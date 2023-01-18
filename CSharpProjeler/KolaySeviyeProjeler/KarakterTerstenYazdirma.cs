using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.KolaySeviyeProjeler
{
    public class KarakterTerstenYazdirma
    {
        public KarakterTerstenYazdirma()
        {
            Console.WriteLine("Bir cümle giriniz: ");
            KarakterTerstenYazdir(Console.ReadLine().Split(' '));
        }
        public static void KarakterTerstenYazdir(string[] Kelime)
        {
            for (int i = 0; i < Kelime.Length; i++) Kelime[i] = Kelime[i].Substring(1) + (Kelime[i])[0];
            foreach (var Eleman in Kelime) Console.Write($"{Eleman} ");
        }
    }
}
