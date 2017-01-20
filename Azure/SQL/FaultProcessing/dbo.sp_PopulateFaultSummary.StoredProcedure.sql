USE [WO_procs]
GO
/****** Object:  StoredProcedure [dbo].[sp_PopulateFaultSummary]    Script Date: 1/20/2017 12:52:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PopulateFaultSummary]
@Building nvarchar(255) = NULL,
@From datetime = NULL,
@To datetime = NULL
AS
BEGIN
	SET NOCOUNT ON;

	--insert into FaultSummary
----------------
-- VAV Faults --
----------------

-- Failed Closed Primary Air Damper
WITH [FaultSummarySourceCTE] AS
(
	select FullAssetPath, FaultName, cast(Instances as float)/cast(Total as float) Likelihood
	from(
		select FaultCounts.FullAssetPath, FaultCounts.FaultName, FaultCounts.Instances, TotalCounts.Total
		from (
			select FullAssetPath, count(Timestamp) Instances, 'Failed Closed Primary Air Damper' FaultName
			from (
				select VAV.FullAssetPath, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
				from (
					select VAV.FullAssetPath, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
					from Pivot_VAV VAV
					left join DesignVAVInformation Info
					on VAV.FullAssetPath = Info.FullAssetPath
					where (@Building IS NULL OR VAV.[Building] = @Building)
						  AND (@From IS NULL OR VAV.[Timestamp] >= @From)
						  AND (@To IS NULL OR VAV.[Timestamp] <= @From)
				) VAV
				left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
			) as RequiredData
			where DMPR > 99 and FLOWSTPT - FLOW > 100 and SSP > 0.25
			group by FullAssetPath
			union

			--Failed Open Primary Air Damper
			select FullAssetPath, count(Timestamp) Instances, 'Failed Open Primary Air Damper' FaultName
			from (
				select VAV.FullAssetPath, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
				from (
					select VAV.FullAssetPath, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
					from Pivot_VAV VAV
					left join DesignVAVInformation Info
					on VAV.FullAssetPath = Info.FullAssetPath
					where (@Building IS NULL OR VAV.[Building] = @Building)
						  AND (@From IS NULL OR VAV.[Timestamp] >= @From)
						  AND (@To IS NULL OR VAV.[Timestamp] <= @From)
				) VAV
				left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
			) as RequiredData
			where DMPR < 1 and ( FLOW - FLOWSTPT > 100 or FLOW > 100 ) and SSP > 0.25
			group by FullAssetPath
			union


			--Operator Override on Primary Air Damper
			select FullAssetPath, count(Timestamp) Instances, 'Operator Override of Primary Air Damper' FaultName
			from (
				select VAV.FullAssetPath, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
				from (
					select VAV.FullAssetPath, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
					from Pivot_VAV VAV
					left join DesignVAVInformation Info
					on VAV.FullAssetPath = Info.FullAssetPath
					where (@Building IS NULL OR VAV.[Building] = @Building)
						  AND (@From IS NULL OR VAV.[Timestamp] >= @From)
						  AND (@To IS NULL OR VAV.[Timestamp] <= @From)
				) VAV
				left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
			) as RequiredData
			where ( DMPR < 99 and FLOWSTPT - FLOW > 100 or DMPR > 1 and FLOW - FLOWSTPT > 100 ) and SSP > 0.25
			group by FullAssetPath
			union

			-- Failed Primary Airflow Sensor
			select FullAssetPath, count(Timestamp) Instances, 'Failed Airflow Sensor' FaultName
			from (
				select VAV.FullAssetPath, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
				from (
					select VAV.FullAssetPath, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
					from Pivot_VAV VAV
					left join DesignVAVInformation Info
					on VAV.FullAssetPath = Info.FullAssetPath
					where (@Building IS NULL OR VAV.[Building] = @Building)
						  AND (@From IS NULL OR VAV.[Timestamp] >= @From)
						  AND (@To IS NULL OR VAV.[Timestamp] <= @From)
				) VAV
				left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
			) as RequiredData
			where FLOW > 100 and SSP < 0.25
			group by FullAssetPath
			union

			--Failed Primary Airflow Sensor
			select FullAssetPath, count(Timestamp) Instances, 'Failed Airflow Sensor' FaultName
			from (
				select VAV.FullAssetPath, VAV.Timestamp, VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW, AHU.SSP
				from (
					select VAV.FullAssetPath, VAV.Timestamp, Info.AirHandlerRef,VAV.DMPR, VAV.FLOWSTPT, VAV.FLOW
					from Pivot_VAV VAV
					left join DesignVAVInformation Info
					on VAV.FullAssetPath = Info.FullAssetPath
					where (@Building IS NULL OR VAV.[Building] = @Building)
						  AND (@From IS NULL OR VAV.[Timestamp] >= @From)
						  AND (@To IS NULL OR VAV.[Timestamp] <= @From)
				) VAV
				left join Pivot_AHU AHU on VAV.Timestamp = AHU.Timestamp and AHU.FullAssetPath = VAV.AirHandlerRef
			) as RequiredData
			where FLOW > 100 and SSP < 0.25
			group by FullAssetPath
			union

			--Failed Room Temperature Sensor
			select FullAssetPath, count(Timestamp) Instances, 'Failed Room Temperature Sensor' FaultName
			from Pivot_VAV
			where (ROOMTEMP <= 0 OR ROOMTEMP > 100)
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Ineffective Heating
			select FullAssetPath, count(Timestamp) Instances, 'Ineffective Heating' FaultName
			from Pivot_VAV
			where ROOMTEMP < HTGSTPT and OCC = 1 and HTGLPO = 100 and abs(FLOW - FLOWSTPT) < 50
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Ineffective Cooling
			select FullAssetPath, count(Timestamp) Instances, 'Ineffective Cooling' FaultName 
			from Pivot_VAV
			where ROOMTEMP > CLGSTPT and OCC = 1 and CLGLPO = 100 and abs(FLOW - FLOWSTPT) < 50
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Occupied Heating Setpoint Too High
			select FullAssetPath, count(Timestamp) Instances, 'Occupied Heating Setpoint Too High' FaultName 
			from Pivot_VAV
			where HTGSTPT > 74 and OCC = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Occupied Cooling Setpoint Too Low
			select FullAssetPath, count(Timestamp) Instances, 'Occupied Cooling Setpoint Too Low' FaultName 
			from Pivot_VAV
			where CLGSTPT < 71 and OCC = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union


			------------------
			-- DXFCU Faults --
			------------------

			-- Failed Fan
			select FullAssetPath, count(Timestamp) Instances, 'Failed Fan' FaultName
			from Pivot_FCU
			where FANSTS = 0 and FANCMD = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Fan In Hand
			select FullAssetPath, count(Timestamp) Instances, 'Failed Fan' FaultName
			from Pivot_FCU
			where FANSTS = 1 and FANCMD = 0
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Occupied Heating Setpoint Too High
			select FullAssetPath, count(Timestamp) Instances, 'Occupied Heating Setpoint Too High' FaultName 
			from Pivot_FCU
			where HTGSTPT > 74 and OCC = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			--Occupied Cooling Setpoint Too Low
			select FullAssetPath, count(Timestamp) Instances, 'Occupied Cooling Setpoint Too Low' FaultName 
			from Pivot_FCU
			where CLGSTPT < 71 and OCC = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Room Temperature Sensor Issue
			select FullAssetPath, count(Timestamp) Instances, 'Room Temperature Sensor Location' FaultName 
			from Pivot_FCU
			where ROOMTEMP - RAT > 5 and CLGSTPT - RAT > 3
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Lead Lag Schedule Misalignment
			select FullAssetPath, count(Timestamp) Instances, 'Lead Lag Schedule Misalignment' FaultName 
			from Pivot_FCU
			where OCC = 1 and dbo.Occupied(Timestamp,7,18) = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union


			----------------
			-- AHU Faults --
			----------------

			-- Off-Hours Operation
			select FullAssetPath, count(Timestamp) Instances, 'Off-Hours Operation' FaultName
			from Pivot_AHU
			where SFCMD = 1 and dbo.Occupied(Timestamp, 7, 18) = 0
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Insufficient Economizer Utilization
			select FullAssetPath, count(Timestamp) Instances, 'Insufficient Economizer Utilization' FaultName
			from Pivot_AHU
			where SAT - OAT > 4 and (CLGSTG1CMD + CLGSTG2CMD + CLGSTG3CMD + CLGSTG4CMD > 0 or OAD < 100 ) or OAT > SAT and OAT < RAT and OAD < 100 or OAT > RAT and OAD > 25 
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Over-Cooling 
			select FullAssetPath, count(Timestamp) Instances, 'Over-Cooling' FaultName
			from Pivot_AHU
			where SATSTPT - SAT > 5 and SFCMD = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Poor Building Pressure Control
			select FullAssetPath, count(Timestamp) Instances, 'Poor Building Pressure Control' FaultName
			from Pivot_AHU
			where abs(BSP - BSPSTPT) > 0.1 and SFCMD = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union

			-- Dirty Filter
			select FullAssetPath, count(Timestamp) Instances, 'Dirty Filter' FaultName
			from Pivot_AHU
			where SFCMD = 1 and FILSTS = 1
				  AND (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
		) as FaultCounts

		left join
		(
			select FullAssetPath, count(Timestamp) Total 
			from Pivot_VAV 
			where (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union
			select FullAssetPath, count(Timestamp) Total 
			from Pivot_FCU
			where (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
			union
			select FullAssetPath, count(Timestamp) Total 
			from Pivot_AHU
			where (@Building IS NULL OR [Building] = @Building)
				  AND (@From IS NULL OR [Timestamp] >= @From)
				  AND (@To IS NULL OR [Timestamp] <= @From)
			group by FullAssetPath
		) as TotalCounts

		on FaultCounts.FullAssetPath = TotalCounts.FullAssetPath
	) AS Result
)

MERGE [dbo].[FaultSummary] AS FaultSummaryTarget
USING [FaultSummarySourceCTE] AS FaultSummarySource
ON FaultSummaryTarget.[FullAssetPath]= FaultSummarySource.[FullAssetPath]
   AND FaultSummaryTarget.[FaultName] = FaultSummarySource.[FaultName]
WHEN MATCHED THEN
    UPDATE SET FaultSummaryTarget.Likelihood = FaultSummarySource.Likelihood
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([FullAssetPath], [FaultName], [Likelihood])
    VALUES (FaultSummarySource.[FullAssetPath], FaultSummarySource.[FaultName], FaultSummarySource.[Likelihood])
;
END

GO
