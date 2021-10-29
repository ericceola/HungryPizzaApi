CREATE DATABASE HungryPizzaDb;

GO

USE HungryPizzaDb;

GO


create TABLE Customer
(
  CustomerId  INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  CustomerName VARCHAR(30),
  Cpf VARCHAR(14),
  ContactPhone VARCHAR(14),
  DateCreate DATETIME NOT NULL
)
GO
CREATE TABLE Product
(
  ProductId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  ProductName VARCHAR(50) NOT NULL,
  ProductDescription VARCHAR(500) NOT NULL,
  Price SMALLMONEY  NULL,
  ImageUrl VARCHAR(500) NOT NULL,
  InStock BIT DEFAULT 1 
)
GO
CREATE TABLE CustomerAddress
(
  CustomerAddressId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  CustomerId INT NULL,
  Street VARCHAR(100) NOT NULL,
  Number VARCHAR(10) NOT NULL,
  Complement VARCHAR(50) NULL,
  District VARCHAR(50) NOT NULL,
  City VARCHAR(50) NOT NULL,
  RegionState VARCHAR(2) NOT NULL,
  ZipCode VARCHAR(9)  NULL,
  Surname VARCHAR(15) NOT NULL,

   FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId),
 
)
GO

CREATE TABLE CustomerOrder
(
  OrderId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  CustomerId INT NULL,
  CustomerName VARCHAR(100),
  Amount SMALLMONEY NOT NULL,
  Street VARCHAR(100),
  Number VARCHAR(10),
  Complement VARCHAR(50),
  District VARCHAR(50),
  City VARCHAR(50),
  RegionState VARCHAR(2),
  ZipCode VARCHAR(9),
  ContactPhone VARCHAR(14),
  DateOrder DATETIME NOT NULL
)

GO

CREATE TABLE OrderItem
(
  OrderItemId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  OrderId INT NOT NULL,
  ProductName VARCHAR(100),
  UnitPrice SMALLMONEY NOT NULL,
  Quantity INT NOT NULL,
  Price SMALLMONEY NOT NULL

  FOREIGN KEY (OrderId) REFERENCES CustomerOrder (OrderId),
)


