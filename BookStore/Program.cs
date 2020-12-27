using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dobrodošli u online knjižaru!\n\nJeste li korisnik? (D/N)");
            string isUser = Console.ReadLine();

            if (isUser == "D")
            {
                Console.WriteLine("IdKupca: ");
                //učitavanje
                Console.WriteLine("\nAdresa: ");
                //
                Console.WriteLine("\nBroj mobitela: ");
                //
                Console.WriteLine("\nEmail: ");
                //
                Console.WriteLine("\nIme i prezime: ");
                //
                string izbornik = "Izbornik:\n     -Prikaži košaricu (K)\n     -Dodaj u košaricu (D)\n     -Ukloni iz košarice (U)\n     -Prikaži sve knjige (P)\n     -Filter (F)\n     -Izađi iz programa (X)\n";
                string filter = "Filter:\n     -Ime knjige (K)\n     -Ime autora (A)\n     -Ime izdavača (I)\n     -Godina izadnja (G)\n     -Izađi iz programa (X)\n";

                Console.WriteLine(izbornik);
                string response = Console.ReadLine();
                while (true)
                {
                    if (response == "K") { }
                    if (response == "D") { }
                    if (response == "U") { }
                    if (response == "P") { }
                    if (response == "F")
                    {
                        Console.WriteLine(filter);
                        response = Console.ReadLine();
                        if (response == "K") ;
                        if (response == "A") ;
                        if (response == "I") ;
                        if (response == "G") ;
                        if (response == "X") ;
                    }
                    if (response == "X") { }
                }
            }
            if (isUser == "N") { }
        }
    }
}
