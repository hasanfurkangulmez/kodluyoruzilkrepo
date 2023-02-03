using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaDev.CSharp101.ToDoApps
{
    public class ToDoApp
    {
        public ToDoApp()
        {
            int Choose = 0;
            do
            {
                Choose = TransactionList();
                if (Choose == 1) Boards.List();
                else if (Choose == 2)
                {
                    if (Boards.Add(DefineCard())) Console.WriteLine("Kart Eklendi!");
                    else Console.WriteLine("Kart Eklenemedi!");
                }
                else if (Choose == 3)
                {
                UpdateRetry:
                    Search(out int CardID);
                    if (CardID == -1)
                    {
                        if (!OkayContinue())
                            goto UpdateRetry;
                    }
                    else
                    {
                        Boards.CardShow(CardID);
                        Console.WriteLine("Yeni verileri giriniz.");
                        Boards.Update(CardID, DefineCard());
                    }
                }
                else if (Choose == 4)
                {
                RemoveRetry:
                    Search(out int CardID);
                    if (CardID == -1)
                    {
                        if (!OkayContinue())
                            goto RemoveRetry;
                    }
                    else
                    {
                        Boards.CardShow(CardID);
                        Console.Write("Silme işlemini onaylıyorsanız y, istemiyorsanız herhangi bir tuşa basınız:");
                        string ChooseRemove = Console.ReadLine().Trim();
                        if (ChooseRemove == "y" || ChooseRemove == "Y") Boards.Remove(CardID);
                        else Console.WriteLine("Silme işlemi gerçekleştirilmedi!");
                    }
                }
                else if (Choose == 5)
                {
                RemoveRetry:
                    Search(out int CardID);
                    if (CardID == -1)
                    {
                        if (!OkayContinue())
                            goto RemoveRetry;
                    }
                    else
                    {
                        Boards.CardShow(CardID);
                        ListLine();
                        Console.Write("Taşımak istediğiniz line'ı seçiniz: ");
                        int LineID = 0;
                        do
                        {
                            Console.Write("Line ID Giriniz                                : ");
                            LineID = int.TryParse(Console.ReadLine().Trim(), out int results) ? (results > 0 && results < 4) ? results : 0 : 0;
                            if (LineID == 0) Console.WriteLine("Hatalı Giriş!");
                        } while (LineID == 0);
                        if (Boards.LineMove(CardID, LineID)) Console.WriteLine("Taşıma işlemi başarılı.");
                        else Console.WriteLine("Taşıma işlemi başarısız.");
                    }
                }
                else if (Choose == 6)
                {
                    Console.WriteLine(new string('-', 50) + "\nUygulama Sonlandırılıyor...");
                    Environment.Exit(0);
                }
                else Console.WriteLine("Hatalı Giriş!");
            } while (Choose != 6);
        }
        public int TransactionList()
        {
            int Choose = 0;
            do
            {
                Console.Write($"{new string('-', 50)}\n" +
                $"1. Board Listele\n" +
                $"2. Kart Ekle\n" +
                $"3. Kart Güncelle\n" +
                $"4. Kart Sil\n" +
                $"5. Kart Taşı\n" +
                $"6. Çıkış Yap\n" +
                $"{new string('-', 50)}\n" +
                $"İşlem Seç: ");
                Choose = int.TryParse(Console.ReadLine().Trim(), out int result) ? (result > 0 && result < 7) ? result : 0 : 0;
                if (Choose == 0) Console.WriteLine("Hatalı Giriş!");
            } while (Choose == 0);
            return Choose;
        }
        public void ListMember()
        {
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"\tTakım Üyeleri\n{new string('-', 25)}");
            foreach (var Member in Boards.TeamMembers) Console.WriteLine(Member.Key + ". " + Member.Value);

            Console.WriteLine(new string('-', 50));
        }
        public void ListLine()
        {
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"\tLines\n{new string('-', 25)}\n1. To Do Line\n2. In Progress Line\n3. Done Line");

            Console.WriteLine(new string('-', 50));
        }
        public Card DefineCard()
        {
            Card DefinedCard = new Card();// new();
            DefinedCard.Clear();
            ListMember();
            ListLine();
            Console.WriteLine(new string('-', 50));
            int FC = -1;
            do
            {
                Console.Write("Başlık Giriniz                                 : ");
                DefinedCard.Title = Console.ReadLine();
                FC = Boards.FindTitle(DefinedCard.Title);
                if (string.IsNullOrEmpty(DefinedCard.Title) || string.IsNullOrWhiteSpace(DefinedCard.Title)) Console.WriteLine("Hatalı Giriş!");
                else if (FC != -1) Console.WriteLine("Bu başlık daha önce kullanılmıştır.");
            } while (string.IsNullOrEmpty(DefinedCard.Title) || string.IsNullOrWhiteSpace(DefinedCard.Title) || FC != -1);

            do
            {
                Console.Write("İçerik Giriniz                                 : ");
                DefinedCard.Content = Console.ReadLine();
                if (string.IsNullOrEmpty(DefinedCard.Content) || string.IsNullOrWhiteSpace(DefinedCard.Content)) Console.WriteLine("Hatalı Giriş!");
            } while (string.IsNullOrEmpty(DefinedCard.Content) || string.IsNullOrWhiteSpace(DefinedCard.Content));

            do
            {
                Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5) : ");
                DefinedCard.SizeID = int.TryParse(Console.ReadLine().Trim(), out int result) ? (result > 0 && result < 6) ? result : 0 : 0;
                if (DefinedCard.SizeID == 0) Console.WriteLine("Hatalı Giriş!");
            } while (DefinedCard.SizeID == 0);

            do
            {
                Console.Write("Kişi ID Giriniz                                : ");
                DefinedCard.MemberID = int.TryParse(Console.ReadLine().Trim(), out int results) ? (results >=0 && results < Boards.TeamMembers.Count) ? results : -1 : -1;
                if (DefinedCard.MemberID == -1) Console.WriteLine("Hatalı Giriş!");
            } while (DefinedCard.MemberID == -1);

            do
            {
                Console.Write("Line ID Giriniz                                : ");
                DefinedCard.LineID = int.TryParse(Console.ReadLine().Trim(), out int results) ? (results > 0 && results < 4) ? results : 0 : 0;
                if (DefinedCard.LineID == 0) Console.WriteLine("Hatalı Giriş!");
            } while (DefinedCard.LineID == 0);

            Console.WriteLine(new string('-', 50));
            return DefinedCard;
        }
        public void Search(out int CardID)
        {
            string Title = null;
            do
            {
                Console.Write("Kart Başlığı Giriniz : ");
                Title = Console.ReadLine();
                if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title)) Console.WriteLine("Hatalı Giriş!");
            } while (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title));
            CardID = Boards.FindCard(Title);
        }
        public bool OkayContinue()
        {
            int Choose = 0;
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı.");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("1. İşlemi Sonlandır");
            Console.WriteLine("2. Yeniden Dene");
            do
            {
                Console.Write("İşlem Seç : ");
                Choose = int.TryParse(Console.ReadLine().Trim(), out int result) ? (result > 0 && result < 3) ? result : 0 : 0;
                if (Choose == 0) Console.WriteLine("Hatalı Giriş!");
            } while (Choose == 0);
            Console.WriteLine(new string('-', 50));
            if (Choose == 1) return true;
            else return false;
        }
    }
    public static class Boards
    {
        public static Dictionary<int, string> TeamMembers = new Dictionary<int, string>();
        public static List<Card> Board = new List<Card>();
        static Boards()
        {
            TeamMembers.Add(0, "Ali");
            TeamMembers.Add(1, "Ayşe");
            TeamMembers.Add(2, "Buğra");
            TeamMembers.Add(3, "Buse");
            TeamMembers.Add(4, "Mehmet");
            TeamMembers.Add(5, "Melike");

            Board.Add(new Card("Başlık  1", "İçerik 1", 1, 0, 1));
            Board.Add(new Card("Başlık  2", "İçerik 2", 2, 1, 1));
            Board.Add(new Card("Başlık  3", "İçerik 3", 3, 2, 1));
            Board.Add(new Card("Başlık  4", "İçerik 4", 4, 3, 1));
            Board.Add(new Card("Başlık  5", "İçerik 5", 5, 4, 1));
            Board.Add(new Card("Başlık  6", "İçerik 6", 1, 5, 1));

            Board.Add(new Card("Başlık  7", "İçerik 1", 1, 0, 2));
            Board.Add(new Card("Başlık  8", "İçerik 2", 2, 1, 2));
            Board.Add(new Card("Başlık  9", "İçerik 3", 3, 2, 2));
            Board.Add(new Card("Başlık 10", "İçerik 4", 4, 3, 2));
            Board.Add(new Card("Başlık 11", "İçerik 5", 5, 4, 2));
            Board.Add(new Card("Başlık 12", "İçerik 6", 1, 5, 2));

            Board.Add(new Card("Başlık 13", "İçerik 1", 1, 0, 3));
            Board.Add(new Card("Başlık 14", "İçerik 2", 2, 1, 3));
            Board.Add(new Card("Başlık 15", "İçerik 3", 3, 2, 3));
            Board.Add(new Card("Başlık 16", "İçerik 4", 4, 3, 3));
            Board.Add(new Card("Başlık 17", "İçerik 5", 5, 4, 3));
            Board.Add(new Card("Başlık 18", "İçerik 6", 1, 5, 3));
        }
        public static bool Add(Card Card)
        {
            Board.Add(Card);
            return Board.Contains(Card);
        }
        public static bool Remove(int CardID) => Board.Remove(Board[CardID]);
        public static bool Update(int CardID, Card Card)
        {
            Board[CardID] = Card;
            return Board.Contains(Card);
        }
        public static bool LineMove(int CardID, int NewLineID)
        {
            Board[CardID].LineID = NewLineID;
            return Board[CardID].LineID == NewLineID;
        }
        public static void CardShow(int CardID)
        {
            Console.WriteLine(
                $"ID          : {CardID}\n" +
                $"Başlık      : {Board[CardID].Title}\n" +
                $"İçerik      : {Board[CardID].Content}\n" +
                $"Atanan Kişi : {TeamMembers[Board[CardID].MemberID]}\n" +
                $"Büyüklük    : {(Sizes)Board[CardID].SizeID}\n" +
                $"Line        : {(Lines)Board[CardID].LineID}\n");
        }
        public static void CardShow(Card Card)
        {
            Console.WriteLine(
                $"ID          : {Board.IndexOf(Card)}\n" +
                $"Başlık      : {Card.Title}\n" +
                $"İçerik      : {Card.Content}\n" +
                $"Atanan Kişi : {TeamMembers[Card.MemberID]}\n" +
                $"Büyüklük    : {(Sizes)Card.SizeID}\n" +
                $"Line        : {(Lines)Card.LineID}\n");
        }
        public static void List()
        {
            Console.WriteLine($"{new string('-', 50)}");
            Console.WriteLine($"\tTo Do Line\n{new string('-', 35)}");
            foreach (Card card in Board) if (card.LineID == 1) CardShow(Board.IndexOf(card));
            Console.WriteLine($"{new string('-', 35)}\n\tIn Progress Line\n{new string('-', 35)}");
            foreach (Card card in Board) if (card.LineID == 2) CardShow(Board.IndexOf(card));
            Console.WriteLine($"{new string('-', 35)}\n\tDone Line\n{new string('-', 35)}");
            foreach (Card card in Board) if (card.LineID == 3) CardShow(Board.IndexOf(card));
            Console.WriteLine($"{new string('-', 50)}");
        }
        public static int FindCard(string CardTitle)
        {
            foreach (Card card in Board)
            {
                if (card.Title.ToString() == CardTitle.ToString()) return Board.IndexOf(card);
                else if (Board.IndexOf(card) == Board.Count - 1)
                {
                    Console.WriteLine("Aradğınız kart board'da bulunamadı!");
                    return -1;
                }
            }
            return -1;
        }
        public static int FindTitle(string CardTitle)
        {
            foreach (Card card in Board)
            {
                if (card.Title.ToString() == CardTitle.ToString()) return Board.IndexOf(card);
                else if (Board.IndexOf(card) == Board.Count - 1)
                {
                    return -1;
                }
            }
            return -1;
        }
    }

    public enum Sizes { XS = 1, S = 2, M = 3, L = 4, XL = 5 }

    public enum Lines { ToDo = 1, InProgress = 2, Done = 3 }

    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int SizeID { get; set; }
        public int MemberID { get; set; }
        public int LineID { get; set; }
        public Card() { }
        public Card(string Title, string Content, int SizeID, int MemberID, int LineID)
        {
            this.Title = Title;
            this.Content = Content;
            this.SizeID = SizeID;
            this.MemberID = MemberID;
            this.LineID = LineID;
        }
        public void Clear()
        {
            this.Title = string.Empty;
            this.Content = string.Empty;
            this.SizeID = 0;
            this.MemberID = 0;
            this.LineID = 0;
        }
        public override string ToString() => Title + "," + Content + "," + SizeID + "," + MemberID + "," + LineID;
    }
}
