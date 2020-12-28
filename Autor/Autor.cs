using System;

namespace Objekti
{
    public class Autor
    {

        private string ime;
        private string url;
        private string adresa;

        public Autor(string ime, string url, string adresa)
        {
            this.ime = ime;
            this.url = url;
            this.adresa = adresa;
        }

        public Autor() { }

        public string Ime { get => ime; set => ime = value; }
        public string Url { get => url; set => url = value; }
        public string Adresa { get => adresa; set => adresa = value; }
    }
}
