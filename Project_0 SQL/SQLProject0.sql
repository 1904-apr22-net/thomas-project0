CREATE DATABASE Project0;

GO
CREATE SCHEMA Cigar;
GO

CREATE TABLE Cigar.Cigar(
	Id INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_CigarId PRIMARY KEY (Id),
	);

CREATE TABLE Cigar.Manufacturer(
	Id INT NOT NULL IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_ManufacturerId PRIMARY KEY (Id),
	);

ALTER TABLE Cigar.Cigar ADD
	ManufacturerId INT NOT NULL DEFAULT(1),
	CONSTRAINT FK_Cigar_Manufacturer FOREIGN KEY (ManufacturerId) REFERENCES Cigar.Manufacturer (Id);

ALTER TABLE Cigar.Manufacturer ADD
	Location NVARCHAR(100) NOT NULL DEFAULT('unknown');

SELECT *
FROM Cigar.Cigar

CREATE TABLE Cigar.CigarBodyChar(
	Id INT NOT NULL IDENTITY,
	Body NVARCHAR(200) NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_CigarBodyChar PRIMARY KEY (Id),
	);

ALTER TABLE Cigar.Cigar ADD
	BodyId INT NOT NULL DEFAULT(0),
	CONSTRAINT FK_Cigar_CigarBodyChar FOREIGN KEY (BodyId) REFERENCES Cigar.CigarBodyChar (Id);

CREATE TABLE Cigar.Customer(
	Id INT NOT NULL IDENTITY,
	FirstName NVARCHAR(200) NOT NULL,
	LastName NVARCHAR(200) NOT NULL,
	Address1 NVARCHAR(200) NOT NULL,
	Address2 NVARCHAR(200) NOT NULL,
	City NVARCHAR(200) NOT NULL,
	State NVARCHAR(200) NOT NULL,
	ZipCode NVARCHAR(200) NOT NULL,
	DefaultStore NVARCHAR(200) NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Customer PRIMARY KEY (Id),
	);

CREATE TABLE Cigar.Store(
	Id INT NOT NULL IDENTITY,
	Address1 NVARCHAR(200) NOT NULL,
	Address2 NVARCHAR(200) NOT NULL,
	City NVARCHAR(200) NOT NULL,
	State NVARCHAR(200) NOT NULL,
	ZipCode NVARCHAR(200) NOT NULL,
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Store PRIMARY KEY (Id),
	);
CREATE TABLE Cigar.Orders(
	Id INT NOT NULL IDENTITY,
	OrderTotal MONEY NOT NULL DEFAULT(0),
	DatePlaced DATETIME2 NOT NULL DEFAULT (GETDATE()),
	DateModified DATETIME2 NOT NULL DEFAULT(GETDATE()),
	Active BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Orders PRIMARY KEY (Id),
	);

ALTER TABLE Cigar.Orders ADD
	CustomerId INT NOT NULL DEFAULT(0),
	CONSTRAINT FK_Orders_Customer FOREIGN KEY (CustomerId) REFERENCES Cigar.Customer (Id);

	
ALTER TABLE Cigar.Customer ADD
	CONSTRAINT FK_Customer_Store FOREIGN KEY (DefaultStoreId) REFERENCES Cigar.Store (Id);

CREATE TABLE Cigar.OrderItems(
Quantity INT not null DEFAULT(1),
OrderId INT,
ProductId INT,
CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Cigar.Orders (Id),
CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductId) REFERENCES Cigar.Cigar (Id)
)

CREATE TABLE Cigar.InvintoryItem(
Quantity INT not null DEFAULT(1),
StoreId INT,
ProductId INT,
CONSTRAINT FK_InvintoryItems_Store FOREIGN KEY (StoreId) REFERENCES Cigar.Store (Id),
CONSTRAINT FK_InvintoryItems_Products FOREIGN KEY (ProductId) REFERENCES Cigar.Cigar (Id)
)

GO
CREATE TRIGGER Cigar.CigarDateModified ON Cigar.Cigar
AFTER UPDATE
AS
BEGIN
	UPDATE Cigar.Cigar
	SET DateModified = GETDATE()
	WHERE Id IN (SELECT Id FROM Inserted);
