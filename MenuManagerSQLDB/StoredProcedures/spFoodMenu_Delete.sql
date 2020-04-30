CREATE PROCEDURE [dbo].[spFoodMenu_Delete]
	@FoodMenuId int
AS
BEGIN
	DELETE FROM dbo.FoodMenu
	WHERE FoodMenuId = @FoodMenuId;
END
