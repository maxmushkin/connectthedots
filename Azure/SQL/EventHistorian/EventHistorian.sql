USE [WO_procs]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventHistorian](
	[TimeStamp] [datetime] NULL,
	[FullAssetPath] [varchar](max) NULL,
	[EquipmentClass] [varchar](100) NULL,
	[Tag] [varchar](100) NULL,
	[Value] [float] NULL
)

GO

CREATE CLUSTERED INDEX [IX_EventHistorian] ON [dbo].[EventHistorian]
(
	[TimeStamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

CREATE NONCLUSTERED INDEX [IX_EventHistorian_TimeStamp_EquipmentClass] ON [dbo].[EventHistorian]
(
	[TimeStamp] ASC,
	[EquipmentClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO





