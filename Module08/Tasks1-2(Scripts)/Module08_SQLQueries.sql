-- Task 1.1

--1
select ord.OrderID, ord.ShippedDate, ord.ShipVia
from Orders as ord
where ShippedDate >= '1998-05-06' AND ShipVia >= 2

--2
select OrderID, ShippedDate = 
case
	when ShippedDate IS NULL then 'Not Shipped'
end
from Orders
where ShippedDate IS NULL

--3
select OrderID as [Order Number], [Shipped Date] =  
case
	when ShippedDate IS NULL then 'Not Shipped'  
end
from Orders
where ShippedDate > '1998-05-06' OR ShippedDate IS NULL

-- Task 1.2

--1
select CompanyName as [Company Name], Country
from Customers
where Country in ('USA', 'Canada')
order by Country, CompanyName 

--2
select CompanyName as [Company Name], Country
from Customers
where Country not in ('USA', 'Canada')
order by CompanyName 
 
--3
 select distinct Country
 from Customers
 order by Country desc

-- Task 1.3

--1
select distinct OrderID
from [Order Details]
where Quantity BETWEEN 3 AND 10

--2
select CustomerID, Country
from Customers
where Country between 'b%' AND 'h%' 
order by Country

--3
select CustomerID, Country
from Customers
where Country LIKE '[b-g]%'

-- Task 1.4

--1
select ProductName
from Products
where ProductName like '%chocolate%' and '%chocolate%' like '%c%'

-- Task 2.1

--1 
select sum((UnitPrice - (UnitPrice * Discount)) * Quantity) as Totals
from [Order Details]

--2
select (count(*) - count(ShippedDate)) as [Not Shipped Yet]
from Orders

--3
select count(distinct CustomerID) as [Customers who made orders]
from Orders

-- Task 2.2

--1 
select year(OrderDate) as [Year], count(year(OrderDate)) as [Total]
from Orders
group by year(OrderDate) 
order by year(OrderDate) asc

select count(OrderDate) as [Total Orders]
from Orders

--2 
select concat (emp.LastName + ' ', emp.FirstName) as [Seller], count(OrderDate) as [Amount]
from Orders as ord
inner join Employees as emp
on ord.EmployeeID = emp.EmployeeID
group by emp.LastName, emp.FirstName, ord.EmployeeID
order by [Amount] desc

--3
select emp.FirstName + ' ' + emp.LastName as [Seller], ord.CustomerID, count(ord.OrderID) as [Number of Orders]
from Orders as ord
inner join Employees as emp
on ord.EmployeeID = emp.EmployeeID and Year(ord.OrderDate) = 1998
group by emp.FirstName, emp.LastName, ord.CustomerID

--4
select cust.CompanyName, emp.FirstName + ' ' + emp.LastName as [Seller]
from Customers cust, Employees emp
where cust.City = emp.City

--5
select cust.CompanyName, cust.City, count(*)
from Customers cust
group by cust.CompanyName, cust.City

--6
select E.FirstName as Employee, M.FirstName as Manager
from Employees E
left join Employees M
on E.ReportsTo = M.EmployeeID

-- Task 2.3

--1 
select emp.FirstName as [Seller's Name], reg.RegionDescription as [Region]
from Employees as emp
inner join Region as reg
on emp.RegionID = reg.RegionID and reg.RegionDescription = 'Western'

--2
select cust.CompanyName as [Customer Name], count(ord.OrderID) as [Number of Orders]
from Customers as cust
inner join Orders as ord
on cust.CustomerID = ord.CustomerID
group by cust.CompanyName
order by [Number of Orders]

-- Task 2.4

--1 
select distinct sup.CompanyName, prod.UnitsInStock
from Suppliers as sup
left join Products as prod
on sup.SupplierID = prod.SupplierID
where prod.UnitsInStock in (Select UnitsInStock from Products where UnitsInStock = 0);

--2
select emp.FirstName, count(ord.OrderID) as [Number of Orders]
from Employees as emp
inner join Orders as ord
on ord.EmployeeID = emp.EmployeeID
group by emp.FirstName
having count(ord.OrderID) in (select count(ord.OrderID) from Orders where count(ord.OrderID) > 150)

--3
select  *
from Customers as cust
where exists (select OrderID from Orders, Customers where Orders.CustomerID not in (Customers.CustomerID));






