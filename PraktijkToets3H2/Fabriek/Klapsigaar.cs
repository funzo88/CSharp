using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabriek
{
    public class Klapsigaar : Product
    {
        public double AantalSeconden { get; set; }

        public Klapsigaar(string kleur, double prijs, double aantalseconden) : base(kleur, prijs)
        {
            Kleur = kleur;
            Prijs = prijs;
            AantalSeconden = aantalseconden;
        }

        public override void Activeer()
        {
            Console.WriteLine("Bam!");
        }
    }
}
