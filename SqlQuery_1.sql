--CREATE TABLE Autor (
--    ID INT PRIMARY KEY,
--    Ime VARCHAR(30) NOT NULL,
--    AutorUrl VARCHAR(50),
--    Adresa VARCHAR(20) NOT NULL
--)

--CREATE TABLE Izdavac (
--    ID INT PRIMARY KEY,
--    Ime VARCHAR(30) NOT NULL,
--    IzdavacUrl VARCHAR(50),
--    Adresa VARCHAR(20) NOT NULL
--)

--CREATE TABLE Skladiste (
--    IDSkladiste INT PRIMARY KEY,
--    Adresa VARCHAR(20) NOT NULL
--)

--CREATE TABLE Kupac (
--    IDKupca INT PRIMARY KEY,
--    Adresa VARCHAR(20),
--    BrojMobitela VARCHAR(15),
--    Email VARCHAR(30) NOT NULL,
--    Ime VARCHAR(30)NOT NULL
--)

--CREATE TABLE Kosarica (
--    IDKosarice INT PRIMARY KEY,
--    IDKupca INT FOREIGN KEY REFERENCES Kupac(IDKupca) NOT NULL
--)

--CREATE TABLE Knjiga (
--    ISBN INT PRIMARY KEY,
--    Ime VARCHAR(30) NOT NULL,
--    BrojDostupnih INT,
--    Godina INT NOT NULL,
--    IDSkladista INT FOREIGN KEY REFERENCES Skladiste(IDSkladiste) NOT NULL,
--    IDIzdavaca INT FOREIGN KEY REFERENCES Izdavac(ID) NOT NULL,
--    IDAutora INT FOREIGN KEY REFERENCES Autor(ID) NOT NULL
--)

--CREATE TABLE SeNalazi(
--    IDKosarice INT FOREIGN KEY REFERENCES Kosarica(IDKosarice) NOT NULL,
--    ISBN INT FOREIGN KEY REFERENCES Knjiga(ISBN) NOT NULL
--)
--DROP TABLE Autor
--DROP TABLE Izdavac
--DROP TABLE Knjiga
--DROP TABLE Kosarica
--DROP TABLE Kupac
--DROP TABLE SeNalazi
--DROP TABLE Skladiste