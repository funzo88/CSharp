using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dier
{
    public abstract class Dier : IComparable
    {
        // properties
        public double Massa { get; protected set; }
        public double Lengte { get; protected set; }
        public double Breedte { get; protected set; }
        public double Hoogte { get; protected set; }
        public double Inhoud { get; protected set; }
        public string Naam { get; protected set; }

        // methods
        public abstract Dier Reproduceer();

        public abstract void voeden();

        public abstract void ontlasten();

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Dier beest = obj as Dier;
            if (beest != null)
                return Massa.CompareTo(beest.Massa);
            else
                throw new ArgumentException("Geen Dier"); 
        }

    }
}
