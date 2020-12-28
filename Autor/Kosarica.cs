using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    public class Kosarica
    {
        private int idKosarice;
        private int idKupca;

        public Kosarica(int idKosarice, int idKupca)
        {
            this.idKosarice = idKosarice;
            this.idKupca = idKupca;
        }

        public int IdKosarice { get => idKosarice; set => idKosarice = value; }
        public int IdKupca { get => idKupca; set => idKupca = value; }
    }
}
