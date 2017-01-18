SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PopulateEquipmentPivots]
AS
BEGIN
	SET NOCOUNT ON;

	EXECUTE [dbo].[sp_PopulateEquipmentPivot] 'VAV', '''VAV'',''SVAV'',''PVAV'',''VSVAV'''
	EXECUTE [dbo].[sp_PopulateEquipmentPivot] 'AHU'
	EXECUTE [dbo].[sp_PopulateEquipmentPivot] 'FCU', '''DXFCU'''

END

GO

