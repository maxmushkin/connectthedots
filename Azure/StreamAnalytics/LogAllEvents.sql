/* Original, worked
Takes as inputs streaming data from IoTHub and reference data in blob, attempts reference join
Good records get stored in dbo.EventHistorian, bad in MissingBACmapEntries
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

SELECT
    /* This worked:
    CONCAT(bm.Region,'/', bm.Campus,'/', bm.Building,'/', bm.EquipmentClass,'/', bm.Floor,'/', bm.unit) AS [FullAssetPath],
    bm.TagName AS [Tag],ih.Asset.PresentValue AS [Value], ih.[Timestamp] AS [Time]
    */
    /* For truncating milliseconds */
    CONCAT(bm.Region,'/', bm.Campus,'/', bm.Building,'/', bm.EquipmentClass,'/', bm.Floor,'/', bm.unit) AS [FullAssetPath],
    bm.TagName AS [Tag],
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
