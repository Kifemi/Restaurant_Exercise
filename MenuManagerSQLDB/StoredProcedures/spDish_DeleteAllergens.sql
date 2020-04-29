CREATE PROCEDURE [dbo].[spDish_DeleteAllergens]
	@DishId int
AS
BEGIN
	DELETE FROM dbo.DishAllergenCombo
	WHERE DishId = @DishId;
END
