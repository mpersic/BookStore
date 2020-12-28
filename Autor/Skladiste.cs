using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    class Skladiste
    {

        private int iDSkladiste;
        private string adresa;

        public Skladiste(int iDSkladiste, string adresa)
        {
            this.iDSkladiste = iDSkladiste;
            this.adresa = adresa;
        }

        public string Adresa { get => adresa; set => adresa = value; }
        public int IDSkladiste { get => iDSkladiste; set => iDSkladiste = value; }
    }
}
