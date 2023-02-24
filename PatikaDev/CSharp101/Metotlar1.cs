using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp101
{
    internal class Metotlar1
    {
        public Metotlar1()
        {
            int a = 2; int b = 3;
            Console.WriteLine(a + b);
            int sonuc = Topla(a, b);
            Console.WriteLine(sonuc);
            Metotlar ornek = new Metotlar();
            ornek.EkranaYazdir(Convert.ToString(sonuc));

            int sonuc2 = ornek.ArttirVeTopla(ref a, ref b);
            ornek.EkranaYazdir(Convert.ToString(sonuc2));
            ornek.EkranaYazdir(Convert.ToString(a + b));
        }
        static int Topla(int deger1, int deger2) => deger1 + deger2;
    }
    class Metotlar
    {
        public void EkranaYazdir(string veri) => Console.WriteLine(veri);
        public int ArttirVeTopla(ref int deger1, ref int deger2) => (deger1++) + (deger2++);
    }
}
