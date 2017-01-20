USE [WO_procs]
GO
/****** Object:  Table [dbo].[DesignVAVInformation]    Script Date: 1/20/2017 12:51:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesignVAVInformation](
	[FullAssetPath] [varchar](1000) NULL,
	[AirHandlerRef] [varchar](1000) NULL,
	[Model] [varchar](100) NULL,
	[DesignCLGFLOWMAX] [float] NULL,
	[DesignCLGFLOWMIN] [float] NULL,
	[HeaterCapacity] [float] NULL
)

GO
