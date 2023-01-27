using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PhoneGuide
{
    public class MyPhone : IGuideOperation
    {
        private static List<Person> Persons = new List<Person>();
        private Person PersonInfo;

        static MyPhone()
        {
            Persons.Add(new Person("Sabit", "Numara", 1));
            Persons.Add(new Person("Acil", "Servis", 112));
            Persons.Add(new Person("Polis", "İmdat", 155));
            Persons.Add(new Person("İtfaiye", "İmdat", 110));
            Persons.Add(new Person("Jandarma", "İmdat", 156));
        }

        public MyPhone()
        {
            StartMenu();
            int ContinueOkay = 1;
            do
            {
                OperationChoose(Choosed());
                Console.Write("İşlemlere devam etmek için 1 e basınız...");
                ContinueOkay = Console.ReadLine().Choose();
            } while (ContinueOkay == 1);
            Close();
        }

        private void StartMenu()
        {
            Console.WriteLine($"İşlem Listesi\n{new string('*', 50)}");
            Console.WriteLine(
                $"(1) Yeni Numara Kaydetmek\n" +
                $"(2) Varolan Numarayı Silmek\n" +
                $"(3) Varolan Numarayı Güncelleme\n" +
                $"(4) Rehberi Listelemek\n" +
                $"(5) Rehberi Arama Yapmak");
            Console.WriteLine($"{new string('*', 50)}");
        }

        private int Choosed()
        {
            Console.Write($"Lütfen yapmak istediğiniz işlemi seçiniz...");
            int Choose = Console.ReadLine().Choose();
            Console.WriteLine($"{new string('*', 50)}");
            return Choose;
        }

        private void OperationChoose(int Choosed)
        {
            switch ((Actions)Choosed)
            {
                case Actions.Register: Register(); break;
                case Actions.Delete: Delete(); break;
                case Actions.Update: Update(); break;
                case Actions.Listing: Listing(); break;
                case Actions.Search: Search(); break;
                default: Console.WriteLine("Hatalı tuşlama yapıldı!"); break;
            }
        }

        private void Close() => Environment.Exit(0);

        public void Register()
        {
            PersonInfo.Clear();
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.Write("İsim giriniz: ");
            PersonInfo.Name = Console.ReadLine().Text();
            Console.Write("Soyisim giriniz: ");
            PersonInfo.Surname = Console.ReadLine().Text();
            Console.Write("Telefon numarası giriniz: ");
            PersonInfo.PhoneNumber = Console.ReadLine().ChooseLong();
            Persons.Add(PersonInfo);
            if (Persons.Contains(PersonInfo)) Console.WriteLine($"{PersonInfo.Name} isimli kişi kaydedildi.");
            else Console.WriteLine($"{PersonInfo.Name} isimli kişi kaydedilmedi.");
            PersonInfo.Clear();
        }

        public void Delete()
        {
            PersonInfo.Clear();
            Console.WriteLine($"(2) Varolan Numarayı Silmek");
            bool OC = true;
            while (OC)
            {
                PersonInfo.Clear();
                Console.Write("İsim veya soyisime giriniz: ");
                string NameSurname = Console.ReadLine();
                Console.WriteLine($"{new string('*', 50)}");
                int Counter = 0;
                for (int i = 0; i < Persons.Count; i++)
                {
                    if (Persons[i].Name.ToLower().Contains(NameSurname.ToLower()) || Persons[i].Surname.ToLower().Contains(NameSurname.ToLower()))
                    {
                        Console.WriteLine($"{i}. Kayıt\nİsim: {Persons[i].Name}\nSoyisim: {Persons[i].Surname}\nTelefon Numarası: {Persons[i].PhoneNumber}\n{new string('*', 3)}");
                        Counter++;
                        if (Counter == 1) PersonInfo = Persons[i];
                    }
                }
                if (Counter == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı.");
                    Console.WriteLine("  * Silmeyi sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");
                    Console.Write("Seçim: ");
                    int DChoose = Console.ReadLine().Choose();
                    if (DChoose == 1) OC = false;
                    else if (DChoose == 2) OC = true;
                }
                else
                {
                    Console.Write($"{PersonInfo.Name} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                    string DeleteChoose = Console.ReadLine().Text();
                    if (DeleteChoose == "y")
                    {
                        Persons.Remove(PersonInfo);
                        if (!Persons.Contains(PersonInfo)) Console.WriteLine($"{PersonInfo.Name} isimli kişi silindi.");
                        else Console.WriteLine($"{PersonInfo.Name} isimli kişi silinemedi.");
                    }
                    else Console.WriteLine($"Silinme işlemi iptal edildi.");
                    OC = false;
                }
                PersonInfo.Clear();
            }
        }

        public void Update()
        {
            PersonInfo.Clear();
            Console.WriteLine($"(3) Varolan Numarayı Güncelleme");
            bool OC = true;
            while (OC)
            {
                PersonInfo.Clear();
                Console.Write("İsim veya soyisime giriniz: ");
                string NameSurname = Console.ReadLine();
                Console.WriteLine($"{new string('*', 50)}");
                int Counter = 0;
                for (int i = 0; i < Persons.Count; i++)
                {
                    if (Persons[i].Name.ToLower().Contains(NameSurname.ToLower()) || Persons[i].Surname.ToLower().Contains(NameSurname.ToLower()))
                    {
                        Console.WriteLine($"{i}. Kayıt\nİsim: {Persons[i].Name}\nSoyisim: {Persons[i].Surname}\nTelefon Numarası: {Persons[i].PhoneNumber}\n{new string('*', 3)}");
                        Counter++;
                        if (Counter == 1) PersonInfo = Persons[i];
                    }
                }
                if (Counter == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı.");
                    Console.WriteLine("  * Güncellemeyi sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");
                    Console.Write("Seçim: ");
                    int UChoose = Console.ReadLine().Choose();
                    if (UChoose == 1) OC = false;
                    else if (UChoose == 2) OC = true;
                }
                else
                {
                    Console.WriteLine($"{PersonInfo.Name} isimli kişi için yeni bilgileri giriniz.");
                    int Hold = Persons.IndexOf(PersonInfo);

                    Console.Write("İsim giriniz: ");
                    PersonInfo.Name = Console.ReadLine().Text();
                    Console.Write("Soyisim giriniz: ");
                    PersonInfo.Surname = Console.ReadLine().Text();
                    Console.Write("Telefon numarası giriniz: ");
                    PersonInfo.PhoneNumber = Console.ReadLine().ChooseLong();

                    Persons[Hold] = PersonInfo;

                    if (Persons.Contains(PersonInfo)) Console.WriteLine("Güncellenme işlemi tamamlandı.");
                    else Console.WriteLine("Güncellme işlemi tamamlanamadı.");
                    OC = false;
                }
                PersonInfo.Clear();
            }
        }

        public void Listing()
        {
            PersonInfo.Clear();
            Console.WriteLine($"(4) Rehberi Listelemek");
            Console.WriteLine("A-Z için (1)");
            Console.WriteLine("Z-A için (2)");
            Console.Write("Seçim: ");
            int Choose = Console.ReadLine().Choose();
            Console.WriteLine($"{new string('*', 50)}");
            List<string> Sorting = new List<string>();
            Persons.ForEach(x => Sorting.Add(x.ToString()));
            Sorting.Sort();
            if (Choose == 1) Sorting.ForEach(az => Console.WriteLine($"İsim: {az.Split(',')[0]}\nSoyisim: {az.Split(',')[1]}\nTelefon Numarası: {az.Split(',')[2]}\n{new string('*', 3)}"));
            else if (Choose == 2)
            {
                Sorting.Reverse();
                Sorting.ForEach(az => Console.WriteLine($"İsim: {az.Split(',')[0]}\nSoyisim: {az.Split(',')[1]}\nTelefon Numarası: {az.Split(',')[2]}\n{new string('*', 3)}"));
            }
            else Console.WriteLine("Hatalı giriş yapıldı.");
            PersonInfo.Clear();
        }

        public void Search()
        {
            PersonInfo.Clear();
            Console.WriteLine("(5) Rehberi Arama Yapmak");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            Console.Write("Seçim: ");
            int SearchActionChoose = Console.ReadLine().Choose();

            int Counter = 0;
            if (SearchActionChoose == 1)
            {
                Console.Write("İsim veya soyisime giriniz: ");
                PersonInfo.Name = Console.ReadLine().Text();
                Console.WriteLine($"{new string('*', 50)}");
                for (int i = 0; i < Persons.Count; i++)
                {
                    if (Persons[i].Name.ToLower().Contains(PersonInfo.Name.ToLower()) || Persons[i].Surname.ToLower().Contains(PersonInfo.Name.ToLower()))
                    {
                        Console.WriteLine($"İsim: {Persons[i].Name}\nSoyisim: {Persons[i].Surname}\nTelefon Numarası: {Persons[i].PhoneNumber}\n{new string('*', 3)}");
                        Counter++;
                    }
                }
            }
            else if (SearchActionChoose == 2)
            {
                Console.Write("Telefon numarası giriniz: ");
                PersonInfo.PhoneNumber = Console.ReadLine().ChooseLong();
                Console.WriteLine($"{new string('*', 50)}");
                for (int i = 0; i < Persons.Count; i++)
                {
                    if (Persons[i].PhoneNumber.ToString().Contains(PersonInfo.PhoneNumber.ToString()))
                    {
                        Console.WriteLine($"İsim: {Persons[i].Name}\nSoyisim: {Persons[i].Surname}\nTelefon Numarası: {Persons[i].PhoneNumber}\n{new string('*', 3)}");
                        Counter++;
                    }
                }
            }
            else Console.WriteLine("Hatalı giriş yapıldı.");
            if (Counter == 0) Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı.");
            PersonInfo.Clear();
        }
    }
    public enum Actions
    {
        Register = 1,
        Delete,
        Update,
        Listing,
        Search
    }

    public static class Extension
    {
        public static int Choose(this string Sayi)
        {
            if (Sayi.Length <= 0)
                return 0;
            else
            {
                for (int i = 0; i < Sayi.Length; i++)
                    if (!(char.IsDigit(Sayi[i])))
                        return 0;
                return int.Parse(Sayi);
            }
        }
        public static long ChooseLong(this string Sayi)
        {
            if (Sayi.Length <= 0)
                return 0;
            else
            {
                for (int i = 0; i < Sayi.Length; i++)
                    if (!(char.IsDigit(Sayi[i])))
                        return 0;
                return long.Parse(Sayi);
            }
        }
        public static string Text(this string text) => string.IsNullOrEmpty(text) ? "Tanımsız" : text;
    }
}
