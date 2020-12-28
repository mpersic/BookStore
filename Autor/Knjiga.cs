using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    public class Knjiga
    {

        private int isbn;
        private string ime;
        private int godina;
        private int idSkladista;
        private int brojDostupnih;
        private int idIzdavaca;
        private int idAutora;

        public Knjiga(int isbn, string ime, int godina, int idSkladista, int idIzdavaca, int idAutora, int brojDostupnih)
        {
            this.isbn = isbn;
            this.ime = ime;
            this.godina = godina;
            this.idSkladista = idSkladista;
            this.idIzdavaca = idIzdavaca;
            this.idAutora = idAutora;
            this.brojDostupnih = brojDostupnih;
        }

        public int Isbn { get => isbn; set => isbn = value; }
        public string Ime { get => ime; set => ime = value; }
        public int Godina { get => godina; set => godina = value; }
        public int IdSkladista { get => idSkladista; set => idSkladista = value; }
        public int BrojDostupnih { get => brojDostupnih; set => brojDostupnih = value; }
        public int IdIzdavaca { get => idIzdavaca; set => idIzdavaca = value; }
        public int IdAutora { get => idAutora; set => idAutora = value; }
    }
}
