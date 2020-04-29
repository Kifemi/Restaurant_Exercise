CREATE PROCEDURE [dbo].[spDish_Exists]
	@Name nvarchar(50)
AS
BEGIN
	SELECT Name
	FROM dbo.Dish
	WHERE EXISTS (SELECT Name FROM dbo.Dish WHERE Name = @Name);
END
