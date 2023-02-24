using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.KolaySeviyeProjeler
{
    public class Algoritma
    {
        public Algoritma()
        {
            string a = "3"; string.IsNullOrEmpty(a);
            Console.WriteLine("(Örnek; 'Algoritma,3') şeklinde boşluk bırakarak bir yapı girişi yapınız:");
            Alg(Console.ReadLine().Split(' '));
        }

        public static void Alg(string[] Yapi)
        {
            for (int i = 0; i < Yapi.Length; i++)
            {
                string[] Kelime = Yapi[i].Trim().Split(',');
                if (Kelime[0].Length - 1 >= Convert.ToInt32(Kelime[1]) && char.IsNumber(Convert.ToChar(Kelime[1])))
                    Console.Write($"{Kelime[0].Remove(Convert.ToInt32(Kelime[1]), 1)}\t");
                else Console.Write($"{Kelime[0]}\t");
            }
        }
    }
}
