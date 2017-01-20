/* 
ASA job: LogAllEvents
Date: January 2017

Takes as inputs streaming data from IoTHub and reference data in blob, attempts reference join.
Good records get stored in dbo.EventHistorian, bad in MissingBACmapEntries

*/

/*
Reference data stored in SQL table dbo.BACmap
Azure Data Factory job SmartBuildingDF exports to blob as CSV file every hour. Would be better to export only when dbo.BACmap changes, but trigger mechanism not available in SQL Azure
BACmap.csv stored in {date}/{time} format to support ASA choosing latest version
Following code attempts the join data from IoT Hub with BACmap.csv. If JOIN returns no records, 
send IoT Hub record to SQL table dbo.MissingBACmapEntries. If JOIN returns records, send to next SELECT statement
*/
WITH joinedData AS
(
SELECT ih, bm
FROM [SBHubv2] ih
LEFT JOIN [BACmap] bm
    ON ih.GatewayName = bm.GatewayName AND ih.Asset.DeviceName = bm.DeviceName AND ih.Asset.ObjectType = bm.ObjectType AND (CASE WHEN ih.Asset.Instance IS NULL THEN '\N' ELSE ih.Asset.Instance END) = bm.Instance
)

SELECT 
        ih.GatewayName,
        ih.Asset.DeviceName,
        ih.Asset.ObjectType,
        ih.Asset.Instance,
        
        CASE 
            WHEN TRY_CAST(ih.Asset.PresentValue AS NVARCHAR(MAX)) = 'inactive' THEN 0
            WHEN TRY_CAST(ih.Asset.PresentValue AS NVARCHAR(MAX)) = 'active' THEN 1
            ELSE TRY_CAST (ih.Asset.PresentValue AS FLOAT) 
        END AS [PresentValue],

        CAST(DATETIMEFROMPARTS(
        DATEPART(year,ih.[Timestamp]),
        DATEPART(month,ih.[Timestamp]),
        DATEPART(day,ih.[Timestamp]),
        DATEPART(hour,ih.[Timestamp]),
        DATEPART(minute,ih.[Timestamp]),
        DATEPART(second,ih.[Timestamp]),
        00) AS DateTime)
     AS [TimeStamp]
INTO MissingBACmapEntries
FROM joinedData
WHERE bm IS NULL

/* 
Format and send records to SQL table dbo.EventHistorian
Goal of JOIN is to map incoming records with BACmap addressing scheme (GatewayName, DeviceName, ObjectType, Instance) to
physical address (building, floor, equipment type, sensor type). BACmap address no longer valuable, and not stored in EventHistorian
*/
SELECT
    /* For truncating milliseconds */
    CONCAT(bm.Region,'/', bm.Campus,'/', bm.Building,'/', bm.EquipmentClass,'/', bm.Floor,'/', bm.unit) AS [FullAssetPath],
    bm.EquipmentClass,
    bm.TagName AS [Tag],
    /*
    TRY_CAST used to capture data send as known strings rather than numbers
    */
    CASE 
        WHEN TRY_CAST(ih.Asset.PresentValue AS NVARCHAR(MAX)) = 'inactive' THEN 0
        WHEN TRY_CAST(ih.Asset.PresentValue AS NVARCHAR(MAX)) = 'active' THEN 1
        ELSE TRY_CAST (ih.Asset.PresentValue AS FLOAT) 
    END AS [Value],
 
    CAST(DATETIMEFROMPARTS(
        DATEPART(year,ih.[Timestamp]),
        DATEPART(month,ih.[Timestamp]),
        DATEPART(day,ih.[Timestamp]),
        DATEPART(hour,ih.[Timestamp]),
        DATEPART(minute,ih.[Timestamp]),
        DATEPART(second,ih.[Timestamp]),
        00) AS DateTime)
     AS [TimeStamp]
INTO
    [EventHistorian]
FROM
    joinedData
WHERE bm IS NOT NULL               
