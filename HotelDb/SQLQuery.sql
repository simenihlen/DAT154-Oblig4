--Dette kommer opp på localdb\MSSQLLocalDB
--Kjør denne først før du kjører resten
DROP DATABASE IF EXISTS HotelDb;
CREATE DATABASE HotelDb;

--Husk å kjør SQL filen på riktig server!
DROP TABLE IF EXISTS priser;

--TODO
--Users

--Employee

--Bookingrooms

--Tabell for prices
CREATE TABLE prices (
	quality VARCHAR(50) NOT NULL PRIMARY KEY,
	price INT NOT NULL
);