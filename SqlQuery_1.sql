--CREATE TABLE Autor (
--    ID NUMERIC PRIMARY KEY,
--    Ime NVARCHAR(30) NOT NULL,
--    AutorUrl NVARCHAR(50),
--    Adresa NVARCHAR(20) NOT NULL
--)
--
--CREATE TABLE Izdavac (
--    ID NUMERIC PRIMARY KEY,
--    Ime NVARCHAR(30) NOT NULL,
--    IzdavacUrl NVARCHAR(50),
--    Adresa NVARCHAR(20) NOT NULL
--)
--
--CREATE TABLE Skladiste (
--    IDSkladiste NUMERIC PRIMARY KEY,
--    Adresa NVARCHAR(20) NOT NULL
--)
--
--CREATE TABLE Kupac (
--    IDKupca NUMERIC PRIMARY KEY,
--    Adresa NVARCHAR(20) NOT NULL,
--    BrojMobitela NVARCHAR(15),
--    Email NVARCHAR(30) NOT NULL,
--    Ime NVARCHAR(30)NOT NULL
--)
--
--CREATE TABLE Kosarica (
--    IDKosarice NUMERIC PRIMARY KEY,
--    IDKupca NUMERIC FOREIGN KEY REFERENCES Kupac(IDKupca) NOT NULL
--)
--
--CREATE TABLE Knjiga (
--    ISBN NUMERIC PRIMARY KEY,
--    Ime NVARCHAR(30) NOT NULL,
--    BrojDostupnih NUMERIC,
--    Godina NUMERIC NOT NULL,
--    IDSkladista NUMERIC FOREIGN KEY REFERENCES Skladiste(IDSkladiste) NOT NULL,
--    IDIzdavaca NUMERIC FOREIGN KEY REFERENCES Izdavac(ID) NOT NULL,
--    IDAutora NUMERIC FOREIGN KEY REFERENCES Autor(ID) NOT NULL
--)
--
--CREATE TABLE SeNalazi(
--    IDKosarice NUMERIC FOREIGN KEY REFERENCES Kosarica(IDKosarice) NOT NULL,
--    ISBN NUMERIC FOREIGN KEY REFERENCES Knjiga(ISBN) NOT NULL
--)



--CREATE PROCEDURE CreateBook @ISBN NUMERIC, @Ime NVARCHAR(30), @BrojDostupnih NUMERIC, @Godina NUMERIC, @IDSkladista NUMERIC, @IDIzdavaca NUMERIC, @IDAutora NUMERIC
--AS
--INSERT INTO Knjiga(ISBN, Ime, BrojDostupnih, Godina, IDSkladista, IDIzdavaca, IDAutora) VALUES(@isbn, @ime, @brojDostupnih, @godina, @idSkladista, @idIzdavaca, @idAutora)

--CREATE PROCEDURE CreateAutor @ID NUMERIC, @Ime NVARCHAR(30), @AutorUrl NVARCHAR(50), @Adresa NVARCHAR(20)
--AS
--INSERT INTO Autor(ID, Ime, AutorUrl, Adresa) VALUES(@ID, @Ime, @AutorUrl, @Adresa)

--CREATE PROCEDURE CreateIzdavac @ID NUMERIC, @Ime NVARCHAR(30), @IzdavacUrl NVARCHAR(50), @Adresa NVARCHAR(20)
--AS
--INSERT INTO Izdavac(ID, Ime, IzdavacUrl, Adresa) VALUES(@ID, @Ime, @IzdavacUrl, @Adresa)

--CREATE FUNCTION CountDifferentBooks(@IDSkladiste NUMERIC)  
--RETURNS INT   
--AS   
--BEGIN  
--    DECLARE @ret int;  
--
--    SELECT @ret = COUNT(*) FROM Knjiga,Skladiste WHERE @IDSkladiste = Knjiga.IDSkladista AND Skladiste.IDSkladiste = @IDSkladiste
--
--    RETURN @ret
--END; 


CREATE FUNCTION CountAuthorBooks(@AutorID NUMERIC)  
RETURNS INT   
AS   
BEGIN  
    DECLARE @ret int;  

    SELECT @ret = COUNT(*) FROM Autor,Knjiga WHERE @AutorID = Autor.ID AND Knjiga.IDAutora = @AutorID

    RETURN @ret
END; 



--DROP TABLE Autor
--DROP TABLE Izdavac
--DROP TABLE Knjiga
--DROP TABLE Kosarica
--DROP TABLE Kupac
--DROP TABLE SeNalazi
--DROP TABLE Skladiste