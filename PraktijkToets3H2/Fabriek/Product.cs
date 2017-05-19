using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabriek
{
    public abstract class Product
    {
        public string Kleur { get; set; }
        public double Prijs { get; set; }
        public Product(string kleur, double prijs)
        {
            kleur = Kleur;
            prijs = Prijs;
        }
        public abstract void Activeer();
    }
}
