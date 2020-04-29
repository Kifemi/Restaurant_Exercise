CREATE PROCEDURE [dbo].[spDish_Delete]
	@DishId int
AS
BEGIN
	DELETE FROM dbo.Dish
	WHERE DishId = @DishId;
END
