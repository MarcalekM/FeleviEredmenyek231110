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
            while (!sr.EndOfStream) if(sr.ReadLine() != null) tanulok.Add(new(sr.ReadLine()));
            var v = sor.Split('\t');
            for (int i = 2; i < v.Length; i++)
            {
                tanorak.Add(v[i]);
            }

            Console.WriteLine("1. feladat:");
            Console.WriteLine($"\tAz osztályátlag:  {Osztalyatlag(tanulok)}");

            Console.WriteLine("2. feladat:");
            int index = tanorak.IndexOf("Programozás gyakorlat");
            var bukottak = tanulok.Where(t => t.Jegyek[index] == 1);
            foreach (var b in bukottak)
            {
                Console.WriteLine($"\tNév:  {b.Nev}\n\tTanulóikód:  {b.Kod}");
            }

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
    }
}
