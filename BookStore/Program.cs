using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dobrodošli u online knjižaru!\n\nJeste li korisnik? (Y/N)");
            bool isUser = Console.ReadLine() == "Y";
            Console.WriteLine(isUser);

            while (true)
            {
                // sta god korisnik radi, jedna od opcija -> exit

                
            }
        }
    }
}
