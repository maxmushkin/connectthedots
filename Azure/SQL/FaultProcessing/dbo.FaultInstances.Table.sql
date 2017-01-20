USE [WO_procs]
GO
/****** Object:  Table [dbo].[FaultInstances]    Script Date: 1/20/2017 12:51:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultInstances](
	[FullAssetPath] [varchar](1000) NULL,
	[Timestamp] [datetime] NULL,
	[FaultName] [varchar](100) NULL
)

GO
