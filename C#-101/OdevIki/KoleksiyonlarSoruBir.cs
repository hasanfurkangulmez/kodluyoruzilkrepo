using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.OdevIki
{
    public class KoleksiyonlarSoruBir
    {
        ArrayList AsalSayilar = new ArrayList();
        ArrayList AsalOlmayanSayilar = new ArrayList();
        public KoleksiyonlarSoruBir()
        {
            Console.WriteLine("20 Adet Sayı Girişi Yapılacaktır.");
            for (int i = 0; i < 20; i++)
            {
                int N = PozitifSayiGiris();
                if (AsalMi(N)) AsalSayilar.Add(N);
                else AsalOlmayanSayilar.Add(N);
            }
            Console.WriteLine($"{new string('-', 50)}\nAsal Sayilar");
            DiziYazdir(AsalSayilar);
            Console.WriteLine($"{new string('-', 50)}\nAsal Olmayan Sayilar");
            DiziYazdir(AsalOlmayanSayilar);
            Console.WriteLine($"{new string('-', 50)}");
        }

        #region Eklentiler
        /// <summary>
        /// Diziyi ekrana yazdırır.
        /// </summary>
        /// <param name="Liste">Girilen dizi</param>
        public static void DiziYazdir(ArrayList Liste)
        {
            Liste.Sort();
            Liste.Reverse();
            double Toplam = 0;
            foreach (int Eleman in Liste)
            {
                Toplam += Eleman;
                Console.Write($"{Eleman,10}");
            }
            Console.WriteLine($"\nEleman Sayısı: {Liste.Count,5}\nOrtalama: {(Toplam / Liste.Count),10:F2}");
        }

        /// <summary>
        /// Sayının asal kontrolünü yapar.
        /// </summary>
        /// <param name="x">Girilen sayı</param>
        /// <returns>True or False</returns>
        public static bool AsalMi(double x)
        {
            if (x <= 1) return false;
            else
            {
                for (int i = 2; i < x; i++)
                {
                    if (x % i == 0) return false;
                    else if (i == x - 1) return true;
                }
                return true;
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
        #endregion

    }
}
