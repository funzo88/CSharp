using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabriek
{
    class Program
    {
        private static List<Product> producten = new List<Product>();
        private static Random random = new Random();

        static void Main(string[] args)
        {
            PlaatsSigaren(2);
            PlaatsZappers(2);
            ToonProducten();
            Klappen();
            BerekenTotalePrijs();
            TotaleWinst();
        }

        private static void TotaleWinst()
        {
            double winst = 0;
            foreach (Product product in producten)
            {
                if(product is Handzapper)
                {
                    winst += (product.Prijs*0.2);
                }
                if(product is Klapsigaar)
                {
                    winst += (product.Prijs * 0.1);
                }
            }
            Console.WriteLine("De totale winst is {0} euro.", winst);
        }

        private static void BerekenTotalePrijs()
        {
            double totaleprijs = 0;
            foreach (Product product in producten)
            {
                totaleprijs += product.Prijs;
            }
            Console.WriteLine("De totale prijs is {0} euro.\n",totaleprijs);
        }

        private static void Klappen()
        {
            foreach (Product product in producten)
            {
                Klapsigaar sigaar = product as Klapsigaar;
                if (sigaar is Klapsigaar)
                {
                    double teller = sigaar.AantalSeconden;
                    while (teller > 0)
                    {
                        Console.Write("{0}...",teller);
                        teller--;
                    }
                    Console.Write("BAM!\n");
                }
            }
            Console.WriteLine("");
        }

        private static void ToonProducten()
        {
            double teller = 0;
            foreach(Product product in producten)
            {
                product.Activeer();
                teller++;
            }
            Console.WriteLine("Er zitten {0} items in de list.\n",teller);
        }

        private static void PlaatsZappers(int v)
        {
            for (int i = 0; i < v; i++)
            {
                producten.Add(NieuweZapper());
            }
        }

        private static Product NieuweZapper()
        {
            string kleur = "Geel";
            double prijs = random.Next(100,150);
            double voltage = random.Next(200,250);
            Handzapper zapper = new Handzapper(kleur, prijs, voltage);
            return zapper;
        }

        private static void PlaatsSigaren(int v)
        {
            for (int i = 0; i < v; i++)
            {
                producten.Add(NieuweSigaar());
            }
        }

        private static Product NieuweSigaar()
        {
            string kleur = "Rood";
            double prijs = random.Next(10, 50);
            double aantalseconden = random.Next(3,10);
            Klapsigaar sigaar = new Klapsigaar(kleur, prijs, aantalseconden);
            return sigaar;
        }
    }
}
