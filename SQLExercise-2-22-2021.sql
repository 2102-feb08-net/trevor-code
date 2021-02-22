CREATE SCHEMA SQLExercise;

CREATE TABLE SQLExercise.Products (
	ID INT IDENTITY(1,1),
	Name NVARCHAR(100),
	Price MONEY,
	PRIMARY KEY (ID)
);

CREATE TABLE SQLExercise.Customers (
	ID INT IDENTITY(1,1),
	FirstName NVARCHAR(100),
	LastName NVARCHAR(100),
	CardNumber NCHAR(16),
	PRIMARY KEY (ID)
);

CREATE TABLE SQLExercise.Orders (
	ID INT IDENTITY(1,1),
	ProductID INT NOT NULL,
	CustomerID INT NOT NULL
	PRIMARY KEY (ID),
	FOREIGN KEY (ProductID) REFERENCES SQLExercise.Products(ID),
	FOREIGN KEY (CustomerID) REFERENCES SQLExercise.Customers(ID)
);


-- 1
INSERT INTO SQLExercise.Products (Name, Price) VALUES('Apple', 0.5);
INSERT INTO SQLExercise.Products (Name, Price) VALUES('Cereal', 3.5);
INSERT INTO SQLExercise.Products (Name, Price) VALUES('Milk', 4);

INSERT INTO SQLExercise.Customers (FirstName, LastName, CardNumber) VALUES('Trevor', 'Dunbar', '1234567890123456');
INSERT INTO SQLExercise.Customers (FirstName, LastName, CardNumber) VALUES('John', 'Doe', '9876543212345678');
INSERT INTO SQLExercise.Customers (FirstName, LastName, CardNumber) VALUES('Kelly', 'Smith', '5555444466665555');

INSERT INTO SQLExercise.Orders (ProductID, CustomerID) VALUES (1, 1);
INSERT INTO SQLExercise.Orders (ProductID, CustomerID) VALUES (2, 2);
INSERT INTO SQLExercise.Orders (ProductID, CustomerID) VALUES (3, 3);

-- 2
INSERT INTO SQLExercise.Products (Name, Price) VALUES ('iPhone', 200);

--3
INSERT INTO SQLExercise.Customers (FirstName, LastName) VALUES ('Tina', 'Smith');

--4
INSERT INTO SQLExercise.Orders (ProductID, CustomerID) VALUES (4, 4);

--5
SELECT FirstName, Name FROM SQLExercise.Customers
INNER JOIN SQLExercise.Orders ON Customers.ID = Orders.CustomerID
	INNER JOIN SQLExercise.Products ON Orders.ProductID = Products.ID
WHERE Customers.FirstName = 'Tina' AND Customers.LastName = 'Smith';

--6
SELECT Name, SUM(Price) FROM SQLExercise.Products
INNER JOIN SQLExercise.Orders ON Products.ID = SQLExercise.Orders.ProductID
WHERE Products.Name = 'iPhone'
GROUP BY Name;

--7
UPDATE SQLExercise.Products
SET Price = 250
WHERE Name = 'iPhone';