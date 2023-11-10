using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeleviEredmenyek231110
{
    class Tanulo
    {
        public string Nev { get; set; }
        public string Kod { get; set; }
        public List<int> Jegyek { get; set; }
        public double Atlag => Jegyek.Average();

        public Tanulo(string sor)
        {
            var v = sor.Split('\t');
            Nev = v[0];
            Kod = v[1];
            List<int> jegyek = new();
            for (int i = 2; i < v.Length; i++)
            {
                jegyek.Add(int.Parse(v[i]));
            }
            Jegyek = jegyek;
        }

        
    }
}
