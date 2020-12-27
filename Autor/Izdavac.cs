using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Izdavac
    {
        private string ime;
        private string url;
        private string adresa;

        public Izdavac(string ime, string url, string adresa)
        {
            this.ime = ime;
            this.url = url;
            this.adresa = adresa;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Url { get => url; set => url = value; }
        public string Adresa { get => adresa; set => adresa = value; }
    }
}
