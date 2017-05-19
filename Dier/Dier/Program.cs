using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dier
{
    class Program
    {
        private static Random random = new Random();
        private static List<Vee> Stal = new List<Vee>();
        private static Queue<Vee> melkRij = new Queue<Vee>();
        private static Stack<Vee> koeienstack = new Stack<Vee>();
  
        static void Main(string[] args)
        {

            PlaatsKoeien(5);
            PlaatsGeiten(6);
            PlaatsPaarden(8);
            PlaatsMelkKoeien(11);

            GeitenGeluid();
            Console.WriteLine("");
            ZwaarsteDier();
            Console.WriteLine("");
            Voeden();
            Console.WriteLine("");
            Ontlasting();
            Console.WriteLine("");
            VerkoopKoeien();
            Console.WriteLine("");
            SorteerDieren();
            Console.WriteLine("");
            ReproduceerKoe();
            Console.WriteLine("");
            HoeveelWater();
            Console.WriteLine("");
            ToonPaarden();
            Console.WriteLine("");
            KoeienTrekken();
            KoeInStack();
            //MelkRij();
            //MelkMachine();

        }

        private static void KoeInStack()
        {
            int teller = 0;
            foreach (Vee koe in Stal)
            {
                if (koe is Koe)
                {
                    koeienstack.Push(koe);
                    teller++;

                }
            }
            //Console.WriteLine(teller);
        }

        private static void MelkRij()
        {
            bool enter = false;
            int rijteller = 0;

            foreach (Vee vee in Stal)
            {
                if (vee is Melkkoe)
                {
                    do
                    {
                        Console.WriteLine("Druk op 'Enter' om melkkoe {0} in de melk-rij te plaatsen.", vee.Naam);
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            rijteller++;
                            Console.Clear();
                            enter = true;
                            melkRij.Enqueue(vee);
                            Console.WriteLine("Melkkoe {0} staat nu in de rij.\nTotale Koei(en) in de rij: {1}\n", vee.Naam, rijteller);
                        }
                        else
                        {
                            enter = false;
                        }
                    } while (!enter);
                }
            }
            Console.WriteLine("Rij is vol. Er zijn {0} melkkoeien in de rij.\n", rijteller);
            Console.ReadKey();
        }

        private static void MelkMachine()
        {
            MelkRij();
            bool enter = false;
            double i = 0;
            double litres = 0;
            foreach (Melkkoe melkkoe in melkRij)
            {
                do
                {
                    Console.WriteLine("Druk op 'Enter' om melkproductie te beginnen.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        if (i <= melkRij.Count)
                        {
                            Console.Clear();
                            litres += melkkoe.MelkProductie;
                            i++;
                            enter = true;
                            Console.WriteLine("{0} is gemolken en heeft {1}litres melk gegeven.\n Er zijn nu {2}litres melk in de vat\n\n", melkkoe.Naam, melkkoe.MelkProductie, litres);
                        }
                        else
                        {
                            Console.WriteLine("Geen koeien te melken.");
                            enter = true;
                        }
                    }
                } while (!enter);
            }
            Console.Clear();
            Console.WriteLine("Alle koeien zijn gemolken.\n{0} koeien zijn gemolken.\n{1}litres in totaal gekregen.", melkRij.Count, litres);
        }

        private static void ReproduceerKoe()
        {
            List<Koe> kraamkamer = new List<Koe>();
            foreach (Vee vee in Stal)
            {
                if (vee is Koe)
                {
                    Dier baby = vee.Reproduceer();
                    Koe kalf = baby as Koe;
                    kraamkamer.Add(kalf);
                }
            }
            int teller = 0;
            foreach(Koe kalf in kraamkamer)
            {
                teller++;
                Stal.Add(kalf);
            }
            Console.WriteLine("{0} kalfjes geboren.", teller);

        }

        private static void KoeienTrekken()
        {
            double totalekracht = 0;
            foreach (Vee paardje in Stal)
            {
                Paard ros = paardje as Paard;
                if (ros is Paard)
                {
                    totalekracht += ros.Trekkracht;
                }
            }
            double totalekrachtkg = totalekracht / 9.8;
            totalekrachtkg = Math.Round(totalekrachtkg, 2);
            Console.WriteLine("De totale kracht in kg is {0}", totalekrachtkg);

            double aantalkoeien = 0;
            bool vullen = true;
            while (vullen == true)
            {
                foreach (Vee koeien in Stal)
                {
                    if (koeien is Koe)
                    {
                        totalekrachtkg = totalekrachtkg - koeien.Massa;
                        if (totalekrachtkg <= 0)
                        {
                            vullen = false;
                        }
                        else
                        {
                            Console.WriteLine("{0} weegt {1}kg en gaat in de bak", koeien.Naam, koeien.Massa);
                            aantalkoeien++;
                            Console.WriteLine("De paarden kunnen nog {0}kg tillen",totalekrachtkg);
                        }
                    }
                }
            }
            Console.WriteLine("De paarden kunnen {0} koeien tillen.", aantalkoeien);
        }

        private static void ToonPaarden()
        {
            foreach (Vee paardje in Stal)
            {
                Paard ros = paardje as Paard;
                if (ros is Paard)
                {
                    Console.WriteLine("{0} heeft {1} trekkracht", ros.Naam, ros.Trekkracht);
                }
            }
        }

        private static void PlaatsPaarden(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Stal.Add(NieuwePaard());
            }
        }

        private static Vee NieuwePaard()
        {
            double lengte = random.Next(200, 300);
            double massa = random.Next(600, 800);
            double breedte = random.Next(60, 100);
            double hoogte = random.Next(100, 200);
            double trekkracht = massa * 7.5;
            string naam = PaardenNaam();
            Paard pony = new Paard(lengte, massa, breedte, hoogte, naam, trekkracht);
            return pony;
        }

        private static string PaardenNaam()
        {
            return string.Format("Paard_{0}{1}{2}", eenCijfer(), eenCijfer(), eenCijfer());
        }

        private static void HoeveelWater()
        {
            double watergeiten = 0;
            double waterkoeien = 0;
            double watertotaal = 0;
            foreach (Vee dier in Stal)
            {
                if (dier is Geit)
                {
                    watergeiten += 30;
                }
                else if (dier is Koe)
                {
                    waterkoeien += 60;
                }
            }
            watertotaal = watergeiten + waterkoeien;
            Console.WriteLine("De geiten gebruiken {0}m\xB3 water per jaar", watergeiten);
            Console.WriteLine("De koeien gebruiken {0}m\xB3 water per jaar", waterkoeien);
            Console.WriteLine("Je hebt in totaal {0}m\xB3 water nodig per jaar", watertotaal);
        }

        private static void SorteerDieren()
        {
            Stal.Sort();
            foreach (Dier sorteer in Stal)
                Console.WriteLine("{0} weegt {1}kg", sorteer.Naam, sorteer.Massa);
        }

        private static void PlaatsMelkKoeien(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Stal.Add(NieuweKoe());
            }
        }

        private static Melkkoe NieuweMelkKoe()
        {
            double lengte = random.Next(50, 200);
            double massa = random.Next(500, 800);
            double breedte = random.Next(30, 80);
            double hoogte = random.Next(80, 150);
            string naam = KoeienNaam();
            Melkkoe kalf = new Melkkoe(lengte, massa, breedte, hoogte, naam);
            return kalf;
        }

        private static void PlaatsKoeien(int v)
        {
            for(int i = 0; i < v; i++)
            {
                Stal.Add(NieuweKoe());
            }
        }

        private static Koe NieuweKoe()
        {
            double lengte = random.Next(50, 200);
            double massa = random.Next(500, 800);
            double breedte = random.Next(30, 80);
            double hoogte = random.Next(80, 150);
            string naam = KoeienNaam();
            Koe rund = new Koe(lengte, massa, breedte, hoogte, naam);
            return rund;
        }

        private static string KoeienNaam()
        {
            return string.Format("Koe_{0}{1}{2}", eenCijfer(), eenCijfer(), eenCijfer());
        }

        private static void PlaatsGeiten(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Stal.Add(NieuweGeit());
            }
        }

        private static Geit NieuweGeit()
        {
            double lengte = random.Next(50, 120);
            double massa = random.Next(70, 100);
            double breedte = random.Next(20, 40);
            double hoogte = random.Next(50, 80);
            string naam = GeitenNaam();
            Geit rund = new Geit(lengte, massa, breedte, hoogte, naam);
            return rund;
        }

        private static string GeitenNaam()
        {
            return string.Format("Schaap_{0}{1}{2}", eenCijfer(), eenCijfer(), eenCijfer());
        }

        private static object eenCijfer()
        {
            int index = random.Next(0, 9);
            return index;
        }

        private static void VerkoopKoeien()
        {
            List<Vee> tijdelijk = new List<Vee>();
            int teller = 0;
            foreach(Vee dier in Stal)
            {
                if ((dier is Koe) && (dier.Massa > 700))
                {
                    teller++;
                    Console.WriteLine("{0} weegt {1}kg en wordt verkocht",dier.Naam, dier.Massa);
                } else
                {
                    tijdelijk.Add(dier);

                }
            }
            Stal = tijdelijk;

            Console.WriteLine("Er zijn {0} koeien verkocht.", teller);
        }

        private static void GeitenGeluid()
        {
            double totaalgewicht = 0;
            foreach (Vee dier in Stal)
            {
                if (dier is Geit)
                {
                    Console.Write("{0} zegt ", dier.Naam);
                    dier.MaakGeluid();
                }
                totaalgewicht += dier.Massa;
            }
            Console.WriteLine("Het totale gewicht in de stal is {0}kg", totaalgewicht);
        }

        private static void Ontlasting()
        {
            double totaalgewicht = 0;
            foreach (Vee dier in Stal)
            {
                if (dier is Geit)
                {
                    dier.ontlasten();
                }
                totaalgewicht += dier.Massa;
            }
            Console.WriteLine("De geiten zijn ontlast. Het totale gewicht is nu: {0}kg", totaalgewicht);
        }

        private static void Voeden()
        {
            double totaalgewicht = 0;
            foreach (Vee dier in Stal)
            {
                if (dier is Koe)
                {
                    dier.voeden();
                }
                totaalgewicht += dier.Massa;
            }
            Console.WriteLine("De koeien zijn gevoed. Het totale gewicht is nu: {0}kg", totaalgewicht);
        }

        public static void ZwaarsteDier()
        {
            double zwaarste = 0;
            string diernaam = "";
            foreach (Vee item in Stal)
            {
                if (item.Massa > zwaarste)
                {
                    zwaarste = item.Massa;
                    diernaam = item.Naam;
                }
            }
            Console.WriteLine("Het zwaarste dier is {0} met een gewicht van {1}kg", diernaam, zwaarste);
        }
    }
}
