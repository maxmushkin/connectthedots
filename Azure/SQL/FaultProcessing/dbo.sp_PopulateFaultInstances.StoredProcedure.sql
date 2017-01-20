USE [WO_procs]
GO
/****** Object:  StoredProcedure [dbo].[sp_PopulateFaultInstances]    Script Date: 1/20/2017 12:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PopulateFaultInstances]
@Building nvarchar(255) = null,
@From datetime = null,
@To datetime = null
AS
BEGIN
	SET NOCOUNT ON;

--insert into FaultInstances

----------------
-- VAV Faults --
----------------
WITH FaultSourceCTE AS 
(
	-- Failed Closed Primary Air Damper
	select [FullAssetPath], [Building], [Timestamp], 'Failed Closed Primary Air Damper' FaultName
	from (
		select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
		from (
			select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
			from Pivot_VAV VAV
			left join DesignVAVInformation Info
			on VAV.FullAssetPath = Info.FullAssetPath
		) VAV
		left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
	) as RequiredData
	where DMPR > 99 and FLOWSTPT - FLOW > 100 and SSP > 0.25
	union

	--Failed Open Primary Air Damper
	select [FullAssetPath], [Building], [Timestamp], 'Failed Open Primary Air Damper' FaultName
	from (
		select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
		from (
			select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
			from Pivot_VAV VAV
			left join DesignVAVInformation Info
			on VAV.FullAssetPath = Info.FullAssetPath
		) VAV
		left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
	) as RequiredData
	where DMPR < 1 and ( FLOW - FLOWSTPT > 100 or FLOW > 100 ) and SSP > 0.25
	union

	--Operator Override on Primary Air Damper
	select [FullAssetPath], [Building], [Timestamp], 'Operator Override of Primary Air Damper' FaultName
	from (
		select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
		from (
			select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
			from Pivot_VAV VAV
			left join DesignVAVInformation Info
			on VAV.FullAssetPath = Info.FullAssetPath
		) VAV
		left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
	) as RequiredData
	where ( DMPR < 99 and FLOWSTPT - FLOW > 100 or DMPR > 1 and FLOW - FLOWSTPT > 100 ) and SSP > 0.25
	union

	-- Failed Primary Airflow Sensor
	select [FullAssetPath], [Building], [Timestamp], 'Failed Airflow Sensor' FaultName
	from (
		select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
		from (
			select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
			from Pivot_VAV VAV
			left join DesignVAVInformation Info
			on VAV.FullAssetPath = Info.FullAssetPath
		) VAV
		left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
	) as RequiredData

	where FLOW > 100 and SSP < 0.25
	union

	--Failed Primary Airflow Sensor
	select [FullAssetPath], [Building], [Timestamp], 'Failed Airflow Sensor' FaultName
	from (
		select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
		from (
			select VAV.FullAssetPath, VAV.Building, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
			from Pivot_VAV VAV
			left join DesignVAVInformation Info
			on VAV.FullAssetPath = Info.FullAssetPath
		) VAV
		left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
	) as RequiredData
	where FLOW > 100 and SSP < 0.25
	union

	--Failed Room Temperature Sensor
	select [FullAssetPath], [Building], [Timestamp], 'Failed Room Temperature Sensor' FaultName
	from Pivot_VAV
	where ROOMTEMP <= 0 or ROOMTEMP > 100 
	union

	--Ineffective Heating
	select [FullAssetPath], [Building], [Timestamp], 'Ineffective Heating' FaultName
	from Pivot_VAV
	where ROOMTEMP < HTGSTPT and OCC = 1 and HTGLPO = 100 and abs(FLOW - FLOWSTPT) < 50
	union

	--Ineffective Cooling
	select [FullAssetPath], [Building], [Timestamp], 'Ineffective Cooling' FaultName 
	from Pivot_VAV
	where ROOMTEMP > CLGSTPT and OCC = 1 and CLGLPO = 100 and abs(FLOW - FLOWSTPT) < 50
	union

	--Occupied Heating Setpoint Too High
	select [FullAssetPath], [Building], [Timestamp], 'Occupied Heating Setpoint Too High' FaultName 
	from Pivot_VAV
	where HTGSTPT > 74 and OCC = 1
	union

	--Occupied Cooling Setpoint Too Low
	select [FullAssetPath], [Building], [Timestamp], 'Occupied Cooling Setpoint Too Low' FaultName 
	from Pivot_VAV
	where CLGSTPT < 71 and OCC = 1
	union


	------------------
	-- DXFCU Faults --
	------------------

	-- Failed Fan
	select [FullAssetPath], [Building], [Timestamp], 'Failed Fan' FaultName
	from Pivot_FCU
	where FANSTS = 0 and FANCMD = 1
	union

	-- Fan In Hand
	select [FullAssetPath], [Building], [Timestamp], 'Failed Fan' FaultName
	from Pivot_FCU
	where FANSTS = 1 and FANCMD = 0
	union

	--Occupied Heating Setpoint Too High
	select [FullAssetPath], [Building], [Timestamp], 'Occupied Heating Setpoint Too High' FaultName 
	from Pivot_FCU
	where HTGSTPT > 74 and OCC = 1
	union

	--Occupied Cooling Setpoint Too Low
	select [FullAssetPath], [Building], [Timestamp], 'Occupied Cooling Setpoint Too Low' FaultName 
	from Pivot_FCU
	where CLGSTPT < 71 and OCC = 1
	union

	-- Room Temperature Sensor Issue
	select [FullAssetPath], [Building], [Timestamp], 'Room Temperature Sensor Location' FaultName 
	from Pivot_FCU
	where ROOMTEMP - RAT > 5 and CLGSTPT - RAT > 3
	union

	-- Lead Lag Schedule Misalignment
	select [FullAssetPath], [Building], [Timestamp], 'Lead Lag Schedule Misalignment' FaultName 
	from Pivot_FCU
	where OCC = 1 and dbo.Occupied(Timestamp,7,18) = 1
	union


	----------------
	-- AHU Faults --
	----------------

	-- Off-Hours Operation
	select [FullAssetPath], [Building], [Timestamp], 'Off-Hours Operation' FaultName
	from Pivot_AHU
	where SFCMD = 1 and dbo.Occupied(Timestamp, 7, 18) = 0
	union

	-- Insufficient Economizer Utilization
	select [FullAssetPath], [Building], [Timestamp], 'Insufficient Economizer Utilization' FaultName
	from Pivot_AHU
	where SAT - OAT > 4 and (CLGSTG1CMD + CLGSTG2CMD + CLGSTG3CMD + CLGSTG4CMD > 0 or OAD < 100 ) or OAT > SAT and OAT < RAT and OAD < 100 or OAT > RAT and OAD > 25 
	union

	-- Over-Cooling 
	select [FullAssetPath], [Building], [Timestamp], 'Over-Cooling' FaultName
	from Pivot_AHU
	where SATSTPT - SAT > 5 and SFCMD = 1
	union

	-- Poor Building Pressure Control
	select [FullAssetPath], [Building], [Timestamp], 'Poor Building Pressure Control' FaultName
	from Pivot_AHU
	where abs(BSP - BSPSTPT) > 0.1 and SFCMD = 1
	union

	-- Dirty Filter
	select [FullAssetPath], [Building], [Timestamp], 'Dirty Filter' FaultName
	from Pivot_AHU
	where SFCMD = 1 and FILSTS = 1
),
[FilteredFaultSourceCTE] AS
(
	SELECT * FROM [FaultSourceCTE]
		WHERE (@Building IS NULL OR [Building] = @Building)
			  AND (@From IS NULL OR [TimeStamp] >= @From)
			  AND (@To IS NULL OR [TimeStamp] <= @To)
)

MERGE [dbo].[FaultInstances] AS FaultTarget
USING [FilteredFaultSourceCTE] AS FaultSource
ON 
	ISNULL(FaultTarget.[FullAssetPath],'') = ISNULL(FaultSource.[FullAssetPath],'') AND 
	ISNULL(FaultTarget.[TimeStamp],0) = ISNULL(FaultSource.[TimeStamp],0) AND 
	ISNULL(FaultTarget.[FaultName],'') = ISNULL(FaultSource.[FaultName],'')
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([FullAssetPath], [Timestamp], [FaultName])
	VALUES (FaultSource.[FullAssetPath], FaultSource.[Timestamp], FaultSource.[FaultName])
; 

END

GO
