using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.OrtaSeviyeProjeler
{
    public class IntegerIkililerininToplamı
    {
        public IntegerIkililerininToplamı()
        {
            IIT(PozitifSayiGiris());
        }

        public static void IIT(int Derece)
        {
            int[] Sayilar = new int[Derece];
            for (int i = 0; i < Derece; i++)
            {
                Sayilar[i] = PozitifSayiGiris();
            }
            Islem(Sayilar);
        }
        public static void Islem(int[] Sayilar)
        {
            for (int i = 0; i < (Sayilar.Length % 2 == 0 ? Sayilar.Length : Sayilar.Length - 1); i += 2)
            {
                if (Sayilar[i] == Sayilar[i + 1]) Console.Write($"{Math.Pow(Sayilar[i] + Sayilar[i + 1], 2)}\t");
                else Console.Write($"{Sayilar[i] + Sayilar[i + 1]}\t");
            }
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
