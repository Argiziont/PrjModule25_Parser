﻿CREATE PROCEDURE [dbo].[sp_GetNestedCategoryByParentId]
	-- Add the parameters for the stored procedure here
	@categoryId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	SELECT * FROM Categories ctg WHERE ctg.SupCategoryDataId = @categoryId
END