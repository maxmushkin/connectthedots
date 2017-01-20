USE [WO_procs]
GO
/****** Object:  StoredProcedure [dbo].[sp_PopulateEquipmentPivot]    Script Date: 1/20/2017 12:52:04 PM ******/
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
		WHERE TABLE_NAME = @PivotTableName 
			  AND COLUMN_NAME != 'FullAssetPath' 
			  AND COLUMN_NAME != 'Timestamp' 
			  AND COLUMN_NAME != 'Building'

	DECLARE @Tags VARCHAR(max)
	SELECT @Tags = COALESCE(@Tags + ', ', '') + QUOTENAME([Tag]) 
		FROM @TagsTable

	DECLARE @Parameters nvarchar(max)
	SET @Parameters = N'@From datetime = NULL'
	
	DECLARE @SqlQuery nvarchar(max)

	DECLARE @From datetime
	SET @SqlQuery = 'SELECT @max=ISNULL(MAX(TimeStamp), 0) FROM ' + QUOTENAME(@PivotTableName)
	EXECUTE sp_executesql @SqlQuery, N'@max datetime OUTPUT', @max = @From OUTPUT
	

	DECLARE @InsertColumnsStatement varchar(max);
	SELECT @InsertColumnsStatement = COALESCE(@InsertColumnsStatement + ', ', '') + QUOTENAME([COLUMN_NAME])
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_NAME = @PivotTableName 

	DECLARE @InsertValuesStatement varchar(max);
	SELECT @InsertValuesStatement = COALESCE(@InsertValuesStatement + ', ', '') + CONCAT('PivotSource.',QUOTENAME([COLUMN_NAME]))
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_NAME = @PivotTableName 

	DECLARE @UpdateSetStatement varchar(max);
	SELECT @UpdateSetStatement = COALESCE(@UpdateSetStatement + ', ', '') + CONCAT('PivotTarget.',QUOTENAME([Tag]),' = PivotSource.', QUOTENAME([Tag]))
		FROM @TagsTable
	SET @SqlQuery =
	N'
	WITH [RoundedTimeStamp] AS 
	(
		SELECT [FullAssetPath], 
			   [Building],
			   DATEADD(MINUTE, DATEDIFF(MINUTE, 0, [Timestamp])/5*5, 0) AS [Timestamp],
			   [Tag],
			   [Value]
		FROM [dbo].[EventHistorian] 
		WHERE [TimeStamp] >= @From
			  AND [EquipmentClass] IN ('+@EqupmentClasses+')
	), [GroupedValues] AS
	(
		SELECT [FullAssetPath], [Building], [Tag], [Timestamp], ROUND(AVG([Value]), 1) AS [Value]
		FROM RoundedTimeStamp
		GROUP BY [FullAssetPath], [Building], [Tag], [TimeStamp]
	), [PivotTable] AS
	(
		SELECT [FullAssetPath], [Building], [TimeStamp], ' + @Tags + '
		FROM [GroupedValues]
		PIVOT 
		(
			MAX([Value])
			FOR [Tag] IN (' + @Tags + ')
		) AS PivotTable
	)
	
	MERGE [dbo].' + QUOTENAME(@PivotTableName) + ' AS PivotTarget
	USING [PivotTable] AS PivotSource
	ON 
		ISNULL(PivotTarget.[FullAssetPath],'''') = ISNULL(PivotSource.[FullAssetPath],'''') AND 
		ISNULL(PivotTarget.[Building],'''') = ISNULL(PivotSource.[Building],'''') AND 
		ISNULL(PivotTarget.[TimeStamp],0) = ISNULL(PivotSource.[TimeStamp],0)
	WHEN MATCHED THEN
		UPDATE SET '+@UpdateSetStatement+'
	WHEN NOT MATCHED BY TARGET THEN
		INSERT ('+@InsertColumnsStatement+')
		VALUES ('+@InsertValuesStatement+')
	;';
	
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
