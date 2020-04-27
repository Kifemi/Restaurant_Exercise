CREATE TABLE [dbo].[Category]
(
	CategoryId INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [MenuId] INT NULL, 
    CONSTRAINT [FK_Category_Menu] FOREIGN KEY ([MenuId]) REFERENCES [FoodMenu]([FoodMenuId]) 
)
