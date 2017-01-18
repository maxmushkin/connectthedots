SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MissingTagNames](
	[TimeStamp] [datetime] NULL,
	[FullAssetPath] [varchar](max) NULL,
	[EquipmentClass] [varchar](100) NULL,
	[Tag] [varchar](100) NULL,
	[Value] [float] NULL
)

GO


