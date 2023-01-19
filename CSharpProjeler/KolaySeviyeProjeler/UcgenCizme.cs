using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.KolaySeviyeProjeler
{
    public class UcgenCizme
    {
        public UcgenCizme()
        {
            Ciz(PozitifSayiGiris());
            CizIki(PozitifSayiGiris());
        }
        public static void Ciz(int Limit)
        {
            int a = -1;
            for (int i = 1; i <= Limit; i++)
            {
                if (i == 1) Console.WriteLine(@$"{new string(' ', Limit - i)}*");
                else if (i > 1 && i < Limit) Console.WriteLine(@$"{new string(' ', Limit - i)}*{new string(' ', a)}*");
                else Console.WriteLine($"{new string('*', Limit * 2 - 1)}");
                a += 2;
            }
        }
        public static void CizIki(int Limit)
        {
            for (int i = 1; i <= Limit; i++)
            {
                for (int j = 1; j <= Limit - i; j++) Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
                Console.WriteLine();
            }
            for (int i = Limit - 1; i >= 1; i--)
                Console.WriteLine($"{new string(' ', Limit - i)}{new string('*', i * 2 - 1)}");
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
                Console.Write("Üçgen boyutunu giriniz: ");
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
