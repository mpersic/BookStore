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
            //setInitialValues();


            List<string> mainMenu = new List<string>();
            mainMenu.Add("Odaberite radnju :");
            mainMenu.Add("(1) Unesi u bazu");
            mainMenu.Add("(2) Obrisi iz baze");
            mainMenu.Add("(3) Ispisi iz baze");
            mainMenu.Add("(4) Ubaci u kosaricu");
            mainMenu.Add("(5) Ispisi knjige autora");
            mainMenu.Add("(6) Ispisi sve autore sa knjigama u zadanom skladistu");
            mainMenu.Add("(7) Ispisi broj knjiga na skladistu");
            mainMenu.Add("(8) Ispisi broj knjiga zadanog autora");
            mainMenu.Add("(9) Izađi iz programa");

            string submenu1title = "Odaberite gdje unijeti :";
            string submenu2title = "Odaberite gdje obrisati :";
            string submenu3title = "Odaberite sto ispisati :";
            string submenu4title = "Unesite podatke (IDKupca, IDKosarice, ISBN) :";

            List<string> names = new List<string>();
            names.Add("(1) Autor");
            names.Add("(2) Izdavac");
            names.Add("(3) Knjiga");
            names.Add("(4) Kosarica");
            names.Add("(5) Kupac");
            names.Add("(6) SeNalazi");
            names.Add("(7) Skladiste");
            names.Add("(9) Izađi iz izbornika");



            Console.WriteLine("Dobrodošli u online knjižaru!\n");

            bool run = true;
            while (run)
            {
                Console.WriteLine();
                printMenu(mainMenu);
                int option = readCorrectInput(1, mainMenu.Count - 2);

                int IDKupca;
                int IDKosarice;
                int ISBN;
                int ID;
                int choice;
                switch (option)
                {
                    case 1:
                        // Insert into database
                        Console.WriteLine(submenu1title);
                        printMenu(names);
                        choice = readCorrectInput(1, names.Count);

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Unesite podatke (ID, ime, URL, adresa)");
                                int authorIDd = Int32.Parse(Console.ReadLine());
                                string authorIme = Console.ReadLine();
                                string authorURL = Console.ReadLine();
                                string authorAdresa = Console.ReadLine();

                                p.InsertAutor(new Autor(authorIme, authorURL, authorAdresa, authorIDd));

                                break;
                            case 2:
                                Console.WriteLine("Unesite podatke (ID, ime, URL, adresa)");

                                int izdavacID = Int32.Parse(Console.ReadLine());
                                string izdavacIme = Console.ReadLine();
                                string izdavacURL = Console.ReadLine();
                                string izdavacAdresa = Console.ReadLine();

                                p.InsertIzdavac(new Izdavac(izdavacIme, izdavacURL, izdavacAdresa, izdavacID));

                                break;
                            case 7:

                                Console.WriteLine("Unesite podatke (ID, adresa)");

                                int skladisteID = Int32.Parse(Console.ReadLine());
                                string skladisteAdresa = Console.ReadLine();

                                p.InsertSkladiste(new Skladiste(skladisteID, skladisteAdresa));

                                break;
                            case 6:

                                Console.WriteLine("Unesite podatke (ID, ISBN)");

                                int senalaziID = Int32.Parse(Console.ReadLine());
                                int senalaziISBN = Int32.Parse(Console.ReadLine());

                                p.InsertSeNalazi(new SeNalazi(senalaziID, senalaziISBN));

                                break;
                            case 4:

                                Console.WriteLine("Unesite podatke (IDKosarice, IDKupca)");

                                int kosaricaIDkosara = Int32.Parse(Console.ReadLine());
                                int kosaricaIDkupac = Int32.Parse(Console.ReadLine());

                                p.InsertKosarica(new Kosarica(kosaricaIDkosara, kosaricaIDkupac));

                                break;
                            case 5:

                                Console.WriteLine("Unesite podatke (ID, ime, adresa, broj mobitela, email)");

                                int kupacID = Int32.Parse(Console.ReadLine());
                                string kupacIme = Console.ReadLine();
                                string kupacAdresa = Console.ReadLine();
                                string kupacBroj = Console.ReadLine();
                                string kupacEmail = Console.ReadLine();

                                p.InsertKupac(new Kupac(kupacID, kupacAdresa, kupacBroj, kupacEmail, kupacIme));

                                break;
                            case 3:

                                Console.WriteLine("Unesite podatke (ISBN, ime, broj dostupnih, godina, IDskladista, IDizdavaca, IDautora)");

                                int knjigaISBN = Int32.Parse(Console.ReadLine());
                                string knjigaIme = Console.ReadLine();
                                int knjigaDostupnost = Int32.Parse(Console.ReadLine());
                                int knjigaGodina = Int32.Parse(Console.ReadLine());
                                int knjigaIDS = Int32.Parse(Console.ReadLine());
                                int knjigaIDI = Int32.Parse(Console.ReadLine());
                                int knjigaIDA = Int32.Parse(Console.ReadLine());

                                p.InsertKnjiga(new Knjiga(knjigaISBN, knjigaIme, knjigaGodina,  knjigaIDS,  knjigaIDI,  knjigaIDA,  knjigaDostupnost));

                                break;
                        }

                        break;
                    case 2:
                        // Remove from database
                        Console.WriteLine(submenu2title);
                        printMenu(names);
                        choice = readCorrectInput(1, names.Count);

                        switch (choice) {
                            case 1:
                                Console.WriteLine("Unesi ID autora za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteAutor(ID);
                                break;
                            case 2:
                                Console.WriteLine("Unesi ID izdavaca za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteIzdavac(ID);
                                break;
                            case 3:
                                Console.WriteLine("Unesi ISBN knjige za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteKnjiga(ID);
                                break;
                            case 4:
                                Console.WriteLine("Unesi ID kosarice za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteKosarica(ID);
                                break;
                            case 5:
                                Console.WriteLine("Unesi ID kupca za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteKupac(ID);
                                break;
                            case 6:
                                break;
                            case 7:
                                Console.WriteLine("Unesi ID skladista za obrisati");
                                ID = readCorrectInput(0, 2147483647);
                                p.DeleteSkladiste(ID);
                                break;
                            case 9:
                                break;
                        }

                        break;
                    case 3:
                        // Print from database
                        Console.WriteLine(submenu3title);
                        printMenu(names);
                        choice = readCorrectInput(1, names.Count);

                        switch (choice)
                        {
                            case 1:
                                p.PrintAutors();
                                break;
                            case 2:
                                p.PrintIzdavac();
                                break;
                            case 3:
                                p.PrintKnjiga();
                                break;
                            case 4:
                                p.PrintKosarica();
                                break;
                            case 5:
                                p.PrintKupac();
                                break;
                            case 6:
                                p.PrintSeNalazi();
                                break;
                            case 7:
                                p.PrintSkladiste();
                                break;
                            case 9:
                                break;
                        }

                        break;
                    case 4:
                        // Ubaci u kosaricu

                        Console.WriteLine(submenu4title);

                        IDKupca = readCorrectInput(0, 2147483647);
                        IDKosarice = readCorrectInput(0, 2147483647);
                        ISBN = readCorrectInput(0, 2147483647);

                        insertUKosaricu(IDKupca,  IDKosarice,  ISBN);
                        break;
                    case 5:
                        // Ispisi knjige autora x

                        Console.WriteLine("Unesi ID autora");
                        int authorID = readCorrectInput(0, 2147483647);

                        p.IspisKnjigaAutora(authorID);

                        break;
                    case 6:
                        // Ispisi sve autore sa knjigama na skladistu

                        Console.WriteLine("Unesi ID skladista");
                        int skladisteID2 = readCorrectInput(0, 2147483647);

                        p.IspisAutoraKnjigaSkladista(skladisteID2);

                        break;
                    case 7:
                        // Ispisi broj knjiga na skladistu

                        Console.WriteLine("Unesi ID skladista");
                        int skladisteID3 = readCorrectInput(0, 2147483647);

                        p.IspisBrojaKnjigaNaSkladistu(skladisteID3);

                        break;
                    case 8:
                        // Ispisi broj knjiga na skladistu

                        Console.WriteLine("Unesi ID autora");
                        int autorID3 = readCorrectInput(0, 2147483647);

                        p.IspisBrojaKnjigaOdAutora(autorID3);

                        break;
                    case 9:
                        // Quit
                        run = false;
                        break;
                }
            }
        }

        private static void insertUKosaricu(int IDKupca,int IDKosarice, int ISBN)
        {
            Posrednik posrednik = new Posrednik();
            posrednik.InsertKosarica(new Kosarica(IDKosarice, IDKupca));
            posrednik.InsertSeNalazi(new SeNalazi(ISBN, IDKosarice));
            posrednik.UpdateKnjiga(ISBN);
        }

        private static int readCorrectInput(int lowerBoud, int upperBound)
        { 
            int option = 0;
            bool validChoice = false;
            while (!validChoice)
            {
                string choice = Console.ReadLine();
                validChoice = Int32.TryParse(choice, out option);
                if (validChoice)
                {
                    if (option < lowerBoud || option > upperBound)
                    {
                        Console.WriteLine("Ulaz nije u pravom rasponu, pokusajte ponovo");
                        validChoice = false;
                    }
                }
                else
                {
                    Console.WriteLine("Ulaz nije pravog oblika, pokusajte ponovo");
                }
            }

            return option;
        }

        private static void printMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
            Console.WriteLine();
        }

        private static void setInitialValues()
        {
            Posrednik p = new Posrednik();

            p.InsertSkladiste(new Skladiste(1, "Jagiceva 5"));
            p.InsertSkladiste(new Skladiste(2, "Nazorova 13"));

            p.InsertAutor(new Autor("Fyodor Dostoevsky", "https://en.wikipedia.org/wiki/Fyodor_Dostoevsky", "St. Petersburg", 1));
            p.InsertAutor(new Autor("Ranko Marinković", "https://en.wikipedia.org/wiki/Ranko_Marinković", "Zagreb", 2));
            p.InsertAutor(new Autor("Izmisljenko", "https://en.wikipedia.org/wiki/Egg", "London", 3));

            p.InsertIzdavac(new Izdavac("Atlas Press", "https://en.wikipedia.org/wiki/Atlas_Press", "London", 1));
            p.InsertIzdavac(new Izdavac("Capstone Publishers", "https://en.wikipedia.org/wiki/Capstone_Publishers", "Mankato, Minnesota", 2));

            p.InsertKnjiga(new Knjiga(1, "Poor Folk", 1846, 1, 1, 1, 150));
            p.InsertKnjiga(new Knjiga(2, "Crime and Punishment", 1866, 1, 2, 1, 350));
            p.InsertKnjiga(new Knjiga(3, "The Idiot", 1868, 1, 2, 1, 50));
            p.InsertKnjiga(new Knjiga(4, "Kiklop", 1965, 1, 2, 2, 70));
            p.InsertKnjiga(new Knjiga(5, "Never more", 1993, 2, 1, 2, 90));
            p.InsertKnjiga(new Knjiga(6, "Albatros ", 1939, 2, 1, 2, 20));

            p.InsertKnjiga(new Knjiga(7, "Izmisljena 1", 1890, 1, 1, 3, 10));
            p.InsertKnjiga(new Knjiga(8, "Izmisljena 2", 1891, 1, 1, 3, 20));
        }
    }
}
