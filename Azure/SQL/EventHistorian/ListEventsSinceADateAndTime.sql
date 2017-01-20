select FullAssetPath, Time, 
FLOW,
[HTG STG 1],
[FLOW STPT],
DMPR,
DAT,
[FAN CMD],
[HTG LPO],
[CLG LPO],
OCC,
[ROOM TEMP],
[CLG STPT],
[HTG STPT]

 from Pivot_VAV 
 where FullAssetPath like '%LabVAV'
 and Time BETWEEN DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), '14:00:00.000') AND GETDATE()
 order by time desc