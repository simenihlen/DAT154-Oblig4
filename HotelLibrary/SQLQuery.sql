--Dette kommer opp på localdb\MSSQLLocalDB
--Kjør denne først før du kjører resten

--DROP DATABASE IF EXISTS HotelDb;
--CREATE DATABASE HotelDb;

--Scaffold doc: https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=vs
--Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

--Husk å kjør SQL filen på riktig server!
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS roomdata;
DROP TABLE IF EXISTS bookingdata;

--Users
CREATE TABLE users (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	username VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	phone VARCHAR(50) NOT NULL,
	role VARCHAR(50) DEFAULT 'guest'
);

--Data for rooms
CREATE TABLE roomdata (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	room_number int NOT NULL,
	number_of_beds int NOT NULL,
	room_size int NOT NULL,
	room_quality VARCHAR(50) NOT NULL
);

--Data for Booking
CREATE TABLE bookingdata (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	roomid int NOT NULL,
	userid int NOT NULL,
	startdate DATETIME NOT NULL,
	enddate DATETIME NOT NULL,
	antallPersoner int NOT NULL,
	FOREIGN KEY (roomid) REFERENCES roomdata (id) ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY (userid) REFERENCES users (id) ON DELETE NO ACTION ON UPDATE CASCADE
);