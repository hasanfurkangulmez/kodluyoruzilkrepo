﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp101
{
    internal class Donguler1
    {
        public Donguler1()
        {
            // Ekrandan girilen sayıya kadar olan tek sayılarını ekrana yazdır.
            Console.Write("Lütfen bir sayı giriniz: ");
            int sayac = int.Parse(Console.ReadLine());
            for (int i = 1; i <= sayac; i++)
                if (i % 2 == 1) Console.WriteLine(i);

            //1 ile 1000 arasındaki tek ve çift sayıların ken içlerinde toplamlarını ekrana yazdır.
            int tekToplam = 0;
            int ciftToplam = 0;
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 2 == 1) tekToplam += i;// tekToplam=tekToplam+i;
                else ciftToplam += i; // ciftToplam=ciftToplam+i;
            }
            Console.WriteLine("Tek Toplam: " + tekToplam);
            Console.WriteLine("Çift Toplam: " + ciftToplam);

            //break, continue
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) break;
                Console.WriteLine(i);
            }
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) continue;
                Console.WriteLine(i);
            }
            for (; ; )
            {
                
            }
        }
    }
}