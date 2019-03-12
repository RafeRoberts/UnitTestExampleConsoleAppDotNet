using System;

namespace BookStore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                BookStore bookdata = new BookStore();
                Console.Write(bookdata.DisplayOrder());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            ConsoleKey inputkey = Console.ReadKey(true).Key;
        }
    }
}