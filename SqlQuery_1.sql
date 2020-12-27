CREATE TABLE Autor (
    Ime VARCHAR(30) PRIMARY KEY,
    AutorUrl VARCHAR(14),
    Adresa VARCHAR(13)
)

CREATE TABLE Izdavac (
    Ime VARCHAR(30) PRIMARY KEY,
    IzdavacUrl VARCHAR(14),
    Adresa VARCHAR(13)
)

CREATE TABLE Skladiste (
    IDSkladiste INT PRIMARY KEY,
    Adresa VARCHAR(13)
)

CREATE TABLE Kupac (
    IDKupca INT PRIMARY KEY,
    Adresa VARCHAR(13),
    BrojMobitela VARCHAR(15),
    Email VARCHAR(15),
    Ime VARCHAR(30)
)

CREATE TABLE Kosarica (
    IDKosarice INT PRIMARY KEY,
    IDKupca INT FOREIGN KEY REFERENCES Kupac(IDKupca)
)

CREATE TABLE Knjiga (
    ISBN INT PRIMARY KEY,
    Ime VARCHAR(30),
    Godina INT,
    ImeIzdavaca VARCHAR(30),
    ImeAutora VARCHAR(30),
    IDSkladista INT FOREIGN KEY REFERENCES Skladiste(IDSkladiste),
    IDIzdavaca VARCHAR(30) FOREIGN KEY REFERENCES Izdavac(Ime),
    IDAutora VARCHAR(30) FOREIGN KEY REFERENCES Autor(Ime)
)

CREATE TABLE SeNalazi(
    IDKosarice INT FOREIGN KEY REFERENCES Kosarica(IDKosarice),
    ISBN INT FOREIGN KEY REFERENCES Knjiga(ISBN)
)



--DROP TABLE Autor
--DROP TABLE Izdavac
--DROP TABLE Knjiga
--DROP TABLE Kosarica
--DROP TABLE Kupac
--DROP TABLE SeNalazi
--DROP TABLE Skladiste