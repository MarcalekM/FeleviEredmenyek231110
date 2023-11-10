using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeleviEredmenyek231110
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tanulo> tanulok = new();
            List<string> tanorak = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\Eredmenyek.txt",
                encoding: UTF8Encoding.UTF8);
            string sor = sr.ReadLine();
            while (!sr.EndOfStream) if (sr.ReadLine() != null) tanulok.Add(new(sr.ReadLine()));
            var v = sor.Split('\t');
            for (int i = 2; i < v.Length; i++)
            {
                tanorak.Add(v[i]);
            }

            Console.WriteLine("1. feladat:");
            Console.WriteLine($"\tAz osztályátlag:  {Osztalyatlag(tanulok)}");
            var atlagok = OraAtlag(tanulok, tanorak);
            for (int i = 0; i < tanorak.Count; i++)
            {
                Console.WriteLine($"{tanorak[i]}:  {atlagok[i]}");
            }

            Console.WriteLine("2. feladat:");
            int index = tanorak.IndexOf("Programozás gyakorlat");
            var bukottak = tanulok.Where(t => t.Jegyek[index] == 1);
            foreach (var b in bukottak)
            {
                Console.WriteLine($"\tNév:  {b.Nev}\n\tTanulóikód:  {b.Kod}");
            }

            Console.WriteLine("3. feladat:");
            Console.WriteLine(ElsoHarmas(tanulok, tanorak));

            Console.WriteLine("4.feladat:");
            Console.Write("Adja meg a keresett tanuló nevét:  ");
            string nev = Console.ReadLine();
            Console.WriteLine($"\t{nev} legjobb jegye:  {LegjobbJegy(nev, tanulok)}");

            using StreamWriter sw = new(
                path: @"..\..\..\src\Eredmenyek2.txt",
                append: false,
                encoding: UTF8Encoding.UTF8);
            foreach (var t in tanulok)
            {
                sw.WriteLine($"{t.Nev}\t{t.Kod}");
            }
            Console.ReadLine();
        }

        static double Osztalyatlag(List<Tanulo> tanulok)
        {
            double atlag = 0;
            foreach (var t in tanulok)
            {
                atlag += t.Atlag;
            }
            atlag /= tanulok.Count();
            return atlag;
        }
        static List<double> OraAtlag(List<Tanulo> tanulok, List<string> tanorak)
        {
            List<double> oraAtlagok = new();
            double atlag = 0;
            int oszto = 0;
            for (int i = 0; i < tanulok.Count; i++)
            {
                for (int j = 0; j < tanulok[i].Jegyek.Count; j++)
                {
                    atlag += tanulok[i].Jegyek[j];
                    oszto = tanulok[i].Jegyek.Count;
                }
                atlag /= oszto;
                oraAtlagok.Add(atlag);
                atlag = 0;
            }
            return oraAtlagok;
        }

        static int LegjobbJegy(string nev, List<Tanulo> tanulok)
        {
            int jegy = 0;
            foreach (var t in tanulok)
            {
                if (t.Nev == nev)
                {
                    for (int i = 0; i < t.Jegyek.Count; i++)
                    {
                        if (t.Jegyek[i] > jegy)  jegy = t.Jegyek[i];
                    }
                }
            }
            return jegy;
        }

        static string ElsoHarmas(List<Tanulo> tanulok, List<string> tanorak)
        {
            int index = tanorak.IndexOf("Angol nyelv");
            var tanulo = tanulok.Where(t => t.Jegyek[index].Equals(3)).First();
            return $"\tNév:  {tanulo.Nev}\n\tKód:  {tanulo.Kod}";
        }
    }
}
