using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.OrtaSeviyeProjeler
{
    public class SessizHarf
    {
        static readonly string SessizHarfler = "BbCcÇçDdFfGgĞğHhJjKkLlMmNnPpRrSsŞşTtVvYyZz";
        public SessizHarf()
        {
            Console.WriteLine("Bir cümle giriniz: ");
            SH(Console.ReadLine().Split(' '));
        }

        public static void SH(string[] Kelime)
        {
            bool Kontrol = false;
            for (int i = 0; i < Kelime.Length; i++)
            {
                for (int j = 0; j < Kelime[i].Length - 1; j++)
                    if (SessizHarfler.ToCharArray().Contains(Kelime[i][j]) && SessizHarfler.ToCharArray().Contains(Kelime[i][j + 1]))
                        Kontrol = true;
                Console.Write($"{Kontrol} ");
                Kontrol = false;
            }
        }
    }
}
