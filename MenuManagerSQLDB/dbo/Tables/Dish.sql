CREATE TABLE [dbo].[Dish]
(
	[DishId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Price] DECIMAL NULL
)
