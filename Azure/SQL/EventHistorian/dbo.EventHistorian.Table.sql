USE [WO_procs]
GO
/****** Object:  Table [dbo].[EventHistorian]    Script Date: 1/20/2017 12:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventHistorian](
	[TimeStamp] [datetime] NULL,
	[FullAssetPath] [varchar](max) NULL,
	[Building] [nvarchar](255) NULL,
	[EquipmentClass] [varchar](100) NULL,
	[Tag] [varchar](100) NULL,
	[Value] [float] NULL
)

GO
/****** Object:  Index [IX_EventHistorian]    Script Date: 1/20/2017 12:51:59 PM ******/
CREATE CLUSTERED INDEX [IX_EventHistorian] ON [dbo].[EventHistorian]
(
	[TimeStamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_EventHistorian_TimeStamp_EquipmentClass]    Script Date: 1/20/2017 12:52:04 PM ******/
CREATE NONCLUSTERED INDEX [IX_EventHistorian_TimeStamp_EquipmentClass] ON [dbo].[EventHistorian]
(
	[TimeStamp] ASC,
	[EquipmentClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
