/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  [TimeStamp]
      ,[FullAssetPath]
      ,[EquipmentClass]
      ,[Tag]
      ,[Value]
  FROM [dbo].[MissingTagNames]
  order by timestamp desc