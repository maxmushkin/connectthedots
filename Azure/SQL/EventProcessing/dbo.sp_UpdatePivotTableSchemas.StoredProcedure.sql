USE [WO_procs]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePivotTableSchemas]    Script Date: 1/20/2017 12:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdatePivotTableSchemas]
AS
BEGIN
	SET NOCOUNT ON;

	EXECUTE [dbo].[sp_UpdatePivotTableSchema] 'VAV'
	EXECUTE [dbo].[sp_UpdatePivotTableSchema] 'AHU'
	EXECUTE [dbo].[sp_UpdatePivotTableSchema] 'FCU'
END

GO
