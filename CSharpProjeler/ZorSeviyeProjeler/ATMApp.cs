using CSharp101;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharpProjeler.ZorSeviyeProjeler
{
    public class ATMApp
    {
        IBankAccount NewAccount = new ActiveAccount();
        public ATMApp()
        {
            if (NewAccount.LogIn())
            {
                int Choose = -1;
                do
                {
                    NewAccount.ShowInfo();
                    ListActions(NewAccount.EducationPayAmound, NewAccount.TaxPayAmound, NewAccount.InvoicePayAmound);
                    Choose = ChooseAction();
                    if (Choose == 0) NewAccount.Deposit(EnterAmound(out double Amound));
                    else if (Choose == 1) NewAccount.WithDraw(EnterAmound(out double Amound));
                    else if (Choose == 20) NewAccount.EducationPay(EnterAmound(out double Amound));
                    else if (Choose == 21) NewAccount.TaxPay(EnterAmound(out double Amound));
                    else if (Choose == 22) NewAccount.InvoicePay(EnterAmound(out double Amound));
                    else if (Choose == 23) continue;
                    else if (Choose == 3) NewAccount.EndOfTheDay();
                    else if (Choose == 4) NewAccount.LogOut();
                    else { }
                } while (Choose != 4);
            }
            else Console.WriteLine($"{new string('-', 60)}\nOturum Sonlandırıldı! İyi Günler...");
        }
        private void ListActions(double EducationAmound, double TaxAmound, double InvoiceAmound)
        {
            Console.WriteLine($"{new string('-', 60)}\n{new string("İŞLEMLER"),34}\n{new string('-', 60)}");
            Console.WriteLine($"0.Para Yatır");
            Console.WriteLine($"1.Para Çek");
            Console.WriteLine($"2.Ödeme Yap");
            Console.WriteLine($"\t0.Eğitim Ödemesi\t{EducationAmound,10:F2} TL");
            Console.WriteLine($"\t1.Vergi Ödemesi \t{TaxAmound,10:F2} TL");
            Console.WriteLine($"\t2.Fatura Ödemesi\t{InvoiceAmound,10:F2} TL");
            Console.WriteLine($"\t3.Geri Dön");
            Console.WriteLine($"3.Gün Sonu Al");
            Console.WriteLine($"4.Çıkış Yap");
            Console.WriteLine(new string('-', 60));
        }
        private int ChooseAction()
        {

            string Choose;
            int Counter = 0;
        Repeat:
            Console.Write("İşlem Seçiniz: ");
            Choose = Console.ReadLine();
            if (Choose == "0") return 0;
            else if (Choose == "1") return 1;
            else if (Choose == "2")
            {
                Counter = 0;
                do
                {

                    Console.Write("Alt İşlem Seçiniz: ");
                    Choose = Console.ReadLine();
                    if (Choose == "0") return 20;
                    else if (Choose == "1") return 21;
                    else if (Choose == "2") return 22;
                    else if (Choose == "3") return 23;
                    else
                    {
                        Counter++;
                        Console.WriteLine($"Geçersiz tuşlama yapıldı. Lütfen Tekrar Deneyiniz...\nKalan giriş hakkı: {3 - Counter}");
                        if (Counter == 3) return 23;
                    }
                } while (Counter < 3);
                return 23;
            }
            else if (Choose == "3") return 3;
            else if (Choose == "4") return 4;
            else
            {
                Counter++;
                Console.WriteLine($"Geçersiz tuşlama yapıldı. Lütfen Tekrar Deneyiniz...\nKalan giriş hakkı: {3 - Counter}");
                if (Counter < 3) goto Repeat;
                else return 4;
            }
        }
        private double EnterAmound(out double Amound)
        {
            Console.Write("Miktar Giriniz: ");
            double RealAmound = double.TryParse(Console.ReadLine(), out double result) ? Math.Abs(result) : 0;
            Amound = RealAmound;
            Console.WriteLine($"{new string('-', 60)}");
            return Amound;
        }
    }

    public struct AccountInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public double EducationPayAmound { get; set; }
        public double TaxPayAmound { get; set; }
        public double InvoicePayAmound { get; set; }
        public AccountInfo(int ID, string Name, string Password, double Balance, double EducationPayAmound, double TaxPayAmound, double InvoicePayAmound)
        {
            this.ID = ID;
            this.Name = Name;
            this.Password = Password;
            this.Balance = Balance;
            this.EducationPayAmound = EducationPayAmound;
            this.TaxPayAmound = TaxPayAmound;
            this.InvoicePayAmound = InvoicePayAmound;
        }
        public bool Clear()
        {
            ID = -1;
            Name = null;
            Password = null;
            Balance = 0;
            EducationPayAmound = 0;
            TaxPayAmound = 0;
            InvoicePayAmound = 0;
            if (ID == -1 && Name == null && Password == null && Balance == 0 && EducationPayAmound == 0 && TaxPayAmound == 0 && InvoicePayAmound == 0) return true;
            else return false;
        }
        public override string ToString() => ID + "," + Name + "," + Password + "," + Balance + "," + EducationPayAmound + "," + TaxPayAmound + "," + InvoicePayAmound;
    }

    public interface IBankAccount
    {
        public int ID { get => ID; set => ID = value; }
        public string Name { get => Name; set => Name = value; }
        public string Password { get => Password; set => Password = value; }
        public double Balance { get => Balance; set => Balance = value; }
        public double EducationPayAmound { get => EducationPayAmound; set => EducationPayAmound = value; }
        public double TaxPayAmound { get => TaxPayAmound; set => TaxPayAmound = value; }
        public double InvoicePayAmound { get => TaxPayAmound; set => TaxPayAmound = value; }
        bool LogIn();
        void ShowInfo();
        bool LogOut();
        bool Deposit(double Amound);
        bool WithDraw(double Amound);
        bool EducationPay(double Amound);
        bool TaxPay(double Amound);
        bool InvoicePay(double Amound);
        void CreateLogFile();
        void SaveToLog(string LogDescription);
        void EndOfTheDay();
    }

    public class ActiveAccount : IBankAccount
    {
        static List<AccountInfo> Accounts = new List<AccountInfo>();
        AccountInfo Account;
        public int ID { get => Account.ID; set => Account.ID = value; }
        public string Name { get => Account.Name; set => Account.Name = value; }
        public string Password { get => Account.Password; set => Account.Password = value; }
        public double Balance { get => Account.Balance; set => Account.Balance = value; }
        public double EducationPayAmound { get => Account.EducationPayAmound; set => Account.EducationPayAmound = value; }
        public double TaxPayAmound { get => Account.TaxPayAmound; set => Account.TaxPayAmound = value; }
        public double InvoicePayAmound { get => Account.InvoicePayAmound; set => Account.InvoicePayAmound = value; }

        static ActiveAccount()
        {
            Accounts.Add(new AccountInfo(0, "Tanımsız", "123456", 0.00, 0.00, 0.00, 0.00));
            Accounts.Add(new AccountInfo(1, "Ali", "Ali123", new Random().Next(50, 100000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble()));
            Accounts.Add(new AccountInfo(2, "Ayşe", "Ay123", new Random().Next(50, 100000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble()));
            Accounts.Add(new AccountInfo(3, "Buse", "123Buse", new Random().Next(50, 100000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble()));
            Accounts.Add(new AccountInfo(4, "Melike", "123Mel456", new Random().Next(50, 100000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble(), new Random().Next(50, 10000) + new Random().NextDouble()));
        }

        public ActiveAccount()
        {
            Console.WriteLine($"{new string('-', 60)}\n{new string("GİRİŞ YAP"),35}\n{new string('-', 60)}");
        }

        public bool LogIn()
        {
            bool LC = false;
            int Counter = 0;
            do
            {
                Console.Write("Ad Giriniz: ");
                string Name = Console.ReadLine();
                foreach (AccountInfo User in Accounts)
                {
                    if (User.Name == Name)
                    {
                        this.ID = User.ID;
                        this.Name = User.Name;
                        this.Balance = User.Balance;
                        this.EducationPayAmound = User.EducationPayAmound;
                        this.TaxPayAmound = User.TaxPayAmound;
                        this.InvoicePayAmound = User.InvoicePayAmound;
                        Counter = 3;
                        CreateLogFile();
                        break;
                    }
                    else if (Accounts.IndexOf(User) == Accounts.Count - 1)
                    {
                        Counter++;
                        Console.WriteLine($"Hesap bulunamadı! Kalan giriş hakkı: {3 - Counter}");
                        if (Counter == 3) return false;
                    }
                }
            } while (Counter < 3);
            Counter = 0;
            do
            {
                Console.Write("Parola Giriniz: ");
                string Password = Console.ReadLine();
                foreach (AccountInfo User in Accounts)
                {
                    if (User.Name == this.Name && User.Password == Password)
                    {
                        this.Password = User.Password;
                        Counter = 3;
                        LC = true;
                        SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> Hesap girişi gerçekleştirildi.");
                        break;
                    }
                    else if (Accounts.IndexOf(User) == Accounts.Count - 1)
                    {
                        Counter++;
                        Console.WriteLine($"Hatalı parola! Kalan giriş hakkı: {3 - Counter}");
                        SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> Hatalı parola girişi gerçekleştirildi.");
                        if (Counter == 3) if (LogOut()) return false;
                    }
                }
            } while (Counter < 3);
            return LC;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{new string('-', 60)}\n{new string("HESAP BİLGİLERİ"),38}\n{new string('-', 60)}");
            Console.WriteLine($"Müşteri Numarası:\t{ID,15}");
            Console.WriteLine($"Müşteri Adı:\t\t{Name,15}");
            Console.WriteLine($"Müşteri Bakiye:\t\t{Balance,12:F2} TL");
            Console.WriteLine($"{new string('-', 60)}");
        }

        public bool LogOut()
        {
            Console.WriteLine($"{new string('-', 60)}\nOturum Sonlandırıldı! İyi Günler...");
            SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> Hesaptan çıkış gerçekleştirildi.");
            return Account.Clear();
        }

        public bool Deposit(double Amound)
        {
            Balance += Amound;
            Accounts[ID] = Account;
            SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaba para yatırma işlemi gerçekleştirildi.");
            return Accounts[ID].ToString() == Account.ToString();
        }

        public bool WithDraw(double Amound)
        {
            if (Balance >= Amound)
            {
                Balance -= Amound;
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan para çekme işlemi gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan para çekme işlemi gerçekleştirilemedi.");
            }
            Accounts[ID] = Account;
            return Accounts[ID].ToString() == Account.ToString();
        }

        public bool EducationPay(double Amound)
        {
            if (Balance >= Amound && Amound <= EducationPayAmound)
            {
                Balance -= Amound;
                EducationPayAmound -= Amound;
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Eğitim Ödemesi gerçekleştirildi.");
            }
            else if (Amound > EducationPayAmound)
            {
                Console.WriteLine("Geçersiz bakiye girişi. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Eğitim Ödemesi gerçekleştirilemedi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Eğitim Ödemesi gerçekleştirilemedi.");
            }
            Accounts[ID] = Account;
            return Accounts[ID].ToString() == Account.ToString();
        }

        public bool TaxPay(double Amound)
        {
            if (Balance >= Amound && Amound <= TaxPayAmound)
            {
                Balance -= Amound;
                TaxPayAmound -= Amound;
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Vargi Ödemesi gerçekleştirildi.");
            }
            else if (Amound > TaxPayAmound)
            {
                Console.WriteLine("Geçersiz bakiye girişi. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Vargi Ödemesi gerçekleştirilemedi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Vargi Ödemesi gerçekleştirilemedi.");
            }
            Accounts[ID] = Account;
            return Accounts[ID].ToString() == Account.ToString();
        }

        public bool InvoicePay(double Amound)
        {
            if (Balance >= Amound && Amound <= InvoicePayAmound)
            {
                Balance -= Amound;
                InvoicePayAmound -= Amound;
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Fatura Ödemesi gerçekleştirildi.");
            }
            else if (Amound > InvoicePayAmound)
            {
                Console.WriteLine("Geçersiz bakiye girişi. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Fatura Ödemesi gerçekleştirilemedi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi!");
                SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> {Amound:F2}TL -> Hesaptan Fatura Ödemesi gerçekleştirilemedi.");
            }
            Accounts[ID] = Account;
            return Accounts[ID].ToString() == Account.ToString();
        }

        public void CreateLogFile()
        {
            bool Control = File.Exists(PhysicalRoad());
            if (!Control)
            {
                FileStream FS = File.Create(PhysicalRoad());
                FS.Close();
                SaveToLog($"{DateTime.Now.ToString()} -> ID -> NAME -> BALANCE -> EDUCATIONPAYAMOUND -> TAXPAYAMOUND -> INVOICEPAYAMOUND -> PROCESSAMOUND -> Hesap LOG oluşturuldu.");
            }
        }

        public void SaveToLog(string LogDescription)
        {
            StreamReader SR = new StreamReader(PhysicalRoad());
            string Data = SR.ReadToEnd();
            SR.Close();
            StreamWriter SW = new StreamWriter(PhysicalRoad());
            SW.WriteLine(Data + LogDescription);
            SW.Close();
        }

        public void EndOfTheDay()
        {
            SaveToLog($"{DateTime.Now.ToString()} -> {ID} -> {Name} -> {Balance:F2}TL -> {EducationPayAmound:F2}TL -> {TaxPayAmound:F2}TL -> {InvoicePayAmound:F2}TL -> Hesap Gün Sonu işlemi gerçekleştirildi.");
            StreamReader SR = new StreamReader(PhysicalRoad());
            string Data = SR.ReadToEnd();
            SR.Close();
            Console.WriteLine($"{new string('-', 60)}\n{new string("GÜN SONU KAYDI"),37}\n{new string('-', 60)}\n{Data}\n{new string('-', 60)}");
        }

        ~ActiveAccount()
        {
            Console.WriteLine($"{new string('-', 60)}\nOturum Sonlandırıldı! İyi Günler...");
        }

        public string PhysicalRoad()
        {
            //Dynamic Road Definition
            string[] DirectoryRoad = Directory.GetCurrentDirectory().Split('\\');
            string FileRoad = "";
            for (int i = 0; i < DirectoryRoad.Length - 3; i++)
                FileRoad += DirectoryRoad[i] + '\\';
            FileRoad += this.Name + DateTime.Now.ToString("ddMMyyy") + ".txt";
            return FileRoad;
        }
    }
}
