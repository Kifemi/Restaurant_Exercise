CREATE PROCEDURE [dbo].[spDish_DeleteAllergenDishCombo]
	@DishId int
AS
BEGIN
	DELETE FROM dbo.DishAllergenCombo
	WHERE DishId = @DishId;
END
