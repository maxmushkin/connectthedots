USE [WO_procs]
GO

/****** Object:  Table [dbo].[MissingBACmapEntries]    Script Date: 1/18/2017 4:21:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MissingBACmapEntries](
	[GatewayName] [varchar](31) NOT NULL,
	[DeviceName] [varchar](31) NULL,
	[ObjectType] [varchar](31) NULL,
	[Instance] [varchar](5) NULL,
	[PresentValue] [float] NULL,
	[TimeStamp] [datetime] NULL
)

GO


