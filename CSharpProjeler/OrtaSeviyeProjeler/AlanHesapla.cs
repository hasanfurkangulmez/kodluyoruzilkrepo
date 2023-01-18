using PatikaDev.CSharpProjeler.KolaySeviyeProjeler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.OrtaSeviyeProjeler
{
    public class AlanHesapla
    {
        /// <summary>
        /// Değişkene girilen karakterin sayı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="Sayi">Girişi yapılan sayı.</param>
        /// <returns>Girilen sayıyı geri döndürür.</returns>
        public static int SayiMi(string Sayi)
        {
            if (Sayi.Length <= 0) return -1;
            else
            {
                for (int i = 0; i < Sayi.Length; i++) if (!char.IsDigit(Sayi[i])) return -1;
                return int.Parse(Sayi);
            }
        }

        List<string> Sekiller = new List<string> { "Daire", "Üçgen", "Kare", "Dikdörtgen" };
        List<string> Islemler = new List<string> { "Alan", "Çevre", "Hacim" };
        public AlanHesapla()
        {
            Console.WriteLine($"Alan Hesaplama Sistemi\n{new string('-', 50)}");

            Console.WriteLine($"Şekiller\n{new string('-', 20)}");
            Sekiller.ForEach(x => Console.WriteLine($"{Sekiller.IndexOf(x)}. {x}"));

            Console.WriteLine($"{new string('-', 20)}\nİşlemler\n{new string('-', 20)}");
            Islemler.ForEach(x => Console.WriteLine($"{Islemler.IndexOf(x)}. {x}"));

            Console.WriteLine(new string('-', 20));

            bool Kontrol = true;
            while (Kontrol)
            {
                SecimYap();
                Console.Write("Devam etmek için '1' e, çıkış yapmak için herhangi bir tuşa basabilirsiniz.");
                if (Console.ReadLine() != "1") Kontrol = false;
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine("Progmram sonlandırılıyor...");
            Environment.Exit(0);
        }
        public void SecimYap()
        {
            Console.Write("Seçmek istediğiniz şeklin numarasını giriniz: ");
            int SecilenSekil = SayiMi(Console.ReadLine());

            Console.Write("Seçmek istediğiniz işlemin numarasını giriniz: ");
            int SecilenIslem = SayiMi(Console.ReadLine());

            Console.WriteLine(new string('-', 50));

            switch (SecilenSekil)
            {
                case 0: Console.WriteLine($"{new Daire(SecilenIslem).ToString()}\n{new string('-', 50)}"); break;
                case 1: Console.WriteLine($"{new Ucgen(SecilenIslem)}\n{new string('-', 50)}"); break;
                case 2: Console.WriteLine($"{new Kare(SecilenIslem)}\n{new string('-', 50)}"); break;
                case 3: Console.WriteLine($"{new Dikdortgen(SecilenIslem)}\n{new string('-', 50)}"); break;
                default: Console.WriteLine("Şekil bulunamadı!"); break;
            }
        }
    }
    public interface ISekil
    {
        public double Sonuc { get; set; }
        double Alan();
        double Cevre();
        double Hacim();
    }
    public class Daire : ISekil
    {
        public double YariCap { get; set; }
        public double Sonuc { get; set; }
        public Daire(int SecilenIslem)
        {
            Console.WriteLine("Şekil Tipi: Daire");
            Islem(SecilenIslem);
        }
        public void Islem(int SecilenIslem)
        {
            switch (SecilenIslem)
            {
                case 0:
                    Console.WriteLine("İşlem Tipi: Alan");
                    Console.Write("Yarıçapı: ");
                    YariCap = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Alan();
                    break;
                case 1:
                    Console.WriteLine("İşlem Tipi: Çevre");
                    Console.Write("Yarıçapı: ");
                    YariCap = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Cevre();
                    break;
                case 2:
                    Console.WriteLine("İşlem Tipi: Hacim");
                    Console.Write("Yarıçapı: ");
                    YariCap = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Hacim();
                    break;
                default:
                    Console.WriteLine("İşlem bulunamadı!");
                    break;
            }
        }
        public double Alan() => Math.Pow(YariCap, 2);
        public double Cevre() => 2 * YariCap;
        public double Hacim() => (Math.Pow(YariCap, 3) * 4) / 3;
        public override string ToString() => $"Sonuc: {Sonuc:F2}π";
    }
    public class Ucgen : ISekil
    {
        public double Yukseklik { get; set; }
        public double TYukseklik { get; set; }
        public double BKenar { get; set; }
        public double IKenar { get; set; }
        public double UKenar { get; set; }
        public double Sonuc { get; set; }
        public Ucgen(int SecilenIslem)
        {
            Console.WriteLine("Şekil Tipi: Üçgen");
            Islem(SecilenIslem);
        }
        public void Islem(int SecilenIslem)
        {
            switch (SecilenIslem)
            {
                case 0:
                    Console.WriteLine("İşlem Tipi: Alan");
                    Console.Write("Yükseklik: ");
                    TYukseklik = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Kenar: ");
                    BKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Alan();
                    break;
                case 1:
                    Console.WriteLine("İşlem Tipi: Çevre");
                    Console.Write("Kenar: ");
                    BKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Kenar: ");
                    IKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Kenar: ");
                    UKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Cevre();
                    break;
                case 2:
                    Console.WriteLine("İşlem Tipi: Hacim");
                    Console.Write("Taban Kenar: ");
                    BKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Taban Yükseklik: ");
                    TYukseklik = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Yükseklik: ");
                    Yukseklik = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Hacim();
                    break;
                default:
                    Console.WriteLine("İşlem bulunamadı!");
                    break;
            }
        }
        public double Alan() => (TYukseklik * BKenar) / 2;
        public double Cevre() => BKenar + IKenar + UKenar;
        public double Hacim() => Alan() * Yukseklik;
        public override string ToString() => $"Sonuc: {Sonuc:F2}";
    }
    public class Kare : ISekil
    {
        public double Kenar { get; set; }
        public double Sonuc { get; set; }
        public Kare(int SecilenIslem)
        {
            Console.WriteLine("Şekil Tipi: Kare");
            Islem(SecilenIslem);
        }
        public void Islem(int SecilenIslem)
        {
            switch (SecilenIslem)
            {
                case 0:
                    Console.WriteLine("İşlem Tipi: Alan");
                    Console.Write("Kenar: ");
                    Kenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Alan();
                    break;
                case 1:
                    Console.WriteLine("İşlem Tipi: Çevre");
                    Console.Write("Kenar: ");
                    Kenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Cevre();
                    break;
                case 2:
                    Console.WriteLine("İşlem Tipi: Hacim");
                    Console.Write("Kenar: ");
                    Kenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Hacim();
                    break;
                default:
                    Console.WriteLine("İşlem bulunamadı!");
                    break;
            }
        }
        public double Alan() => Math.Pow(Kenar, 2);
        public double Cevre() => 4 * Kenar;
        public double Hacim() => Math.Pow(Kenar, 3);
        public override string ToString() => $"Sonuc: {Sonuc:F2}";
    }
    public class Dikdortgen : ISekil
    {
        public double KısaKenar { get; set; }
        public double UzunKenar { get; set; }
        public double Yukseklik { get; set; }
        public double Sonuc { get; set; }
        public Dikdortgen(int SecilenIslem)
        {
            Console.WriteLine("Şekil Tipi: Dikdörtgen");
            Islem(SecilenIslem);
        }
        public void Islem(int SecilenIslem)
        {
            switch (SecilenIslem)
            {
                case 0:
                    Console.WriteLine("İşlem Tipi: Alan");
                    Console.Write("Kısa Kenar: ");
                    KısaKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Uzun Kenar: ");
                    UzunKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Alan();
                    break;
                case 1:
                    Console.WriteLine("İşlem Tipi: Çevre");
                    Console.Write("Kısa Kenar: ");
                    KısaKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Uzun Kenar: ");
                    UzunKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Cevre();
                    break;
                case 2:
                    Console.WriteLine("İşlem Tipi: Hacim");
                    Console.Write("Kısa Kenar: ");
                    KısaKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Uzun Kenar: ");
                    UzunKenar = AlanHesapla.SayiMi(Console.ReadLine());
                    Console.Write("Yükseklik: ");
                    Yukseklik = AlanHesapla.SayiMi(Console.ReadLine());
                    Sonuc = Hacim();
                    break;
                default:
                    Console.WriteLine("İşlem bulunamadı!");
                    break;
            }
        }
        public double Alan() => KısaKenar * UzunKenar;
        public double Cevre() => (KısaKenar + UzunKenar) * 2;
        public double Hacim() => KısaKenar * UzunKenar * Yukseklik;
        public override string ToString() => $"Sonuc: {Sonuc:F2}";
    }
}