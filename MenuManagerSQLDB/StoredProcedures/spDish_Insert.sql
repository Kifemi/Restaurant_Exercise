CREATE PROCEDURE [dbo].[spDish_Insert]
	@Name nvarchar(50),
	@Description nvarchar(50),
	@Price int
AS
BEGIN
	INSERT INTO dbo.Dish (Name, Description, Price)
	VALUES (@Name, @Description, @Price);
END
