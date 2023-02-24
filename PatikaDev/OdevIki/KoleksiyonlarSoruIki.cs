using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.OdevIki
{
    public class KoleksiyonlarSoruIki
    {
        static double[] Sayilar = new double[20];
        static double[] EnBuyukUc = new double[3];
        static double[] EnKucukUc = new double[3];

        public KoleksiyonlarSoruIki()
        {
            Console.WriteLine("20 Adet Sayı Girişi Yapınız.");

            for (int i = 0; i < Sayilar.Length; i++)
            {
                Console.Write("Sayi giriniz: ");
                Sayilar[i] = SayiMi(Console.ReadLine());
            }
            Array.Sort(Sayilar);
            Array.Copy(Sayilar, EnKucukUc, 3);
            Array.Reverse(Sayilar);
            Array.Copy(Sayilar, EnBuyukUc, 3);

            Console.Write("Girilen Dizi Elemanları: ");
            DiziYazdir(Sayilar);

            Console.Write("\nEn Büyük Üç Eleman: ");
            DiziYazdir(EnBuyukUc);
            Console.Write($"\nEn Büyük Üç Eleman Ortalaması: {EnBuyukUc.Average(),10:F2}");

            Console.Write("\nEn Küçük Üç Eleman: ");
            DiziYazdir(EnKucukUc);
            Console.Write($"\nEn Küçük Üç Eleman Ortalaması: {EnKucukUc.Average(),10:F2}");

            Console.WriteLine($"\nOrtalama Toplamları: {(EnBuyukUc.Average() + EnKucukUc.Average()),10:F2}");
        }

        /// <summary>
        /// Dizi elemanlarını ekrana yazdırır.
        /// </summary>
        /// <param name="Dizi">Ekrana yazdırılacak dizi.</param>
        public static void DiziYazdir(double[] Dizi)
        {
            foreach (var eleman in Dizi)
                Console.Write($"{eleman,5}");
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
                    if (!(char.IsDigit(Sayi[i])))
                        return 0;
                return int.Parse(Sayi);
            }
        }
    }
}
