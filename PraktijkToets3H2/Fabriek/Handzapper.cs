using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabriek
{
    class Handzapper : Product
    {
        public double Voltage { get; set; }

        public Handzapper(string kleur, double prijs, double voltage) : base(kleur, prijs)
        {
            Kleur = kleur;
            Prijs = prijs;
            Voltage = voltage;
        }

        public override void Activeer()
        {
            Console.WriteLine("Bzzt!");
        }
    }
}
