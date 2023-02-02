using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLib;
using ZXing.Windows.Compatibility;

namespace PatikaDev.CSharpProjeler.ZorSeviyeProjeler
{
    internal class BarcodeGenerator
    {
        public BarcodeGenerator()
        {
            Console.WriteLine("1.Barkod Ekle\n2.Barkod Oku\n3.Çıkış");
            int? IS = 0;
            do
            {
                Console.Write("İşlem Seç: ");
                IS = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (IS == 1) BarWrite4();
                else if (IS == 2) BarReader();
                else if (IS == 3) Environment.Exit(0);
                else Console.WriteLine("Hatalı giriş!");
            } while (IS != 3);
        }
        public void BarWrite4()
        {
            Console.Write("Barkod Değeri giriniz: ");
            //string BarcodeValue = Console.ReadLine();
            int? BV = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            Console.Write("Kayıt adı giriniz: ");
            string RegistrationName = Console.ReadLine();

            Barcode barcode = new Barcode();
            barcode.Encode(TYPE.CODE128, BV.ToString());
            if (!File.Exists(RegistrationName + ".png")) barcode.SaveImage(RegistrationName + ".png", SaveTypes.PNG);

            //barcode.SaveImage(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @$"\{RegistrationName}.png", SaveTypes.PNG);
            /*Barcode barcode = new Barcode(); // new Barcode("123456",TYPE.CODE128);
            Image img = barcode.Encode(TYPE.CODE128, "123456789", Color.Black, Color.White, 290, 120);
            img.Save("Barcode.png");
            Console.WriteLine(barcode.RawData);*/
        }
        public void BarReader()
        {
            Console.Write("Dosya adı giriniz: ");
            string RegistrationName = Console.ReadLine();
            if (string.IsNullOrEmpty(RegistrationName) || string.IsNullOrWhiteSpace(RegistrationName)) Console.WriteLine("Hatalı giriş!");
            else
            {
                //BarcodeReader BR = new BarcodeReader(); //BR.Decode();
                if (File.Exists(RegistrationName + ".png"))
                    Console.WriteLine(new BarcodeReader().Decode(new Bitmap(RegistrationName + ".png")));
            }
        }
    }
}