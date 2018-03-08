USE Northwind

CREATE TABLE Account
(
	Username VARCHAR(20) PRIMARY KEY,
	[Password] VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	CustomerId NCHAR(5) REFERENCES Customers(CustomerId),
	EmployeeId INT REFERENCES Employees(EmployeeId)
)

ALTER TABLE Products ADD [ProductImage] NVARCHAR(200)
ALTER TABLE Categories ADD [CategoryImage] NVARCHAR(200)

GO
CREATE PROCEDURE usp_UpdateData
AS
BEGIN
	DECLARE @count INT = 1;
	DECLARE @total AS INT 
	SET @total = (SELECT COUNT(*) FROM Products);
	WHILE @count <= @total
	BEGIN
		UPDATE Products SET ProductImage = '~/Upload/Product/tonton.png' WHERE ProductID = @count;
		SET @count = @count + 1;
		END
END

EXECUTE usp_UpdateData

GO
CREATE PROCEDURE usp_UpdateDataCate
AS
BEGIN
	DECLARE @count INT = 1;
	DECLARE @total AS INT 
	SET @total = (SELECT COUNT(*) FROM Categories);
	WHILE @count <= @total
	BEGIN
		UPDATE Categories SET  [CategoryImage] = '~/Upload/Category/tonton.png' WHERE CategoryID = @count;
		SET @count = @count + 1;
		END
END

EXECUTE usp_UpdateDataCate

GO
CREATE PROCEDURE usp_UpdateDataEmployee
AS
BEGIN
	DECLARE @count INT = 1;
	DECLARE @total AS INT 
	SET @total = (SELECT COUNT(*) FROM Employees);
	WHILE @count <= @total
	BEGIN
		UPDATE Employees SET  PhotoPath = '~/Upload/Category/tonton.png' WHERE EmployeeID = @count;
		SET @count = @count + 1;
		END
END

EXECUTE usp_UpdateDataEmployee

GO
CREATE TABLE [Card]
(
	CardId INT IDENTITY(1,1) PRIMARY KEY,
	ProductId INT REFERENCES Products(ProductId),
	ProductNumber INT,
	CustomerId NCHAR(5) REFERENCES Customers(CustomerId)
)


GO
CREATE PROCEDURE [dbo].[GetCustomers_Pager]
      @PageIndex INT = 1
      ,@PageSize INT = 10
      ,@RecordCount INT OUTPUT
AS
BEGIN
      SET NOCOUNT ON;
      SELECT ROW_NUMBER() OVER
      (
            ORDER BY [ProductID] ASC
      )AS RowNumber
      ,[ProductID]
      ,[ProductName]
      ,[SupplierID]
      ,[CategoryID]
      ,[QuantityPerUnit]
      ,[UnitPrice]
      ,[UnitsInStock]
      ,[UnitsOnOrder]
      ,[ReorderLevel]
      ,[Discontinued]
      ,[ProductImage]
      INTO #Results
      FROM [Northwind].[dbo].[Products]
     
      SELECT @RecordCount = COUNT(*)
      FROM #Results
           
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
     
      DROP TABLE #Results
END