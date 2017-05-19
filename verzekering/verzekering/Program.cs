using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verzekering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vul uw geboorte datum in op de volgende manier: dd/mm/yyyy");
            int date = LeesDatum();
        }
        private static int LeesDatum()
        {
            int date = 01/01/2000;
            bool goed = false;
            while (!goed)
            {
                string invoer = Console.ReadLine();
                try
                {
                    DateTime dt = DateTime.Parse(invoer);
                    goed = true;
                }
                catch
                {
                    Console.WriteLine("Geen getal ingevoerd");
                    goed = false;
                }
            }
            return date;
        }
        private static int LeesGetal()
        {
            int getal = 0;
            bool goed = false;
            while (!goed)
            {
                string invoer = Console.ReadLine();
                try
                {
                    getal = int.Parse(invoer);
                    goed = true;
                }
                catch
                {
                    Console.WriteLine("Geen getal ingevoerd");
                    goed = false;
                }
            }
            return getal;
        }
    }
}