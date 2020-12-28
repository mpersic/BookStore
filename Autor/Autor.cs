using System;

namespace Objekti
{
    public class Autor
    {

        private string ime;
        private string url;
        private string adresa;
        private int idAutora;

        public Autor(string ime, string url, string adresa,int idAutora)
        {
            this.ime = ime;
            this.url = url;
            this.adresa = adresa;
            this.idAutora = idAutora;
        }

        public Autor() { }

        public string Ime { get => ime; set => ime = value; }
        public string Url { get => url; set => url = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public int IdAutora { get => idAutora; set => idAutora = value; }
    }
}
