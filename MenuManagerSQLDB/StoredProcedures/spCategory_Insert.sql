CREATE PROCEDURE [dbo].[spCategory_Insert]
	@Name nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.Category (Name)
	VALUES (@Name);
END
