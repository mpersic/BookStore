using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Kupac
    {
        private int idKupca;
        private string adresa;
        private string brojMobitela;
        private string email;
        private string ime;

        public Kupac(int idKupca, string adresa, string brojMobitela, string email, string ime)
        {
            this.idKupca = idKupca;
            this.adresa = adresa;
            this.brojMobitela = brojMobitela;
            this.email = email;
            this.ime = ime;
        }

        public int IdKupca { get => idKupca; set => idKupca = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string BrojMobitela { get => brojMobitela; set => brojMobitela = value; }
        public string Email { get => email; set => email = value; }
        public string Ime { get => ime; set => ime = value; }
    }
}
