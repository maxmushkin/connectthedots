SELECT dateadd(hour,-8,TimeStamp) as TimeStampPST,TimeStamp, FullAssetPath, Building, EquipmentClass Tag, Value
FROM [dbo].[EventHistorian]
WHERE 
building='B19'
and
FullAssetPath not like '%Simulator%'
and
Timestamp >= DATEADD(hour, -6, GETDATE())
ORDER BY Timestamp DESC