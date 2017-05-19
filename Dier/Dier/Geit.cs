using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dier
{
    public class Geit : Vee
    {
        public Geit(double lengte, double massa, double breedte, double hoogte, string naam) : base(lengte, breedte, hoogte, massa, naam)
        {
            Lengte = lengte;
            Massa = massa;
            Breedte = breedte;
            Hoogte = hoogte;
            Naam = naam;
        }
        public override void MaakGeluid()
        {
            Console.WriteLine("Beep Beep I'm a sheep");
        }
    }
}
