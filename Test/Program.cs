using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bir sayı giriniz:");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x<45)
            {
                Console.WriteLine("Kaldınız");
            }
            else
            {
                Console.WriteLine("GEçtiniz");
            }
            Console.WriteLine(x < 45 ? "Kaldınız" : "GEçtiniz");
        }
    }
}
