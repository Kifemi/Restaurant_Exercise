CREATE PROCEDURE [dbo].[spFoodMenu_Insert]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.FoodMenu (Name)
	VALUES (@Name);
END
