using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen
{
    public class Persoon
    {
        private double _gewicht;
        public double Gewicht { get { return _gewicht; } set { if (value > 0) { _gewicht = value; } } }
        public Persoon(double gewicht)
        {
            Gewicht = gewicht;
        }
    }
}
