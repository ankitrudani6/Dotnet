CREATE DATABASE DotnetDB
GO
USE DotnetDB
GO

CREATE TABLE Person(
	PersonID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(15) NOT NULL,
	LastName VARCHAR(15) NOT NULL,
	BirthDate DATE,
	Email NVARCHAR(50),
	PhoneNumber NUMERIC(10) CONSTRAINT CK_PhoneNumber CHECK(PhoneNumber BETWEEN 6000000000 AND 9999999999),
	City VARCHAR(20)
);
GO

INSERT INTO Person VALUES
('Ankit','Rudani','01/06/1998','ankitrudani@gmail.com',9974289426,'Dhari'),
('Ankur','Rudani','01/06/1998','ankurrudani@gmail.com',7874750953,'Dhari'),
('Dhairya','Sanghrajka','09/02/1998','Dhari@gmail.com',9737440449,'Dhari'),
('Sarju','Dhokiya','06/25/1996','sarjudhokiya@gmail.com',7878521452,'Jamnagar'),
('Darshan','Kotak','12/30/1995','darshankotak@gmail.com',8400014410,'Rajkot')

SELECT * FROM Person
