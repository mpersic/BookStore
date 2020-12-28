using System;
using Objekti;
using Session;
using System.Collections.Generic;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {

            Posrednik p = new Posrednik();

            while (true) {

                Console.WriteLine("Dobrodošli u online knjižaru!\n\nJeste li korisnik? (D/N)\n  Odaberite X za izlaz. (X)");
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
                    string izbornik = "Izbornik:\n     -Prikaži košaricu (K)\n     -Dodaj u košaricu (D)\n     -Filter (F)\n     -Odjava (O)\n     -Izađi iz programa (X)\n";
                    string filter = "Filter:\n     -Ime knjige (K)\n     -Ime autora (A)\n     -Ime izdavača (I)\n     -Godina izadnja (G)\n     -Za višestruki izbor unesite kombinaciju slova (npr. K A I )\n     -Izađi iz filtera (X)\n";

                    Console.WriteLine(izbornik);
                    string response = Console.ReadLine();
                    while (true)
                    {
                        if (response == "K")
                        {
                            Console.WriteLine("Košarica:\n");
                            // Uzet knjige od kosarice i ispisati
                            Console.WriteLine("Ukloni iz košarice (U)\n");
                            string response = Console.ReadLine();
                            if (response == "D")
                            {
                                // 
                            }
                            else {
                                Console.WriteLine(izbornik);
                            }
                        }

                        if (response == "U")
                        {
                            // Ukloni knjigu na rednom broju ispisa 
                        }

                        if (response == "F")
                        {
                            Console.WriteLine(filter);
                            response = Console.ReadLine();

                            if (response.Contains(" K ")) 
                            { 
                                Console.WriteLine("Ime knjige: \n");
                            }

                            if (response.Contains(" A "))
                            {
                                Console.WriteLine("Ima autora: \n");
                            }

                            if (response.Contains("I"))
                            {
                                Console.WriteLine("Ime izdavača: \n");
                            }

                            if (response.Contains("G"))
                            {
                                Console.WriteLine("Godina izdanja: \n");
                            }

                            if (response == "X") { break; }
                        }

                        if (response == "O") { break; }
                        if (response == "X") { return; }
                    }
                }
                if (isUser == "N")
                {
                   
                }

                p.InsertAutor(new Autor("Stjepan", "URLnn", "Osijek1", 11023));
                p.InsertAutor(new Autor("Stjepan", "URLn", "Osijek3", 203));
                p.InsertAutor(new Autor("Stjepann", "URLn", "Osijek3", 30));
                p.InsertAutor(new Autor("Stjepann", "URLn", "Osijek4", 10232));

                Autor autor = new Autor();
                autor.Ime = "Stjepann";
                List<Autor> autors = p.SelectAutor(autor, 1);

                foreach (Autor a in autors)
                {
                    System.Console.WriteLine(a.Ime + " " + a.Url + " " + a.Adresa + " " + a.IdAutora);
                }

                //p.InsertIzdavac(new Izdavac("Alfa", "URL", "Zagreb", 2));
                //p.InsertSkladiste(new Skladiste(70, "Velka Gorca"));
                //p.InsertKnjiga(new Knjiga(287, "LOTR", 2013, 70, 2, 9, 1));
                // p.InsertSeNalazi(new SeNalazi(287,5));
                //foreach (Autor element in listaAutora)
                //{
                //    Console.WriteLine(element.Ime);
                //}
            }
        }
    }
}
