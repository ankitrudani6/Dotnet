USE master
DROP DATABASE MakeMyTripDB

CREATE DATABASE MakeMyTripDB
GO

USE MakeMyTripDB
GO

CREATE TABLE Country(
	CountryID INT CONSTRAINT PK_CountryID PRIMARY KEY IDENTITY(1,1),
	CountryName VARCHAR(20),
	CountryCode INT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE LoginInfo(
	UserID INT CONSTRAINT PK_UserID PRIMARY KEY IDENTITY(1,1),
	EmailAddress VARCHAR(50),
	PhoneNumber NUMERIC(10) CONSTRAINT CH_PhoneNumber CHECK(PhoneNumber BETWEEN 6000000000 AND 9999999999),
	Password NVARCHAR(16) NOT NULL,
	isAdmin BIT DEFAULT 0,
	isActive BIT DEFAULT 1,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE ProfileInfo(
	ProfileID INT CONSTRAINT PK_ProfileID PRIMARY KEY IDENTITY(1,1),
	UserID INT CONSTRAINT FK_ProfileInfo_LoginInfo FOREIGN KEY REFERENCES LoginInfo,
	FirstName VARCHAR(20),
	LastName VARCHAR(20),
	BirthDate DATE,
	Gender VARCHAR(6) CONSTRAINT CK_gender CHECK(Gender IN ('MALE','FEMALE','OTHER')),
	MaritalStatus VARCHAR(7) CONSTRAINT CK_MaritalStatus CHECK(MaritalStatus IN ('Married','Single')),
	PassportNumber VARCHAR(8),
	IssuingCountryID INT CONSTRAINT FK_ProfileInfo_IssuingCountryID FOREIGN KEY REFERENCES Country(CountryID),
	ExpiredDate DATE,
	isTraveller BIT DEFAULT 0,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Airline(
	AirLineID INT CONSTRAINT PK_AirLineID PRIMARY KEY IDENTITY(1,1),
	AirLineName VARCHAR(15) NOT NULL UNIQUE,
	AirLineCode VARCHAR(2) NOT NULL UNIQUE,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE FlightCodes(
	FlightCodeID INT CONSTRAINT PK_FlightCodeID PRIMARY KEY IDENTITY(1,1),
	AirLineID INT CONSTRAINT FK_FlightCode_AirlineID FOREIGN KEY REFERENCES Airline,
	FlightCode INT NOT NULL,
);
CREATE TABLE Location(
	LocationID INT CONSTRAINT PK_LocationID PRIMARY KEY IDENTITY(1,1),
	LocationName VARCHAR(20) NOT NULL UNIQUE,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Flight(
	FlightID INT CONSTRAINT PK_FlightID PRIMARY KEY IDENTITY(1,1),
	FlightCodeID INT CONSTRAINT FK_Flight_FlightCodeID FOREIGN KEY REFERENCES FlightCodes,
	SourceID INT CONSTRAINT FK_Flight_SourceID FOREIGN KEY REFERENCES Location(LocationID),
	DestinationID INT CONSTRAINT FK_Flight_DestinationID FOREIGN KEY REFERENCES Location(LocationID),
	DepartureTime TIME,
	ArrivalTime TIME,
	Duration INT CONSTRAINT CK_Duration CHECK(Duration >0),
	TotalSeats INT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Schedule(
	ScheduleID INT CONSTRAINT PK_ScheduleID PRIMARY KEY IDENTITY(1,1),
	FlightID INT CONSTRAINT FK_Schedule_FlightID FOREIGN KEY REFERENCES Flight,
	DepartureDate DATE,
	BaseFare MONEY NOT NULL,
	Surcharges MONEY NOT NULL,
	Total MONEY,
	AvailableSeats INT DEFAULT 0,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE TripTypes(
	TripTypeID INT CONSTRAINT PK_TripTypeID PRIMARY KEY IDENTITY(1,1),
	TripType VARCHAR(20) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE PassengerTypes(
	PassengerTypeID INT CONSTRAINT PK_PassengerTypeID PRIMARY KEY IDENTITY(1,1),
	PassengerType VARCHAR(20) NOT NULL,
	AgeFrom INT,
	AgeUpto INT,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE TravelClasses(
	TravelClassID INT CONSTRAINT PK_TravelClass PRIMARY KEY IDENTITY(1,1),
	TravelClass VARCHAR(20) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Insurance(
	InsuranceID INT CONSTRAINT PK_InsuranceID PRIMARY KEY IDENTITY(1,1),
	InsuranceName VARCHAR(30) NOT NULL,
	Charge MONEY NOT NULL
);

CREATE TABLE Discount(
	DiscountID INT CONSTRAINT PK_DiscountID PRIMARY KEY IDENTITY(1,1),
	DiscountCode VARCHAR(20) NOT NULL,
	DiscountPer INT CONSTRAINT CK_DiscountPer CHECK(DiscountPer BETWEEN 0 AND 100),
	DiscountDiscription VARCHAR(100),
	StartDate DATETIME,
	ExpriedDate DATETIME,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE FlightBooking(
	FlightBookingID INT CONSTRAINT PK_FlightBooking PRIMARY KEY IDENTITY(1,1),
	ScheduleID INT CONSTRAINT FK_FlightBooking_ScheduleID FOREIGN KEY REFERENCES Schedule,
	TripTypeID INT CONSTRAINT FK_FlightBooking_TripTypeID FOREIGN KEY REFERENCES TripTypes,
	TravelClassID INT CONSTRAINT FK_FlightBooking_TravelClassID FOREIGN KEY REFERENCES TravelClasses,
	NoOfPassenger INT DEFAULT 0,
	TotalFare MONEY,
	TotalSurcharge MONEY,
	TravellInsurance BIT,
	CovidInsurance BIT,
	TotalAmount MONEY,
	DiscountID INT CONSTRAINT FK_FlightBooking_DiscountID FOREIGN KEY REFERENCES Discount,
	PayableAmount MONEY,
	GSTCompanyName VARCHAR(50),
	GSTRegistrationNo VARCHAR(15),
	DateOfBooking DATETIME DEFAULT GETDATE(),
	Status VARCHAR(10) DEFAULT 'Success' CONSTRAINT CK_FlightBooking_Status CHECK(Status IN('Pending','Success','Failed','Cancelled')),
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE FlightBookingLine(
	FlightBookingLineID INT CONSTRAINT PK_FlightBookingLineID PRIMARY KEY IDENTITY(1,1),
	FlightBookingID INT CONSTRAINT FK_FlightBookingLine_FlightBookingID FOREIGN KEY REFERENCES FlightBooking,
	ProfileID INT CONSTRAINT FK_FlightBookingLine_ProfileID FOREIGN KEY REFERENCES ProfileInfo,
	PassengerTypeID INT CONSTRAINT FK_FlightBooking_PassengerTypeID FOREIGN KEY REFERENCES PassengerTypes,
	SeatNumber VARCHAR(5) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE PaymentTypes(
	PaymentTypeID INT CONSTRAINT PK_PaymentTypeID PRIMARY KEY IDENTITY(1,1),
	PaymentType VARCHAR(20) NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Payment(
	PaymentID INT CONSTRAINT PK_PaymentID PRIMARY KEY IDENTITY(1,1),
	FlightBookingID INT CONSTRAINT FK_Payment_FlightBookingID FOREIGN KEY REFERENCES FlightBooking,
	PaymentTypeID INT CONSTRAINT FK_Payment_PaymentTypeID FOREIGN KEY REFERENCES PaymentTypes,
	PaymentStatus VARCHAR(10) CONSTRAINT CK_Payment_PaymentStatus CHECK(PaymentStatus IN('Pending','Success','Failed','Cancelled')),
	CreatedAt DATETIME DEFAULT GETDATE(),
	ModifiedAt DATETIME
);

CREATE TABLE Tickets(
	TicketID  INT CONSTRAINT PK_TicketID PRIMARY KEY IDENTITY(1,1),
	PNRNo VARCHAR(10),
	PaymentID INT CONSTRAINT FK_Tickets_PaymentID FOREIGN KEY REFERENCES Payment,
	TicketStatus VARCHAR(15) DEFAULT 'Confirmed' CHECK(TicketStatus IN ('Confirmed','Cancelled'))
);


-- WHEN WE INSERT OR DELETE PASSANGER INTO FlightBookingLine THEN NoOfPassenger IN FlightBooking WILL BE UPDATED
GO
CREATE TRIGGER trg_updateFlightBookingDetail
ON FlightBookingLine
AFTER INSERT, DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @fID INT,@sid INT, @did INT, @count INT, @baseFare MONEY,@surgeCharge MONEY, @totalFare MONEY, @totalSurgeCharge MONEY, @totalAmount MONEY, @payableAmount MONEY, @discountPer INT, @discAmount MONEY, @travelInsurance BIT, @covidInsurance BIT, @totalInsurance MONEY;
	SET @fID = (SELECT  FlightBookingID FROM inserted 
				UNION ALL
				SELECT  FlightBookingID FROM deleted);

	SELECT @count = COUNT(*) FROM FlightBookingLine WHERE FlightBookingID = @fID;
	SELECT @sid = ScheduleID, @did = DiscountID, @travelInsurance = TravellInsurance, @covidInsurance = CovidInsurance FROM FlightBooking WHERE FlightBookingID = @fID;

	SELECT @baseFare = BaseFare, @surgeCharge = Surcharges FROM Schedule WHERE ScheduleID = @sid;

	IF @did IS NOT NULL
		SELECT @discountPer = DiscountPer  FROM Discount WHERE DiscountID = @did; 
	ELSE
		SET @discountPer = 0;

	SET @totalInsurance = 0;
	IF @travelInsurance = 1
		SELECT @totalInsurance += Charge FROM Insurance WHERE InsuranceName = 'Travel';

	IF @covidInsurance = 1
		SELECT @totalInsurance += Charge FROM Insurance WHERE InsuranceName = 'COVID19';


	SET @totalFare =  @baseFare * @count;
	SET @totalSurgeCharge =  @surgeCharge * @count;
	SET @totalAmount = @totalFare + @totalSurgeCharge + @totalInsurance;

	SET @discAmount = (@totalAmount *  @discountPer)/100.00;
	SET @payableAmount = @totalAmount - @discAmount;

	
	UPDATE FlightBooking
	SET NoOfPassenger = @count,
	TotalFare = @totalFare,
	TotalSurcharge = @totalSurgeCharge,
	TotalAmount = @totalFare + @totalSurgeCharge,
	PayableAmount = @payableAmount
	WHERE FlightBookingID = @fID;

END
GO


CREATE TRIGGER trg_updateSchedule
ON Schedule
AFTER INSERT,UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @sid INT, @fid INT, @baseFare MONEY, @surcharge MONEY,@availableSeats INT, @totalSeats INT;
	SELECT @sid = ScheduleID, @fid = FlightID, @baseFare = BaseFare, @surcharge = Surcharges, @availableSeats = AvailableSeats  FROM inserted;
	SELECT @totalSeats = TotalSeats FROM Flight WHERE FlightID = @fid;

	UPDATE Schedule
	SET Total = @baseFare + @surcharge,
	AvailableSeats = CASE  WHEN @availableSeats = 0 THEN @totalSeats ELSE AvailableSeats END
	WHERE ScheduleID = @sid
END
GO
/*

SELECT * FROM Country;
SELECT * FROM LoginInfo;
SELECT * FROM ProfileInfo;
SELECT * FROM Airline;
SELECT * FROM FlightCodes;
SELECT * FROM Location;
SELECT * FROM Flight;
SELECT * FROM Schedule;
SELECT * FROM TripTypes;
SELECT * FROM PassengerTypes;
SELECT * FROM TravelClasses;
SELECT * FROM Insurance;
SELECT * FROM Discount;
SELECT * FROM FlightBooking;
SELECT * FROM FlightBookingLine;
SELECT * FROM PaymentTypes;
SELECT * FROM Payment;
SELECT * FROM Tickets;

*/
--country
INSERT INTO Country(CountryName, CountryCode) VALUES
('India',91),
('Australia',61),
('Canada',1),
('China',86),
('Malaysia',60)

INSERT INTO LoginInfo(EmailAddress, Password, isAdmin) VALUES
('ankitrudani234@gmail.com','Ankit@1234',1),
('ankurrudani@gmail.com','Ankur@1234',0)

INSERT INTO ProfileInfo(UserID, FirstName, LastName, BirthDate, Gender, isTraveller) VALUES
(1,'Ankit','Rudani','01/06/1998','Male',0),
(1,'Mihan','Borad','07/09/2012','Male',1),
(2,'Ankur','Rudani','01/06/1998','Male',0),
(2,'dhairya','Sanghrajka','02/09/1998','Male',1)

INSERT INTO Airline(AirLineName, AirLineCode) VALUES
('Go First','G8'),
('Air India','AI'),
('IndiGO','6E'),
('SpiceJet','SG'),
('Finnair','AY')

INSERT INTO FlightCodes (AirLineID,FlightCode) VALUES
(1,234),
(1,245),
(1,564),
(2,654),
(2,644),
(2,754),
(3,888),
(4,987),
(5,12)

INSERT INTO Location(LocationName) VALUES
('Ahmedabad'),
('Delhi'),
('Mumbai'),
('Pune'),
('Hyderabad')

INSERT INTO Flight(FlightCodeID, SourceID, DestinationID, DepartureTime, ArrivalTime, Duration, TotalSeats) VALUES
(1,1,2,'10:15','12:30',135,50),
(2,1,3,'05:15','06:30',75,40),
(3,2,4,'15:00','16:00',60,30),
(4,2,5,'18:35','19:45',70,60),
(5,1,2,'02:15','04:15',120,30),
(6,2,1,'03:30','04:45',75,60),
(7,4,1,'10:45','12:30',105,50),
(8,5,2,'23:00','01:00',120,50),
(9,3,2,'12:15','02:00',105,50)


INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (1,'08/12/2022',4556,340)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (2,'08/12/2022',3456,234)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (3,'08/12/2022',9880,340)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (4,'08/12/2022',3450,893)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (5,'08/13/2022',6751,560)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (6,'08/13/2022',3411,760)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (7,'08/11/2022',8790,320)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (8,'08/11/2022',3400,660)
INSERT INTO Schedule(FlightID, DepartureDate, BaseFare, Surcharges) VALUES (9,'08/11/2022',5490,231)

INSERT INTO TripTypes (TripType) VALUES
('One Way'),
('Round Trip')

INSERT INTO PassengerTypes (PassengerType, AgeFrom, AgeUpto) VALUES
('Infants', 0, 2),
('Children', 2, 12),
('Adults', 12, 125)

INSERT INTO TravelClasses(TravelClass) VALUES
('Premium Economy'),
('Economy'),
('Business')


INSERT INTO Insurance VALUES
('Travel',249),
('COVID19',99)

INSERT INTO Discount(DiscountCode, DiscountPer, DiscountDiscription, StartDate, ExpriedDate) VALUES
('MMTDEALS',10,'Grab Up to Rs. 2000 OFF* on Domestic Flights.',GETDATE(), '12/31/2022'),
('FLYNOW',12,'Grab FLAT 12% OFF* on Domestic Flights with Citi Credit & Debit Cards.',GETDATE(), '12/31/2022'),
('MMTAU',12,'Grab FLAT 12% OFF* on Domestic Flights with AU Bank Credit & Debit Cards.',GETDATE(), '12/31/2022')

INSERT INTO FlightBooking(ScheduleID,TripTypeID, TravelClassID,TravellInsurance,CovidInsurance,DiscountID) VALUES(1,1,1,1,1,1);
INSERT INTO FlightBookingLine(FlightBookingID, ProfileID, PassengerTypeID, SeatNumber) VALUES (1,2,3,23)
INSERT INTO FlightBookingLine(FlightBookingID, ProfileID, PassengerTypeID, SeatNumber) VALUES (1,3,3,24)


INSERT INTO FlightBooking(ScheduleID,TripTypeID, TravelClassID,TravellInsurance,CovidInsurance,DiscountID) VALUES(2,1,1,0,0,NULL);
INSERT INTO FlightBookingLine(FlightBookingID, ProfileID, PassengerTypeID, SeatNumber) VALUES (2,3,3,12)
INSERT INTO FlightBookingLine(FlightBookingID, ProfileID, PassengerTypeID, SeatNumber) VALUES (2,4,3,13)

--DELETE FROM FlightBookingLine WHERE FlightBookingLineID = 2

--SELECT * FROM FlightBooking;
--SELECT * FROM FlightBookingLine;

INSERT INTO PaymentTypes(PaymentType) VALUES
('UPI'),
('Credit Card'),
('Debit Card'),
('Net Banking'),
('Wallet')

INSERT INTO Payment(FlightBookingID, PaymentTypeID) VALUES
(1,1),
(2,4)

INSERT INTO Tickets(PNRNo, PaymentID) VALUES
('PNR01234',1),
('PNR01235',2)