END

GO
CREATE TRIGGER Cigar.CustomerDateModified ON Cigar.Customer
AFTER UPDATE
AS
BEGIN
	UPDATE Cigar.Customer
	SET DateModified = GETDATE()
	WHERE Id IN (SELECT Id FROM Inserted);
END

GO
CREATE TRIGGER Cigar.ManufacturerDateModified ON Cigar.Manufacturer
AFTER UPDATE
AS
BEGIN
	UPDATE Cigar.Manufacturer
	SET DateModified = GETDATE()
	WHERE Id IN (SELECT Id FROM Inserted);
END

GO
CREATE TRIGGER Cigar.OrdersDateModified ON Cigar.Orders
AFTER UPDATE
AS
BEGIN
	UPDATE Cigar.Orders
	SET DateModified = GETDATE()
	WHERE Id IN (SELECT Id FROM Inserted);
END

GO
CREATE TRIGGER Cigar.StoreDateModified ON Cigar.Store
AFTER UPDATE
AS
BEGIN
	UPDATE Cigar.Store
	SET DateModified = GETDATE()
	WHERE Id IN (SELECT Id FROM Inserted);
END


INSERT INTO Cigar.Manufacturer (Name) VALUES
('Drew Estates'),
('Arturo Fuente'),
('Romeo y Julieta'),
('Macanudo'),
('AJ Fernandez'),
('My Father'),
('Camacho')

INSERT INTO Cigar.CigarBodyChar (Body) VALUES
('Mild'),
('Medium'),
('Full')

INSERT INTO Cigar.Cigar (Name, ManufacturerId, BodyId) VALUES
('Liga Privada No 9', 1, 3),
('Liga Privada T 52', 1, 3),
('Undrcrown Sun Grown', 1, 3),
('Undrcrown Maduro', 1, 3),
('Undrcrown Shade', 1, 1),
('858 Maduro', 2, 3),
('858 Natural', 2, 2),
('Gran Reserva', 2, 2),
('Romeo Anejo', 3, 3),
('1875', 3, 2),
('Reserva Real', 3, 2),
('Cafe', 4, 1),
('M', 4, 2),
('New World', 5, 3 ),
('Bellas Artes', 5, 2),
('Last Call', 5, 2),
('El Centurion', 6, 3),
('Jaime Garcia', 6, 2),
('The Judge', 6, 3),
('Triple Maduro', 7, 3),
('Connecticut', 7, 1),
('American Barrel Aged', 7, 2)

INSERT INTO Cigar.Store (Address1, Address2, City, State, ZipCode) VALUES
('123 Lazier Ln', 'Bldg 3A', 'Made Up', 'Texas', 76123),
('321 In a Crunch St', 'Bldg 5B', 'Desert', 'Arizona', 12345)

INSERT INTO Cigar.Customer (FirstName, LastName, Address1, Address2, City, State, ZipCode, DefaultStore, DefaultStoreId) VALUES
('John', 'Smith', '123 Lazy Ln','', 'Made Up', 'Texas', 76123, 'Winston Churchill Cigars', 1),
('Jane', 'Doe', '987 No Grass Ct','', 'Desert', 'Arizona', 12345, 'Winston Churchill Cigars', 2),
('Bobby', 'Quicktruck', '345 Weather Forcast Joke Dr','', 'Made Up', 'Texas', 76123, 'Winston Churchill Cigars', 1),
('Duke', 'Zeppelin', '789 Also No Water St','', 'Desert', 'Arizona', 12345, 'Winston Churchill Cigars', 2)

select * 
FROM Cigar.Customer

SELECT Cigar.Id, Cigar.Name, CigarBodyChar.Body, Manufacturer.Name
FROM Cigar.Cigar 
INNER Join Cigar.CigarBodyChar on Cigar.Cigar.BodyId = CigarBodyChar.Id
INNER Join Cigar.Manufacturer on Cigar.Cigar.ManufacturerId = Manufacturer.Id
WHERE Cigar.Name = 'm'

SELECT * FROM Cigar.Customer WHERE FirstName = 'John' AND LastName = 'Smith';
SELECT * FROM Cigar.Store WHERE Store.Id = 3