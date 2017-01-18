SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pivot_AHU](
	[FullAssetPath] [varchar](1000) NULL,
	[Timestamp] [datetime] NULL,
	[BSP] [float] NULL,
	[BSPSTPT] [float] NULL,
	[CLGSTG1CMD] [float] NULL,
	[CLGSTG2CMD] [float] NULL,
	[CLGSTG3CMD] [float] NULL,
	[CLGSTG4CMD] [float] NULL,
	[EAD] [float] NULL,
	[FILSTS] [float] NULL,
	[MAT] [float] NULL,
	[OAD] [float] NULL,
	[OAT] [float] NULL,
	[RAT] [float] NULL,
	[RFCMD] [float] NULL,
	[RFSPEED] [float] NULL,
	[SAT] [float] NULL,
	[SATSTPT] [float] NULL,
	[SATSTPTMAX] [float] NULL,
	[SATSTPTMIN] [float] NULL,
	[SFCMD] [float] NULL,
	[SFSPEED] [float] NULL,
	[SSP] [float] NULL,
	[SSPSTPT] [float] NULL,
	[SSPSTPTMAX] [float] NULL,
	[SSPSTPTMIN] [float] NULL
)

GO


