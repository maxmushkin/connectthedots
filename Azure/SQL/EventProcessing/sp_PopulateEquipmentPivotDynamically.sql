SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PopulateEquipmentPivotDynamically]
	-- Add the parameters for the stored procedure here
	@DeviceClass varchar(50),
	@From DateTime = null,
	@To DateTime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	DECLARE @Tags VARCHAR(max)
	SELECT @Tags = COALESCE(@Tags + ', ', '') + QUOTENAME([Tag]) FROM [dbo].[EventHistorian]
		WHERE  [FullAssetPath] LIKE '%' + @DeviceClass + '%'
		GROUP BY [Tag]
	
	DECLARE @PivotTableName nvarchar(max)
	SET @PivotTableName = QUOTENAME('Pivot_' + @DeviceClass)

	DECLARE @Parameters nvarchar(max)
	SET @Parameters = N'@From datetime = NULL, @To datetime = NULL'

	DECLARE @SqlQuery nvarchar(max)
	SET @SqlQuery =
	N'
	DROP TABLE IF EXISTS dbo.'+ @PivotTableName + ';
	SELECT [FullAssetPath], [TimeStamp], ' + @Tags + ' 
	INTO [dbo].' + @PivotTableName + '
	FROM 
	(
		SELECT [FullAssetPath], DATEADD(MINUTE, DATEDIFF(MINUTE,0,[TimeStamp])/5*5,0) AS [TimeStamp], [Tag], ROUND(AVG([Value]),1) AS [Value]
		FROM dbo.[EventHistorian] 
		WHERE [FullAssetPath] LIKE ''%'+@DeviceClass+'%''
			  AND (@From IS NULL OR [TimeStamp] >= @From)
			  AND (@To IS NULL OR [TimeStamp] <= @To)
		GROUP BY [FullAssetPath], [Tag], DATEDIFF(MINUTE,0,[TimeStamp])/5*5
	) AS SourceTable
	PIVOT 
	(
		MAX([Value])
		FOR [Tag] IN (' + @Tags + ')
	) AS PivotTable
	ORDER BY TimeStamp DESC';
	EXECUTE sp_executesql @SqlQuery, @Parameters, @From, @To

END


GO

