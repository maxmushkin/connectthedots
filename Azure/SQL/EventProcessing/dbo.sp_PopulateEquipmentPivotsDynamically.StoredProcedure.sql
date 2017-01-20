USE [WO_procs]
GO
/****** Object:  StoredProcedure [dbo].[sp_PopulateEquipmentPivotsDynamically]    Script Date: 1/20/2017 12:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PopulateEquipmentPivotsDynamically]
	@From DateTime = null,
	@To DateTime = null
AS
BEGIN
	SET NOCOUNT ON;

	EXECUTE [dbo].[sp_PopulateEquipmentPivotDynamically] 'VAV', @From, @To
	EXECUTE [dbo].[sp_PopulateEquipmentPivotDynamically] 'AHU', @From, @To
	EXECUTE [dbo].[sp_PopulateEquipmentPivotDynamically] 'FCU', @From, @To

END


GO
