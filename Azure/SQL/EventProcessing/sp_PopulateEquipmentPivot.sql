SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PopulateEquipmentPivot]
	-- Add the parameters for the stored procedure here
	@DeviceClass varchar(50),
	@EqupmentClasses varchar(MAX) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PivotTableName varchar(max)
	SET @PivotTableName = 'Pivot_' + @DeviceClass

	IF @EqupmentClasses IS NULL
		SET @EqupmentClasses = '''' + @DeviceClass + '''';

	DECLARE @TagsTable TABLE ([Tag] varchar(50))
	INSERT INTO @TagsTable
	SELECT [COLUMN_NAME]
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_NAME = @PivotTableName AND COLUMN_NAME != 'FullAssetPath' and COLUMN_NAME != 'Timestamp'

	DECLARE @Tags VARCHAR(max)
	SELECT @Tags = COALESCE(@Tags + ', ', '') + QUOTENAME([Tag]) 
		FROM @TagsTable

	DECLARE @Parameters nvarchar(max)
	SET @Parameters = N'@From datetime = NULL'
	
	DECLARE @SqlQuery nvarchar(max)

	DECLARE @From datetime
	SET @SqlQuery = 'SELECT @max=ISNULL(DATEADD(MINUTE, DATEDIFF(MINUTE,0,MAX(TimeStamp))/5*5 + 5, 0), 0) FROM ' + QUOTENAME(@PivotTableName)
	EXECUTE sp_executesql @SqlQuery, N'@max datetime OUTPUT', @max = @From OUTPUT
	
	SET @SqlQuery =
	N'
	WITH RoundedTimeStamp AS 
	(
		SELECT [FullAssetPath], 
			   DATEADD(MINUTE, DATEDIFF(MINUTE, 0, [Timestamp])/5*5, 0) AS [Timestamp],
			   [Tag],
			   [Value]
		FROM [dbo].[EventHistorian] 
		WHERE [TimeStamp] >= @From
			  AND [EquipmentClass] IN ('+@EqupmentClasses+')
	), [GroupedValues] AS
	(
		SELECT [FullAssetPath], [Tag], [Timestamp], ROUND(AVG([Value]), 1) AS [Value]
		FROM RoundedTimeStamp
		GROUP BY [FullAssetPath], [Tag], [TimeStamp]
	)
	
	INSERT INTO [dbo].' + QUOTENAME(@PivotTableName) + '
	SELECT [FullAssetPath], [TimeStamp], ' + @Tags + '
	FROM [GroupedValues]
	PIVOT 
	(
		MAX([Value])
		FOR [Tag] IN (' + @Tags + ')
	) AS PivotTable';
	
	EXECUTE sp_executesql @SqlQuery, @Parameters, @From

	DECLARE @MissingTagNamesFrom datetime
	SELECT @MissingTagNamesFrom = ISNULL(MAX([TimeStamp]), 0) FROM [dbo].[MissingTagNames]
	
	INSERT INTO [dbo].[MissingTagNames]
	SELECT * FROM [dbo].[EventHistorian]
	WHERE [TimeStamp] > @MissingTagNamesFrom
	  AND [Tag] NOT IN (SELECT [Tag] FROM @TagsTable)
	  AND [FullAssetPath] LIKE '%'+@DeviceClass+'%'
END
GO

