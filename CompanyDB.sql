CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO

CREATE TABLE DEPT (
    DeptID INT PRIMARY KEY IDENTITY(1,1),
    DeptName NVARCHAR(100) NOT NULL,
    ManagerID INT NULL  
);
GO

CREATE TABLE LOCATION (
    LocationID INT PRIMARY KEY IDENTITY(1,1),
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE EMP (
    EmpID INT PRIMARY KEY IDENTITY(1,1),
    EmpName NVARCHAR(100) NOT NULL,
    JobTitle NVARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    DeptID INT FOREIGN KEY REFERENCES DEPT(DeptID) ON DELETE SET NULL,
    LocationID INT FOREIGN KEY REFERENCES LOCATION(LocationID) ON DELETE SET NULL
);
GO

ALTER TABLE DEPT 
ADD CONSTRAINT FK_Manager FOREIGN KEY (ManagerID) REFERENCES EMP(EmpID) ON DELETE SET NULL;
GO

INSERT INTO LOCATION (City, State) VALUES
('New York', 'NY'),
('Los Angeles', 'CA'),
('Chicago', 'IL'),
('Houston', 'TX');
GO

INSERT INTO DEPT (DeptName) VALUES
('HR'),
('IT'),
('Finance'),
('Marketing');
GO

INSERT INTO EMP (EmpName, JobTitle, Salary, DeptID, LocationID) VALUES
('John Doe', 'HR Manager', 75000, 1, 1),
('Alice Smith', 'Software Engineer', 85000, 2, 2),
('Bob Johnson', 'Accountant', 72000, 3, 3),
('Emily White', 'Marketing Specialist', 68000, 4, 4),
('Michael Brown', 'IT Support', 65000, 2, 1),
('David Wilson', 'Finance Analyst', 79000, 3, 2);
GO

UPDATE DEPT SET ManagerID = 1 WHERE DeptName = 'HR';
UPDATE DEPT SET ManagerID = 2 WHERE DeptName = 'IT';
UPDATE DEPT SET ManagerID = 3 WHERE DeptName = 'Finance';
UPDATE DEPT SET ManagerID = 4 WHERE DeptName = 'Marketing';
GO

SELECT * FROM LOCATION;
SELECT * FROM DEPT;
SELECT * FROM EMP;
GO
