/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [AlbumId]
      ,[Title]
      ,[ArtistId]
  FROM [Chinook].[dbo].[Album]

  select * from [dbo].[Artist]