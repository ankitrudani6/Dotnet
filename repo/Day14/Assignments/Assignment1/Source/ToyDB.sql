CREATE DATABASE ToyCompany
GO
Drop Database ToyCompany
USE ToyCompany
GO
use MMTTest

CREATE TABLE Address(
	AddressID INT PRIMARY KEY IDENTITY(1,1),
	Address NVARCHAR(100),
	City VARCHAR(30),
	State VARCHAR(30),
	PinCode INT
);

INSERT INTO Address VALUES
('Mistry Street, near ramji temple','Dhari','Gujrat',365640),
('3, Vardhman Flat, Paldi','Ahmedabad','Gujrat',380007),
('58, Ravipark Society, Near Love Temple','Rajkot','Gujrat',360001)

CREATE TABLE CustomerAddress(
	CustomerAddressID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT CONSTRAINT FK_AL_CustomerID FOREIGN KEY REFERENCES Customer,
	AddressID INT CONSTRAINT FK_AL_AddressID FOREIGN KEY REFERENCES Address,
	IsDefault BIT DEFAULT 0
);

INSERT INTO CustomerAddress VALUES
(1,1,1),
(1,2,0),
(2,3,1)

CREATE TABLE Customer(
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	Gender CHAR CONSTRAINT CK_Gender CHECK(Gender IN ('M','F','O')),
	DOB DATE,
	Email NVARCHAR(50) UNIQUE,
	PhoneNumber NUMERIC(10) UNIQUE
);

INSERT INTO Customer VALUES
('Ankit','Rudani','M','01/06/1998','ankitrudani@gmail.com',9988776655),
('Mihir','Panara','M','03/12/1999','mihirpanara@gmail.com',8899876543),
('Raj','Thakkar','M','03/01/1998','rajthakkar@gmail.com',7889987654),
('Jeet','Vegad','M','12/06/1995','jeetvegad@gmail.com',8999009988),
('Nikunj','Jani','M','09/01/1999','nikunjjani@gmail.com',9999887766)


CREATE TABLE ManufacturingPlant(
	PlantID INT PRIMARY KEY IDENTITY(1,1),
	PlantName VARCHAR(30) NOT NULL,
);

INSERT INTO ManufacturingPlant VALUES
('Plant1'),
('Plant2'),
('Plant3')

CREATE TABLE ToyType(
	ToyTypeID INT PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(30) NOT NULL
);

INSERT INTO ToyType VALUES
('Electronic'),
('Educational')


CREATE TABLE Toy(
	ToyID INT PRIMARY KEY IDENTITY(1,1),
	ToyName VARCHAR(30) NOT NULL,
	Description VARCHAR(100),
	Price MONEY NOT NULL,
	PlantID INT CONSTRAINT FK_Toy_PlantID FOREIGN KEY REFERENCES ManufacturingPlant,
	ToyTypeID INT CONSTRAINT FK_Toy_ToyTypeID FOREIGN KEY REFERENCES ToyType
);

INSERT INTO Toy VALUES
('Plane',null,1500,1,1),
('Bike',null,749,1,1),
('Train',null,999,2,1),
('Building Blocks',null,849,2,2),
('Colour Matching Egg ',null,800,3,2)


CREATE TABLE [Order](
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	OrderDate DATETIME DEFAULT GETDATE(),
	CustomerID INT CONSTRAINT FK_Order_CustomerID FOREIGN KEY REFERENCES Customer
);

INSERT INTO [Order] VALUES
(GETDATE(),1,1),
(GETDATE(),2,2),
(GETDATE(),3,3)

CREATE TABLE OrderToy(
	OrderToyID INT PRIMARY KEY IDENTITY(1,1),
	OrderID INT CONSTRAINT FK_OrderToy_OrderID FOREIGN KEY REFERENCES [Order],
	ToyID INT CONSTRAINT FK_OrderToy_ToyID FOREIGN KEY REFERENCES Toy,
	Qty INT CONSTRAINT CK_Qty CHECK(Qty > 0) ,
	Amount MONEY,
	Discount DECIMAL(4,2)
);

INSERT INTO OrderToy(OrderID, ToyID, Qty) VALUES
(1,1,5),
(1,3,2),
(2,2,3),
(2,1,7),
(3,4,4)