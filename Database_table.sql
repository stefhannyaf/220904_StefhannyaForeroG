CREATE database DB_PHOTOEXPRESS

USE DB_PHOTOEXPRESS

CREATE TABLE INSTITUTE(
	Id int primary key identity(1,1),
	Institute_name varchar(100),
	Institute_address varchar(100),
	Students_Number int,
	Time_service int,
	Price int
)
