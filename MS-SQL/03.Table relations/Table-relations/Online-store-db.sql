CREATE DATABASE OnlineStore

CREATE TABLE Orders
(
	OrderID INT IDENTITY PRIMARY KEY NOT NULL,
	CustomerID INT NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATETIME2,
	CityID INT NOT NULL
)

CREATE TABLE Cities
(
	CityID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50)
)

CREATE TABLE OrderItems
(
	OrderID INT NOT NULL,
	ItemID INT NOT NULL
)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)

ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities (CityID)

ALTER TABLE Items
ADD CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes (ItemTypeID)

ALTER TABLE OrderItems
ADD CONSTRAINT PKC_OrderItems PRIMARY KEY (OrderID, ItemID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders (OrderID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items (ItemID)