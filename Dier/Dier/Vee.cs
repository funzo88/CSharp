using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dier
{
    public class Vee : Dier
    {
        public Vee(double lengte, double massa, double breedte, double hoogte, string naam)
        {
            Lengte = lengte;
            Massa = massa;
            Breedte = breedte;
            Hoogte = hoogte;
            Naam = naam;
        }
        private void SetInhoud()
        {
            Inhoud = Lengte * Breedte * Hoogte;
        }
        public override Dier Reproduceer()
        {
            return new Vee(Massa, Lengte, Breedte, Hoogte, Naam);
        }
        public override void voeden()
        {
            Lengte *= 1.01;
            Hoogte *= 1.01;
            Breedte *= 1.01;
            Massa *= 1.03;

        }
        public override void ontlasten()
        {
            Lengte *= 0.99;
            Hoogte *= 0.99;
            Breedte *= 0.99;
            Massa *= 0.97;
        }
        public virtual void MaakGeluid()
        {

        }
    }
}
