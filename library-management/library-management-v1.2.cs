using System;
using System.Collections.Generic;

namespace front
{
    public class Publisher
    {
        protected string Name;
        protected string Author;
        protected int PublishingYear;
        public Publisher(string name, string author)
        {
            Name = name;
            Author = author;
        }
        public Publisher() { }
        public string getAuthor()
        {
            return Author;
        }
        public string getInfo()
        {
            return $"|---------------------------| \n Name: {Name}; \n Author: {Author}";
        }
        public void creating()
        {
            Console.Write($"Name: ");
            Name = Console.ReadLine();
            Console.Write($"Author: ");
            Author = Console.ReadLine();
        }
    }
    class Book : Publisher
    {
        protected string Publicist;
        public Book(string name, string author, int year, string publicist) : base(name, author)
        {
            PublishingYear = year;
            Publicist = publicist;
        }
        public Book() { }
        public new string getInfo()
        {
            return $"{base.getInfo()} \n Publishing year: {PublishingYear}; \n Publicist: {Publicist} \n|---------------------------|";
        }
        public void creatingNewBook()
        {
            base.creating();
            Console.Write($"PublishingYear: ");
            PublishingYear = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Publicist: ");
            Publicist = Console.ReadLine();
        }
    }
    class Article : Publisher
    {
        protected string MagazineName;
        protected int MagazineNumber;
        public Article(string name, string author, int year, string magazineName, int magazineNumber) : base(name, author)
        {
            PublishingYear = year;
            MagazineName = magazineName;
            MagazineNumber = magazineNumber;
        }
        public Article() { }
        public new string getInfo()
        {
            return $"{base.getInfo()} \n Publishing year: {PublishingYear}; \n MagazineName: {MagazineName}; \n MagazineNumber: {MagazineNumber} \n|---------------------------|";
        }
        public void creatingNewArticle()
        {
            base.creating();
            Console.Write($"Publishing Year: ");
            PublishingYear = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Magazine Name: ");
            MagazineName = Console.ReadLine();
            Console.Write($"Magazine Number: ");
            MagazineNumber = Convert.ToInt32(Console.ReadLine());
        }
    }
    class ElectronicResource : Publisher
    {
        protected string Link;
        protected string Anotation;
        public ElectronicResource(string name, string author, string link, string anotation) : base(name, author)
        {
            Link = link;
            Anotation = anotation;
        }
        public ElectronicResource() { }
        public new string getInfo()
        {
            return $"{base.getInfo()} \n Link: {Link}; \n Anotation: {Anotation} \n|---------------------------|";
        }
        public void creatingNewElectronicResource()
        {
            base.creating();
            Console.Write($"Link: ");
            Link = Console.ReadLine();
            Console.Write($"Anotation: ");
            Anotation = Console.ReadLine();
        }

    }
    class Program
    {
        static List<object> A4 = new List<object>();
        static void Main(string[] args)
        {
            Interface.getDeveloperName();
            DefaultInput();
            bool t = true;

            while (t)
            {
                Interface.getMenu();
                Interface.Choice();

                int l = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (l)
                {
                    case 1: { Output(); break; }
                    case 2: { Search(); break; }
                    case 3: { Input();  break; }
                    case 4: { break; }
                    case 0: { t = false; Interface.getDeveloperName(); break;}
                }
            }
        }
        static void DefaultInput()
        {
            Book FirstBook = new Book("The Richest Man in Babylon", "George S. Clason", 1926, "Penguin Books");
            Book SecondBook = new Book("Rich Dad Poor Dad", "Robert Kiyosaki and Sharon L. Lechter", 2000, "Warner Books");
            Article article = new Article("New and scandalous multimillionaire Morgenshtern", "Dr. Charles Theuer", 2021, "Forbes", 666);
            ElectronicResource electronicResource = new ElectronicResource("XCode", "SXCRED", "xcode.com", "Your security and shelter");

            A4.Add(FirstBook);
            A4.Add(SecondBook);
            A4.Add(article);
            A4.Add(electronicResource);
        }
        static void Input()
        {
            bool x = true;
            while (x)
            {
                Interface.FindBy();
                int l = Int32.Parse(Console.ReadLine());
                switch (l)
                {
                    case 1:
                        {
                            Book book = new Book();
                            book.creatingNewBook();
                            A4.Add(book);
                            break;
                        }
                    case 2:
                        {
                            Article article = new Article();
                            article.creatingNewArticle();
                            A4.Add(article);
                            break;
                        }
                    case 3:
                        {
                            ElectronicResource electronicResource = new ElectronicResource();
                            electronicResource.creatingNewElectronicResource();
                            A4.Add(electronicResource);
                            break;
                        }
                    case 0: { x = false;  break; }
                }
            }
        }
        static void Output()
        {
            foreach (object obj in A4)
            {
                if (obj.GetType().ToString() == "front.Book")
                {
                    Book book = (Book)obj;
                    Interface.stringBook();
                    Console.WriteLine($"{book.getInfo()}");
                }
                else if (obj.GetType().ToString() == "front.Article")
                {
                    Article article = (Article)obj;
                    Interface.stringArticle();
                    Console.WriteLine($"{article.getInfo()}");
                }
                else
                {
                    ElectronicResource electronicResource = (ElectronicResource)obj;
                    Interface.stringElectronicResource();
                    Console.WriteLine($"{electronicResource.getInfo()}");
                }
            }
        }
        static void Search()
        {
            Console.Write("Input author: ");
            string Value = Console.ReadLine();

            foreach (object obj in A4)
            {
                Book book = ((Book)obj);
                Article article = ((Article)obj);
                ElectronicResource electronicResource = ((ElectronicResource)obj);

                if (book.getAuthor().ToLower() == Value.ToLower()) 
                    Console.WriteLine(book.getInfo());
                if (article.getAuthor().ToLower() == Value.ToLower()) 
                    Console.WriteLine(article.getInfo());
                if (electronicResource.getAuthor().ToLower() == Value.ToLower())
                    Console.WriteLine(electronicResource.getInfo());
            } 
        }
    }
    class Interface
    {
        public static void getMenu()
        {
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("\tMENU");
            Console.WriteLine("\t1. Show all");
            Console.WriteLine("\t2. Search");
            Console.WriteLine("\t3. Input");
            Console.WriteLine("\t4. Clear console");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine("|---------------------------|");
        }
        public static void getDeveloperName()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("made by Vladislav Girchuk\n");
            Console.ResetColor();
        }
        public static void stringBook()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tBook: ");
            Console.ResetColor();
        }
        public static void stringArticle()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tArticle: ");
            Console.ResetColor();
        }
        public static void stringElectronicResource()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("   ElectronicResource: ");
            Console.ResetColor();
        }
        public static void FindBy()
        {
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("\tINPUT");
            Console.WriteLine("\t1. Book");
            Console.WriteLine("\t2. Article");
            Console.WriteLine("\t3. Electronic Resource");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine("|---------------------------|");
        }
        public static void Choice()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\tChoice: ");
            Console.ResetColor();
        }
    }
    
}
