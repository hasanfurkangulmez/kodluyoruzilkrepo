using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.KolaySeviyeProjeler
{
    public class OrtalamaHesapla
    {
        static int[] FibonacciList;
        public OrtalamaHesapla()
        {
            Console.WriteLine("Fibonacci derinliği giriniz: ");
            Fibonacci(PozitifSayiGiris());
            foreach (var item in FibonacciList)
                Console.Write($"{item}\t");
            Console.WriteLine($"\nFibonacci Ortalaması: {FibonacciList.Average():F2}");
        }

        /// <summary>
        /// Derinliğe göre fibonacci dizisini ve ortalamasını bulur.
        /// </summary>
        /// <param name="n">Derinlik</param>
        public static void Fibonacci(int n)
        {
            FibonacciList = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i >= 2) FibonacciList[i] = FibonacciList[i - 1] + FibonacciList[i - 2];
                else FibonacciList[i] = 1;
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
