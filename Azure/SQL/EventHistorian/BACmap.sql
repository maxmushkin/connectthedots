USE [WO_procs]
GO

/****** Object:  Table [dbo].[BACmap]    Script Date: 1/18/2017 4:20:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BACmap](
	[GatewayName] [varchar](100) NOT NULL,
	[DeviceName] [varchar](100) NOT NULL,
	[ObjectType] [varchar](100) NOT NULL,
	[Instance] [varchar](31) NULL,
	[Region] [varchar](100) NULL,
	[Campus] [varchar](100) NULL,
	[Building] [nvarchar](255) NULL,
	[Floor] [varchar](100) NULL,
	[Unit] [varchar](100) NULL,
	[EquipmentClass] [varchar](100) NULL,
	[EquipmentModel] [varchar](100) NULL,
	[SubsystemClass] [varchar](100) NULL,
	[SubsystemModel] [varchar](100) NULL,
	[TagName] [varchar](100) NOT NULL
)

GO

ALTER TABLE [dbo].[BACmap] ADD  CONSTRAINT [DF_BACmap_ObjectType]  DEFAULT ('') FOR [ObjectType]
GO


