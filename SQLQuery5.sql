/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *

  FROM [DBProgra1 A].[dbo].[Tb_alumnos]
  where parcial2>15
  order by parcial2
