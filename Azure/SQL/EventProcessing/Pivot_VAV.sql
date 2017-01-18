SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pivot_VAV](
	[FullAssetPath] [varchar](1000) NULL,
	[Timestamp] [datetime] NULL,
	[CLGLPO] [float] NULL,
	[CLGSTPT] [float] NULL,
	[CTLSTPT] [float] NULL,
	[FLOWSTPT] [float] NULL,
	[HTGLPO] [float] NULL,
	[HTGSTG1CMD] [float] NULL,
	[HTGSTG2CMD] [float] NULL,
	[HTGSTPT] [float] NULL,
	[OCC] [float] NULL,
	[OCCOVRD] [float] NULL,
	[OCCSCHED] [float] NULL,
	[ROOMTEMP] [float] NULL,
	[SAT] [float] NULL,
	[FANCMD] [float] NULL,
	[FLOW] [float] NULL,
	[DMPR] [float] NULL,
	[CLGFLOWMAX] [float] NULL,
	[CLGFLOWMIN] [float] NULL,
	[FANVOLTS] [float] NULL,
	[WIND] [float] NULL
)

GO


