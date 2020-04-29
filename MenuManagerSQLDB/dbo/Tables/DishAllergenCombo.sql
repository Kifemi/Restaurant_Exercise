CREATE TABLE [dbo].[DishAllergenCombo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DishId] INT NULL, 
    [AllergenId] INT NULL, 
    CONSTRAINT [FK_DishAllergenCombo_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dish]([DishId]), 
    CONSTRAINT [FK_DishAllergenCombo_AllergenId] FOREIGN KEY ([AllergenId]) REFERENCES [Allergen]([AllergenId])
)
