CREATE PROCEDURE [dbo].[spDish_InsertAllergen]
	@DishId int,
	@AllergenId int
AS
BEGIN
	INSERT INTO dbo.DishAllergenCombo
	VALUES (@DishId, @AllergenId);
END
