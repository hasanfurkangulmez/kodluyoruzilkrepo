using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.OdevBir
{
    public class OdevBir
    {
        public OdevBir()
        {
            Console.WriteLine($"{new string('-', 50)}\nSoru Bir");
            SoruBir();
            Console.WriteLine($"\n{new string('-', 50)}\nSoru İki");
            SoruIki();
            Console.WriteLine($"\n{new string('-', 50)}\nSoru Üç");
            SoruUc();
            Console.WriteLine($"\n{new string('-', 50)}\nSoru Dört");
            SoruDort();
            Console.WriteLine($"\n{new string('-', 50)}\nİyi Çalışmalar.");
        }

        #region SoruBir
        /// <summary>
        /// Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin(n).
        /// Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin.
        /// Kullanıcının girmiş olduğu sayılardan çift olanlar console'a yazdırın.
        /// </summary>
        public static void SoruBir()
        {
            int N = PozitifSayiGiris();
            int[] SayiListesi = new int[N];
            Console.WriteLine($"Listeye {N} Adet Sayı Girişi Yapınız.");
            for (int i = 0; i < N; i++) SayiListesi[i] = PozitifSayiGiris();
            Console.Write("Çift Sayilar: ");
            for (int i = 0; i < SayiListesi.Length; i++)
                if (SayiListesi[i] % 2 == 0) Console.Write($"{SayiListesi[i]}\t");
        }
        #endregion

        #region SoruIki
        /// <summary>
        /// Bir konsol uygulamasında kullanıcıdan pozitif iki sayı girmesini isteyin (n, m).
        /// Sonrasında kullanıcıdan n adet pozitif sayı girmesini isteyin.
        /// Kullanıcının girmiş olduğu sayılardan m'e eşit yada tam bölünenleri console'a yazdırın.
        /// </summary>
        public static void SoruIki()
        {
            int N = PozitifSayiGiris(), M = PozitifSayiGiris();
            int[] SayiListesi = new int[N];
            Console.WriteLine($"Listeye {N} Adet Sayı Girişi Yapınız.");
            for (int i = 0; i < N; i++) SayiListesi[i] = PozitifSayiGiris();
            Console.WriteLine("M'e Eşit Veya Tam Bölünen Listesi");
            for (int i = 0; i < SayiListesi.Length; i++)
                if (SayiListesi[i] % M == 0 || SayiListesi[i] == M) Console.Write($"{SayiListesi[i]}\t");
        }
        #endregion

        #region SoruUc
        /// <summary>
        /// Bir konsol uygulamasında kullanıcıdan pozitif bir sayı girmesini isteyin (n).
        /// Sonrasında kullanıcıdan n adet kelime girmesi isteyin.
        /// Kullanıcının girişini yaptığı kelimeleri sondan başa doğru console'a yazdırın.
        /// </summary>
        public static void SoruUc()
        {
            int N = PozitifSayiGiris();
            string[] KelimeListesi = new string[N];
            Console.WriteLine($"Listeye {N} Adet Kelime Girişi Yapınız.");
            for (int i = 0; i < N; i++)
            {
                Console.Write("Bir kelime giriniz: ");
                string Kelime = Console.ReadLine();
                KelimeListesi[i] = BoslukSil(Kelime);
            }
            for (int i = KelimeListesi.Length - 1; i >= 0; i--)
                Console.WriteLine($"{i}. {KelimeListesi[i]}");
        }
        #endregion

        #region SoruDort
        /// <summary>
        /// Bir konsol uygulamasında kullanıcıdan bir cümle yazması isteyin.
        /// Cümledeki toplam kelime ve harf sayısını console'a yazdırın.
        /// </summary>
        public static void SoruDort()
        {
            Console.Write("Bir cümle giriniz: ");
            string Cumle = Console.ReadLine();
            string[] KelimeAdet = Cumle.Split(' ');
            Console.WriteLine($"Kelime Sayısı: {KelimeAdet.Length}\nHarf Sayısı: {Cumle.Length}");
        }
        #endregion

        #region Eklentiler
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
        /// Kelime girişi istendiğinde boşluk karakterini siler.
        /// </summary>
        /// <param name="Kelime">Girişi yapılan kelime.</param>
        /// <returns>Boşluksuz kelime döndürür.</returns>
        public static string BoslukSil(string Kelime)
        {
            string[] Liste = Kelime.Split(' ');
            Kelime = "";
            foreach (string kelime in Liste)
                Kelime += kelime;
            return Kelime;
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
