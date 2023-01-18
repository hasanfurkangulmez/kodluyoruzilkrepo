using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.OrtaSeviyeProjeler
{
    public class MutlakKareAlma
    {
        public MutlakKareAlma()
        {
            MKA(PozitifSayiGiris());
        }

        public static void MKA(int Derece)
        {
            double Kucuk = 0;
            double Buyuk = 0;
            for (int i = 0; i < Derece; i++)
            {
                int Sayi = PozitifSayiGiris();
                if (Sayi < 67) Kucuk += 67 - Sayi;
                else if (Sayi > 67) Buyuk += Math.Pow(Sayi - 67, 2);
                else;
            }
            Console.WriteLine($"Küçük Değer: {Kucuk}\tBüyük Değer: {Buyuk}");
        }

        /// <summary>
        /// Pozitif sayi girişi yapar.
        /// Yapılmadığında tekrar döndürür.
        /// </summary>
        /// <returns>Pozitif sayı döndürür.</returns>
        public static int PozitifSayiGiris()
        {
            int N = 0;
            while (N <= 0)
            {
                Console.Write("Pozitif bir sayı giriniz: ");
                N = SayiMi(Console.ReadLine());
                if (N <= 0) Console.WriteLine("Lütfen pozitif bir sayı giriniz!");
            }
            return N;
        }

        /// <summary>
        /// Değişkene girilen karakterin sayı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="Sayi">Girişi yapılan sayı.</param>
        /// <returns>Girilen sayıyı geri döndürür.</returns>
        public static int SayiMi(string Sayi)
        {
            if (Sayi.Length <= 0)
                return 0;
            else
            {
                for (int i = 0; i < Sayi.Length; i++)
                    if (!char.IsDigit(Sayi[i]))
                        return 0;
                return int.Parse(Sayi);
            }
        }
    }
}
