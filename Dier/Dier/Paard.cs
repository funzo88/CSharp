using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dier
{
    public class Paard : Vee
    {
        public double Trekkracht { get; protected set; }
        public Paard(double lengte, double massa, double breedte, double hoogte, string naam, double trekkracht) : base(lengte, breedte, hoogte, massa, naam)
        {
            Lengte = lengte;
            Massa = massa;
            Breedte = breedte;
            Hoogte = hoogte;
            Naam = naam;
            Trekkracht = trekkracht;
        }
        public override void MaakGeluid()
        {
            Console.WriteLine("Hinnik");
        }
    }
}
