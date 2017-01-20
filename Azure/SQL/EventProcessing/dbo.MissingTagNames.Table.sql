USE [WO_procs]
GO
/****** Object:  Table [dbo].[MissingTagNames]    Script Date: 1/20/2017 12:51:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MissingTagNames](
	[TimeStamp] [datetime] NULL,
	[FullAssetPath] [varchar](max) NULL,
	[Building] [nvarchar](255) NULL,
	[EquipmentClass] [varchar](100) NULL,
	[Tag] [varchar](100) NULL,
	[Value] [float] NULL
)

GO
/****** Object:  Index [IX_MissingTagNames]    Script Date: 1/20/2017 12:52:00 PM ******/
CREATE CLUSTERED INDEX [IX_MissingTagNames] ON [dbo].[MissingTagNames]
(
	[TimeStamp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
