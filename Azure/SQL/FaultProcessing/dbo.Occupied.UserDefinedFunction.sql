USE [WO_procs]
GO
/****** Object:  UserDefinedFunction [dbo].[Occupied]    Script Date: 1/20/2017 12:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------
-- OCCUPANCY FUNCTION --
------------------------

-- Will compare timestamp of data column to determine if dataset occurred during or outside
-- occupied hours. Will return 1 if the timestamp occurs during occupied times; will return 0
-- if the timestamp occurs outside of occupied times.

CREATE FUNCTION [dbo].[Occupied]
(
	@Time datetime, @StartTime int, @EndTime int
)
RETURNS int
AS
BEGIN

	declare @Result int

	if (datepart(hh,@Time) between @StartTime and @EndTime and datepart(dw,@Time) between 2 and 6) 

		set @Result = 1

	else set @Result = 0
	return @Result

END

GO
