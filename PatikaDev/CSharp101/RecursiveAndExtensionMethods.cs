using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp101
{
    internal class RecursiveAndExtensionMethods
    {
        public RecursiveAndExtensionMethods()
        {
            //Rekürsif - Öz yinelemeli 
            //3*4=3*3*3*3

            int result = 1;
            for (int i = 1; i < 5; i++)
                result = result * 3;
            Console.WriteLine(result);

            Islemler instance = new();
            Console.WriteLine(instance.Expo(3, 4));

            //Extension Metotlar
            string ifade = "Zikriye Ürkmez Cengiz";
            bool sonuc = ifade.CheckSpaces();
            Console.WriteLine(sonuc);
            if (sonuc)
                Console.WriteLine(ifade.RemoveWhiteSpaces());
            Console.WriteLine(ifade.MakeUpperCase());
            Console.WriteLine(ifade.MakeLowerCase());
            int[] dizi = { 9, 3, 6, 2, 1, 5, 0 };
            dizi.SortArray();
            dizi.EkranaYazdir();
            int sayi = 5;
            Console.WriteLine(sayi.IsEvenNumber());

            Console.WriteLine(ifade.GetFirstCharacter());
        }
    }
    public class Islemler
    {
        public int Expo(int sayi, int us)
        {
            if (us < 2) return sayi;
            return Expo(sayi, us - 1) * sayi;
        }
    }
    public static class Extension
    {
        public static bool CheckSpaces(this string param) => param.Contains(" ");
        public static string RemoveWhiteSpaces(this string param)
        {
            string[] dizi = param.Split(" ");
            return string.Join("", dizi);
        }

        public static string MakeUpperCase(this string param) => param.ToUpper();
        public static string MakeLowerCase(this string param) => param.ToLower();
        public static int[] SortArray(this int[] param)
        {
            Array.Sort(param);
            return param;
        }
        public static void EkranaYazdir(this int[] param)
        {
            foreach (int item in param)
                Console.WriteLine(item);
        }
        public static bool IsEvenNumber(this int param) => param % 2 == 0;
        public static string GetFirstCharacter(this string param) => param.Substring(0, 1);
    }
}
