using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leesgetal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vul een getal in");
            int getal = LeesGetal();
            Console.WriteLine("Het getal wat je hebt ingevuld is {0}", getal);
        }
        private static int LeesGetal()
        {
            int getal = 0;
            bool goed = false;
            while(!goed)
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