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
            //initialValues();
            Posrednik p = new Posrednik();
            //p.DeleteAutor(10232);
            //p.InsertIzdavac(new Izdavac("Skolska knjiga", "URL", "Zagreb", 19));
            //p.InsertSkladiste(new Skladiste(42, "Velika Gorica"));
            //p.InsertAutor(new Autor("Suzanne Collins", "URL","Amerika",101));
            //p.InsertKnjiga(new Knjiga(20,"Igre Gladi1",2015,42,19,101,17));
            //p.InsertKnjiga(new Knjiga(21, "Igre Gladi2", 2015, 42, 19, 101, 17));
            //p.InsertKnjiga(new Knjiga(23, "Igre Gladi3", 2015, 42, 19, 101, 17));
            //p.IspisKnjigaAutora(101);
            //p.InsertKupac(new Kupac(17, "Slatina","", "pero.persic@gmail.com", "Pero"));
            //p.InsertKosarica(new Kosarica(14, 17));
            
            //p.DeleteIzdavac(7);

            List<string> mainMenu = new List<string>();
            mainMenu.Add("Odaberite radnju :");
            mainMenu.Add("(1) Unesi u bazu");
            mainMenu.Add("(2) Obrisi iz baze");
            mainMenu.Add("(3) Ispisi iz baze");
            mainMenu.Add("(4) Ubaci u kosaricu");
            mainMenu.Add("(5) Izbaci iz kosarice");
            mainMenu.Add("(9) Izađi iz programa");

            string submenu1title = "Odaberite gdje unijeti :";
            string submenu2title = "Odaberite gdje obrisati :";
            string submenu3title = "Odaberite sto ispisati :";
            string submenu4title = "Unesite podatke onoga za ubaciti (IDKupca, IDKosarice, ISBN) :";
            string submenu5title = "Unesite podatke onoga za izbaciti (IDKupca, IDKosarice, ISBN) :";

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
                printMenu(mainMenu);
                int option = readCorrectInput(1, 4);
                
                int ID;
                int choice;
                switch (option)
                {
                    case 1:
                        // Insert into database
                        Console.WriteLine(submenu1title);
                        printMenu(names);
                        choice = readCorrectInput(1, 7);

                        // TODO logic
                        break;
                    case 2:
                        // Remove from database
                        Console.WriteLine(submenu2title);
                        printMenu(names);
                        choice = readCorrectInput(1, 7);

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
                        choice = readCorrectInput(1, 7);

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

                        int IDKupca = readCorrectInput(0, 2147483647);
                        int IDKosarice = readCorrectInput(0, 2147483647);
                        int ISBN = readCorrectInput(0, 2147483647);

                        insertUKosaricu(IDKupca,  IDKosarice,  ISBN);
                        break;
                    case 5:
                        // Izbaci iz kosarice

                        Console.WriteLine(submenu5title);

                        int IDKupca = readCorrectInput(0, 2147483647);
                        int IDKosarice = readCorrectInput(0, 2147483647);
                        int ISBN = readCorrectInput(0, 2147483647);

                        //insertUKosaricu(IDKupca, IDKosarice, ISBN);
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
                Console.WriteLine(items[i] + "\n");
            }
        }

        private static void initialValues()
        {
            Posrednik p = new Posrednik();
            p.InsertAutor(new Autor("Stipe", "URLnn", "Osijek1", 10));
            p.InsertAutor(new Autor("Joka", "URL", "Osijek2", 20));
            p.InsertAutor(new Autor("Karlo", "URLnn", "Osijek3", 30));
            p.InsertAutor(new Autor("George", "URLnn", "Osijek1", 40));
            p.InsertAutor(new Autor("Pero", "URLnn", "Osijek1", 50));
        }

    }
}
