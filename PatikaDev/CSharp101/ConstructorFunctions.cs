using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp101
{
    internal class ConstructorFunctions
    {
        public ConstructorFunctions()
        {
            //Söz Dizimi
            // class SinifAdi
            //{
            //      [Erişim Belirleyici] [Veri Tipi] OzellikAdi;
            //      [Erişim Belirleyici] [Geri Dönüş Tipi] MetotAdi([Parametre Listesi])
            //      {
            //      // metot Komutları
            //      }
            //}

            //Erişim Belirleyiciler
            // * Public : Her yerden erişilebilir.
            // * Private : Sadece tanımlandığı sınıf içerisinden erişilebilir.
            // * Internal : Sadece bulunduğu proje içerisinden erişilebilir
            // * Protected : Sadece tanımlandığı sınıfta ya da o sınıfı miras alan sınıflardan erişilebilir.

            Console.WriteLine("*****Çalışan 1*****");
            CalisanKurucu calisan1 = new CalisanKurucu("Ayşe", "Kara", 23425634, "İnsan Kaynaklari");
            calisan1.CalisanBilgileri();
            Console.WriteLine("*****Çalışan 2*****");

            CalisanKurucu calisan2 = new CalisanKurucu();
            calisan2.Ad = "Deniz";
            calisan2.Soyad = "Arda";
            calisan2.No = 25646789;
            calisan2.Departman = "Satın Alma";
            calisan2.CalisanBilgileri();

            Console.WriteLine("*****Çalışan 3*****");
            CalisanKurucu calisan3 = new CalisanKurucu("Zikriye", "Ürkmez");
            calisan3.CalisanBilgileri();
        }
    }
    class CalisanKurucu
    {
        public string Ad;
        public string Soyad;
        public int No;
        public string Departman;

        public CalisanKurucu(string ad, string soyad, int no, string departman)
        {
            Ad = ad;
            Soyad = soyad;
            No = no;
            Departman = departman;
        }
        public CalisanKurucu(string ad, string soyad)
        {
            Ad = ad;
            Soyad = soyad;
        }
        public CalisanKurucu() { }
        public void CalisanBilgileri()
        {
            Console.WriteLine("Çalışanın Adı:{0}", Ad);
            Console.WriteLine("Çalışanın Soyadı:{0}", Soyad);
            Console.WriteLine("Çalışanın Numarası:{0}", No);
            Console.WriteLine("Çalışanın Departman:{0}", Departman);
        }
    }
}
