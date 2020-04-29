CREATE PROCEDURE [dbo].[spDish_Edit]
	@Name nvarchar(50),
	@Description nvarchar(50),
	@Price decimal,
	@DishId int
AS
BEGIN
	UPDATE dbo.Dish
	SET Name = @Name,
		Description = @Description, 
		Price = @Price
	WHERE DishId = @DishId;
END
