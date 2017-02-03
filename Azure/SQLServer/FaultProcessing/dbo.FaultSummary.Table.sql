USE [WO_procs]
GO
/****** Object:  Table [dbo].[FaultSummary]    Script Date: 2/3/2017 6:51:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultSummary](
	[FullAssetPath] [varchar](1000) NULL,
	[FaultName] [varchar](100) NULL,
	[Likelihood] [float] NULL,
	[FaultSavings] [money] NULL
)

GO
