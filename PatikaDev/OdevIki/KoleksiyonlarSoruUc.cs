using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.OdevIki
{
    public class KoleksiyonlarSoruUc
    {
        static readonly string SesliHarfler = "AaEeIıİiOoUuÜü";
        static readonly string SessizHarfler = "BbCcÇçDdFfGgĞğHhJjKkLlMmNnPpRrSsŞşTtVvYyZz";
        static List<char> SesliHarflerList = new List<char> { };
        static List<char> SessizHarflerList = new List<char> { };

        public KoleksiyonlarSoruUc()
        {
            Console.Write("Bir cümle girişi yapınız: ");
            SesliSessizHarfSayısı(Console.ReadLine());
            Console.Write("Sesli Harfler Listesi  :\t");
            SesliHarflerList.ForEach(s => Console.Write($"{s,3}"));
            Console.Write("\nSessiz Harfler Listesi :\t");
            SessizHarflerList.ForEach(a => Console.Write($"{a,3}"));
        }

        /// <summary>
        /// Sesli ve sessiz harflerin listesini oluşturur.
        /// </summary>
        /// <param name="Cumle">Girilen cümle</param>
        public static void SesliSessizHarfSayısı(string Cumle)
        {
            for (int i = 0; i < Cumle.Length; i++)
            {
                for (int j = 0; j < SesliHarfler.Length; j++)
                    if (Cumle[i] == SesliHarfler[j])
                        SesliHarflerList.Add(SesliHarfler[j]);
                for (int j = 0; j < SessizHarfler.Length; j++)
                    if (Cumle[i] == SessizHarfler[j])
                        SessizHarflerList.Add(SessizHarfler[j]);
            }
        }
    }
}
