CREATE PROCEDURE [dbo].[spCategory_Delete]
	@CategoryId int
AS
BEGIN
	DELETE FROM dbo.Category
	WHERE CategoryId = @CategoryId;
END
