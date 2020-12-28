using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    public class Izdavac
    {
        private string ime;
        private string url;
        private string adresa;
        private int idIzdavaca;

        public Izdavac(string ime, string url, string adresa, int idIzdavaca)
        {
            this.ime = ime;
            this.url = url;
            this.adresa = adresa;
            this.idIzdavaca = idIzdavaca;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Url { get => url; set => url = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int IdIzdavaca { get => idIzdavaca; set => idIzdavaca = value; }
    }
}
