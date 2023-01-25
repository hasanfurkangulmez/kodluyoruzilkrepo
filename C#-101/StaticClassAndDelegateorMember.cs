using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp101
{
    internal class StaticClassAndDelegateorMember
    {
        public StaticClassAndDelegateorMember()
        {
            Console.WriteLine("Çalışan Sayısı: {0}", CalisanStatic.CalisanSayisi);
            CalisanStatic calisan = new CalisanStatic("Ayşe", "Yılmaz", "IK");
            Console.WriteLine("Çalışan Sayısı: {0}", CalisanStatic.CalisanSayisi);
            CalisanStatic calisan1 = new CalisanStatic("Deniz", "Arda", "IK");
            CalisanStatic calisan2 = new CalisanStatic("Zikriye", "Ürkmez", "IK");
            Console.WriteLine("Çalışan Sayısı: {0}", CalisanStatic.CalisanSayisi);

            Console.WriteLine("Toplama işlemi sonucu: {0}", IslemlerStatic.Topla(100, 200));
            Console.WriteLine("Çıkarma işlemi sonucu: {0}", IslemlerStatic.Cikar(400, 50));
        }
    }
    class CalisanStatic
    {
        private static int calisanSayisi;
        public static int CalisanSayisi { get => calisanSayisi; }
        private string Isim;
        private string Soyisim;
        private string Departman;

        static CalisanStatic() => calisanSayisi = 0;
        public CalisanStatic(string isim, string soyisim, string departman)
        {
            this.Isim = isim;
            this.Soyisim = soyisim;
            this.Departman = departman;
            calisanSayisi++;
        }
    }
    static class IslemlerStatic
    {
        public static long Topla(int sayi1, int sayi2) => sayi1 + sayi2;
        public static long Cikar(int sayi1, int sayi2) => sayi1 - sayi2;
    }
}
