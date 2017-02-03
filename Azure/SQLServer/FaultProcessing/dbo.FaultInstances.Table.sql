USE [WO_procs]
GO
/****** Object:  Table [dbo].[FaultInstances]    Script Date: 2/3/2017 6:51:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultInstances](
	[FullAssetPath] [varchar](1000) NULL,
	[Timestamp] [datetime] NULL,
	[FaultName] [varchar](100) NULL,
	[FaultSavings] [money] NULL
)

GO
