--Dette kommer opp på localdb\MSSQLLocalDB
--Kjør denne først før du kjører resten
--DROP DATABASE IF EXISTS HotelDb;
--CREATE DATABASE HotelDb;
--Scaffold doc: https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=vs
--Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

--Husk å kjør SQL filen på riktig server!
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS prices;
DROP TABLE IF EXISTS roomdata;
DROP TABLE IF EXISTS bookingdata;

--Users
CREATE TABLE users (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	firstname VARCHAR(50) NOT NULL,
	lastname VARCHAR(50) NOT NULL,
	phone INT
);
--Tabell for prices
CREATE TABLE prices (
	quality VARCHAR(50) NOT NULL PRIMARY KEY,
	price INT NOT NULL
);

--Data for rooms
CREATE TABLE roomdata (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	quality VARCHAR(50) NOT NULL,
	beds int NOT NULL,
	FOREIGN KEY (quality) REFERENCES prices (quality) ON DELETE NO ACTION ON UPDATE CASCADE
);

--Data for Booking
CREATE TABLE bookingdata (
	id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	roomid int NOT NULL,
	startdate DATETIME NOT NULL,
	enddate DATETIME NOT NULL,
	guests int NOT NULL,
	userid int NOT NULL,
	FOREIGN KEY (roomid) REFERENCES roomdata (id) ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY (userid) REFERENCES users (id) ON DELETE NO ACTION ON UPDATE CASCADE
);