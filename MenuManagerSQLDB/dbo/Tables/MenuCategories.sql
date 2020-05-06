CREATE TABLE [dbo].[MenuCategories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FoodMenuId] INT NULL, 
    [CategoryId] INT NULL, 
    CONSTRAINT [FK_MenuCategories_FoodMenuId] FOREIGN KEY ([FoodMenuId]) REFERENCES [FoodMenu]([FoodMenuID]), 
    CONSTRAINT [FK_MenuCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])
)
