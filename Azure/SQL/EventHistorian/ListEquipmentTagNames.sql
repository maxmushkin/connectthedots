/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [EquipmentClass]
      ,[TagName]
  FROM [dbo].[EquipmentTagNames]
  where equipmentclass='VAV'