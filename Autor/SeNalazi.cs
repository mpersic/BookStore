using System;
using System.Collections.Generic;
using System.Text;

namespace Objekti
{
    class SeNalazi
    {
        private int isbn;
        private int idKosarice;

        public SeNalazi(int isbn, int idKosarice)
        {
            this.isbn = isbn;
            this.idKosarice = idKosarice;
        }

        public int IdKosarice { get => idKosarice; set => idKosarice = value; }
        public int Isbn { get => isbn; set => isbn = value; }
    }
}
