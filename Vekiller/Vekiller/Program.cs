using System;

namespace Vekiller
{
    class Program
    {
        public static string ConcattedString = string.Empty;
        public static void Concat(string ilk,string son)
        {
            ConcattedString = ilk + son;
           Console.WriteLine(ilk + son);
        }

        static void Main(string[] args)
        {

            Action<string, string> testDelegate2 = Concat;
            testDelegate2("x","y");

            
            Console.WriteLine("Singleton'dan gelen nesne: "+ ConcattedString);
          
            Console.ReadLine();
            
        }
    }
}
