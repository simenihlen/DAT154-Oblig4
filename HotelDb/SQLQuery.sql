--Dette kommer opp p� localdb\MSSQLLocalDB
--Kj�r denne f�rst f�r du kj�rer resten
DROP DATABASE IF EXISTS HotelDb;
CREATE DATABASE HotelDb;

--Husk � kj�r SQL filen p� riktig server!
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