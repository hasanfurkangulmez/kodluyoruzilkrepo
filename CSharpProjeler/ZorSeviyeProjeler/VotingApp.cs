using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.ZorSeviyeProjeler
{
    public class VotingApp
    {
        public VotingApp()
        {
            Console.WriteLine("Oylama Uygulamasına Hoşgeldiniz...");
            Console.WriteLine(new string('-', 60));
            new UserProcess();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Oylama Uygulamasına Sonlandırılıyor...");
            Environment.Exit(0);
        }
    }
    public struct User
    {
        public string Name { get; set; }
        public User(string Name) => this.Name = Name;
        public void Clear() => this.Name = null;
        public override string ToString() => Name;
    }
    public struct Category
    {
        public string Name { get; set; }
        public int Votes { get; set; }
        public Category(string Name)
        {
            this.Name = Name;
            Votes = new Random().Next(0, 50);
        }
        public void Clear()
        {
            this.Name = null;
            this.Votes = -1;
        }
        public override string ToString() => Name + "," + Votes;
    }
    public class UserProcess
    {
        static List<User> Users = new();
        User UserInfo;
        static UserProcess()
        {
            Users.Add(new User("Tanımsız"));
            Users.Add(new User("Ahmet"));
            Users.Add(new User("Ahmet Efe"));
            Users.Add(new User("Burak"));
            Users.Add(new User("Buse"));
        }
        public UserProcess()
        {
            int LR = -1;
            bool Ctrl = false;
            do
            {
                LR = LoginRegister();
                if (LR == 1) Ctrl = Login();
                else if (LR == 2)
                {
                    Ctrl = Register();
                    if (Ctrl) Ctrl = false;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş tespit edildi.");
                    Ctrl = false;
                }
            } while (!Ctrl);
            if (Ctrl) CategoryProcessing();

        }
        private int LoginRegister()
        {
            int LoginOrRegister = 0;
            do
            {
                Console.Write("Giriş yapmak için 1, kayıt olmak için 2 tuşlayınız: ");
                LoginOrRegister = Console.ReadLine().IsNumber();
                if (LoginOrRegister < 1 || LoginOrRegister > 2) Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
            } while (LoginOrRegister < 1 || LoginOrRegister > 2);
            return LoginOrRegister;
        }
        private void CategoryProcessing()
        {
            CategoryProcess.ListTheCategory();
            int VoteControl = 1;
            do
            {
                ToVote();
                CategoryProcess.ListTheCategory();
                Console.Write("Tekrar oy kullanmak için 1, oylamayı bitirmek için herhangi bir tuşa basınız: ");
                VoteControl = Console.ReadLine().IsNumber();
            } while (VoteControl == 1);
        }
        private bool Login()
        {
            Console.WriteLine($"{new string('-', 50)}\n{new string("GİRİŞ YAP"),30}\n{new string('-', 50)}");
            UserInfo.Clear();
            UserInfo = UserName();
            foreach (User user in Users)
            {
                if (user.ToString() == UserInfo.ToString()) return true;
                else if (Users.Count - 1 == Users.IndexOf(user)) Console.WriteLine("Kullanıcı bulunamadı.");
            }
            return false;
        }
        private bool Register()
        {
            bool RegisterLoopControl = true;
            do
            {
                Console.WriteLine($"{new string('-', 50)}\n{new string("KAYIT OL"),29}\n{new string('-', 50)}");
                UserInfo.Clear();
                UserInfo = UserName();
                if (Users.Contains(UserInfo)) Console.WriteLine("Bu kullanıcı adı daha önce kullanılmış.\nLütfen farklı bir kullanıcı adı giriniz...");
                else
                {
                    Users.Add(UserInfo);
                    if (Users.Contains(UserInfo))
                    {
                        Console.WriteLine("Kaydınız gerçekleşmiştir.");
                        RegisterLoopControl = false;
                    }
                    else
                    {
                        Console.WriteLine("Kaydınız gerçekleşmemiştir.\n\nLütfen farklı bir kullanıcı adı giriniz...");
                        RegisterLoopControl = true;
                    }
                }
            } while (RegisterLoopControl);
            return true;
        }
        private User UserName()
        {
            string Name;
            do
            {
                Console.Write("Kullanıcı adı giriniz: ");
                Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
                    Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
                else return new User(Name);
            } while (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name));
            return new User("Tanımsız");
        }
        private void ToVote()
        {
            int CatID = CategoryID();
            CategoryProcess.SaveTheVote(CatID, SubCategoryID(CatID));
        }
        private int CategoryID()
        {
            int ID = 0;
            do
            {
                Console.Write("Kategori seçiniz: ");
                ID = Console.ReadLine().IsNumber();
                if (ID < 0 || ID > 1) Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
            } while (ID < 0 || ID > 1);
            return ID;
        }
        private int SubCategoryID(int CatID)
        {
            int ID = 0, Limit = -1;
            if (CatID == 0) Limit = CategoryProcess.Movie.Count - 1;
            else if (CatID == 1) Limit = CategoryProcess.Sport.Count - 1;
            else Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
            do
            {
                Console.Write("Alt kategori seçiniz: ");
                ID = Console.ReadLine().IsNumber();
                if (ID < 0 || ID > Limit) Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
            } while (ID < 0 || ID > Limit);
            return ID;
        }
    }
    public static class CategoryProcess
    {
        public static List<Category> Movie = new();
        public static List<Category> Sport = new();
        static CategoryProcess()
        {
            Movie.Add(new Category("Aksiyon"));
            Movie.Add(new Category("Macera"));
            Movie.Add(new Category("Gerilim"));
            Movie.Add(new Category("Korku"));
            Movie.Add(new Category("Drama"));

            Sport.Add(new Category("Futbol"));
            Sport.Add(new Category("Basketbol"));
            Sport.Add(new Category("Voleybol"));
        }
        public static void SaveTheVote(int CategoryID, int SubCategoryID)
        {
            Category Cat = new();
            if (CategoryID == 0)
            {
                Cat = Movie[SubCategoryID];
                Cat.Votes++;
                Movie[SubCategoryID] = Cat;
                Console.WriteLine($"Film kategorisinden {Movie[SubCategoryID].Name} alt kategorisine oyunuz kaydedilmiştir...\nTeşekkür Ederiz...");
            }
            else if (CategoryID == 1)
            {
                Cat = Sport[SubCategoryID];
                Cat.Votes++;
                Sport[SubCategoryID] = Cat;
                Console.WriteLine($"Spor kategorisinden {Movie[SubCategoryID].Name} alt kategorisine oyunuz kaydedilmiştir...\nTeşekkür Ederiz...");
            }
            else Console.WriteLine("Geçersiz giriş tespit edildi.\nLütfen geçerli bir giriş yapınız...");
        }
        public static void ListTheCategory()
        {

            Console.WriteLine($"{new string('-', 50)}\n{new string("KATEGORİ"),29}\n{new string('-', 50)}");

            int SumVote = 0;
            Movie.ForEach(x => SumVote += x.Votes);
            Console.WriteLine($"0.\tFilm Kategorileri\t{SumVote,3}\tYüzdelik");
            Console.WriteLine(new string('-', 50));
            Movie.ForEach(x => Console.WriteLine($"{Movie.IndexOf(x)}.\t{x.Name,-20}\t{x.Votes,3}\t{((double)x.Votes * 100 / SumVote),6:F2}%"));
            Console.WriteLine(new string('-', 50));

            SumVote = 0;
            Sport.ForEach(x => SumVote += x.Votes);
            Console.WriteLine($"1.\tSpor Kategorileri\t{SumVote,3}\tYüzdelik");
            Console.WriteLine(new string('-', 50));
            Sport.ForEach(x => Console.WriteLine($"{Sport.IndexOf(x)}.\t{x.Name,-20}\t{x.Votes,3}\t{((double)x.Votes * 100 / SumVote),6:F2}%"));
            Console.WriteLine(new string('-', 50));
        }
    }
    public static class Extension
    {
        public static int IsNumber(this string Number)
        {
            if (string.IsNullOrEmpty(Number) || string.IsNullOrWhiteSpace(Number))
                return -1;
            else
                for (int i = 0; i < Number.Length; i++)
                    if (!(char.IsDigit(Number[i])))
                        return -1;
            return int.Parse(Number);
        }
    }
}
