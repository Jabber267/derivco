SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Johann Smit
-- Create date: 2024-04-10
-- Description:	Get a summary of orders
-- =============================================
CREATE PROCEDURE pr_GetOrderSummary
	@StartDate DATE, 
	@EndDate DATE, 
	@EmployeeID INT,
	@CustomerID VARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		CONCAT(e.TitleOfCourtesy, ' ', e.FirstName, ' ', e.LastName)	[EmployeeFullName]
		, s.CompanyName													[ShipperCompanyName]
		, c.CompanyName													[CustomerCompanyName]
		, COUNT(DISTINCT o.OrderID)										[NumberOfOrders]
		, o.OrderDate													[Date]
		, SUM(DISTINCT o.Freight)										[TotalFreightCost]
		, COUNT(DISTINCT d.ProductID)									[NumberOfDifferentProducts]
		, SUM(d.UnitPrice)												[TotalOrderValue]
		, SUM(d.UnitPrice - (d.UnitPrice * d.Discount))					[TotalInclDiscount] -- Included as not sure which one is referred to
	FROM Customers c
	INNER JOIN Orders o				ON o.CustomerID = c.CustomerID
	INNER JOIN [Order Details] d	ON d.OrderID = o.OrderID 
	INNER JOIN Employees e			ON e.EmployeeID = o.EmployeeID
	INNER JOIN Shippers s			ON s.ShipperID = o.ShipVia
	WHERE 
		1=1 -- Alignment OCD (Also makes it easier to remove/add/comment out the first actual filter, personal preference)
		AND o.OrderDate BETWEEN @StartDate AND @EndDate
		AND (@EmployeeID IS NULL OR e.EmployeeID = @EmployeeID)
		AND (@CustomerID IS NULL OR c.CustomerID = @CustomerID)
	GROUP BY
		o.OrderDate
		, CONCAT(e.TitleOfCourtesy, ' ', e.FirstName, ' ', e.LastName)
		, c.CompanyName
		, s.CompanyName

END
GO
