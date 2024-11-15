CREATE TABLE Users (
    user_id  INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    username VARCHAR(MAX) NULL,
    password VARCHAR(MAX) NULL,
);

SELECT * FROM Users;

INSERT INTO Users(username, password) VALUES('admin', 'admin123');

CREATE TABLE Employees (
    ID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    em_id char(5) NULL,
    status VARCHAR(15) NULL,
    name NVARCHAR(30) NULL,
    gender VARCHAR(10) NULL,
    phone CHAR(10) NULL,
    dob DATE NULL,
    address NVARCHAR(MAX) NULL,
    position NVARCHAR(20) NULL,
    salary DECIMAL(10, 2) DEFAULT 0,
    em_image VARCHAR(MAX) NULL,
    date_insert DATE NULL,
    date_update DATE NULL,
    date_delete DATE NULL,
);

SELECT * FROM Employees;