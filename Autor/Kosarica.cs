using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    public class Kosarica
    {
        private List<Knjiga> knjige;
        private int idKosarice;
        private int idKupca;

        public Kosarica(int idKosarice, int idKupca)
        {
            this.idKosarice = idKosarice;
            this.idKupca = idKupca;
            knjige = new List<Knjiga>();
        }

        public void DodajKnjige(List<Knjiga> knjiges)
        {
            foreach(Knjiga obj in knjiges)
            {
                DodajKnjigu(obj);
            }
        }
        public void DodajKnjigu(Knjiga knjiga)
        {
            knjige.Add(knjiga);
        }
        public int IdKosarice { get => idKosarice; set => idKosarice = value; }
        public int IdKupca { get => idKupca; set => idKupca = value; }
    }
}
