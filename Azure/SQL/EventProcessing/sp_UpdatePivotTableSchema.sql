SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdatePivotTableSchema]
	@EquipmentClass varchar(50) 
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PivotTableName varchar(max)
	SET @PivotTableName = 'Pivot_' + @EquipmentClass

	DECLARE Tag_Cursor CURSOR 
	  LOCAL STATIC READ_ONLY FORWARD_ONLY
	FOR 
	SELECT [TagName]
		FROM [dbo].[EquipmentTagNames] 
		WHERE [EquipmentClass] = @EquipmentClass
		EXCEPT
			SELECT COLUMN_NAME
				FROM INFORMATION_SCHEMA.COLUMNS
				WHERE TABLE_NAME = @PivotTableName AND COLUMN_NAME != 'FullAssetPath' and COLUMN_NAME != 'Timestamp'
	OPEN Tag_Cursor

	DECLARE @Tag varchar(50)
	DECLARE @AlterTableSql varchar(max)
	FETCH NEXT FROM Tag_Cursor INTO @Tag
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		SET @AlterTableSql = 'ALTER TABLE ' + QUOTENAME(@PivotTableName) + ' ADD ' + QUOTENAME(@Tag) + ' float null'
		EXECUTE (@AlterTableSql)
		FETCH NEXT FROM Tag_Cursor INTO @Tag
	END
	CLOSE Tag_Cursor
	DEALLOCATE Tag_Cursor
END

GO

