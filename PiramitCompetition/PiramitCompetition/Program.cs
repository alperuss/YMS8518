using System;

namespace PiramitCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Piramitiniz kaç katlı olacak?");
            int kat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Artış miktarı ne olacak?");
            int n = Convert.ToInt32(Console.ReadLine());
            int result = 1;
            int toplam = 1;
            for (int i = 1; i < kat; i++)
            {
                result = result + n;
                toplam += result;
            }

            Console.WriteLine("Toplam = " + toplam );
            Console.WriteLine("Piramitin Son Katmanındaki Küp Sayısı = " + (1 + n * (kat - 1)));
            Console.ReadLine();
        }
    }
}
