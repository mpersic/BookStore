using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    public class Knjiga
    {
        //ISBN INT PRIMARY KEY,
        // Ime VARCHAR(30),
        //Godina INT,
        //ImeIzdavaca VARCHAR(30),
        // ImeAutora VARCHAR(30),
        //IDSkladista INT FOREIGN KEY REFERENCES Skladiste(IDSkladiste),
        //IDIzdavaca VARCHAR(30) FOREIGN KEY REFERENCES Izdavac(Ime),
        // IDAutora VARCHAR(30) FOREIGN KEY REFERENCES Autor(Ime)

        private int isbn;
        private string ime;
        private int godina;
        private string imeIzdavaca;
        private string imeAutora;
        private int idSkladista;
        private string idIzdavaca;
        private string idAutora;

        public Knjiga(int isbn, string ime, int godina, string imeIzdavaca, string imeAutora, int idSkladista, string idIzdavaca, string idAutora)
        {
            this.isbn = isbn;
            this.ime = ime;
            this.godina = godina;
            this.imeIzdavaca = imeIzdavaca;
            this.imeAutora = imeAutora;
            this.idSkladista = idSkladista;
            this.idIzdavaca = idIzdavaca;
            this.idAutora = idAutora;
        }

        public int Isbn { get => isbn; set => isbn = value; }
        public string Ime { get => ime; set => ime = value; }
        public int Godina { get => godina; set => godina = value; }
        public string ImeIzdavaca { get => imeIzdavaca; set => imeIzdavaca = value; }
        public string ImeAutora { get => imeAutora; set => imeAutora = value; }
        public int IdSkladista { get => idSkladista; set => idSkladista = value; }
        public string IdIzdavaca { get => idIzdavaca; set => idIzdavaca = value; }
        public string IdAutora { get => idAutora; set => idAutora = value; }
    }
}
