CREATE TABLE [dbo].[DishesInCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryId] INT NULL, 
    [DishId] INT NULL, 
    CONSTRAINT [FK_DishesInCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId]), 
    CONSTRAINT [FK_DishesInCategory_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dish]([DishId])
)
