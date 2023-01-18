using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.OrtaSeviyeProjeler
{
    public class KarakterDegistirme
    {
        public KarakterDegistirme()
        {
            Console.WriteLine("Bir cümle giriniz: ");
            KarakterDegis(Console.ReadLine().Split(' '));
        }

        public static void KarakterDegis(string[] Kelime)
        {
            for (int i = 0; i < Kelime.Length; i++)
                if (Kelime[i].Length >= 2)
                    Kelime[i] = Kelime[i].Substring(Kelime[i].Length - 1) + Kelime[i].Substring(1, Kelime[i].Length - 2) + Kelime[i][0];
            foreach (var Eleman in Kelime) Console.Write($"{Eleman} ");
            /*char[] a = Kelime[i].ToCharArray();
              char T = a[0];
              a[0] = a[a.Length - 1];
              a[a.Length - 1] = T;
              Kelime[i] = "";
              for (int s = 0; s < a.Length; s++) Kelime[i] += a[s];*/
        }
    }
}
