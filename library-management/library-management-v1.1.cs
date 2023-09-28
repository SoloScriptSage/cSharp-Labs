using System;
using System.Collections.Generic;

namespace front {
  class Program {
    static List < Book > Books = new List < Book > ();
    static List < Article > Articles = new List < Article > ();
    static List < ElectronicResource > ElectronicResources = new List < ElectronicResource > ();

    static void Main(string[] args) {
      Interface.getDeveloperName();
      Input();
      bool t = true;
      while (t) {

        Interface.getMenu();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\tChoice: ");
        Console.ResetColor();
        int l = Int32.Parse(Console.ReadLine());
        Console.Clear();

        switch (l) {
        case 1: {
          Output();
          break;
        }
        case 2: {
          Search();
          break;
        }
        case 3: {
          break;
        }
        case 0: {
          t = false;
          Interface.getDeveloperName();
          break;
        }
        }
      }
    }
    static void Input() {
      Book FirstBook = new Book("The Richest Man in Babylon", "George S. Clason", 1926, "Penguin Books");
      Book SecondBook = new Book("Rich Dad Poor Dad", "Robert Kiyosaki and Sharon L. Lechter", 2000, "Warner Books");
      Article article = new Article("New and scandalous multimillionaire Morgenshtern", "Dr. Charles Theuer", 2021, "Forbes", 666);
      ElectronicResource electronicResource = new ElectronicResource("XCode", "SXCRED", "xcode.com", "Your security and shelter");

      Books.Add(FirstBook);
      Books.Add(SecondBook);
      Articles.Add(article);
      ElectronicResources.Add(electronicResource);
    }
    static void Output() {
      foreach(Book book in Books) {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\tBooks: ");
        Console.ResetColor();
        Console.WriteLine(book.getInfo());
      }

      foreach(Article article in Articles) {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\tArticles: ");
        Console.ResetColor();
        Console.WriteLine(article.getInfo());
      }

      foreach(ElectronicResource electronicResource in ElectronicResources) {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("   ElectronicResources: ");
        Console.ResetColor();

        Console.WriteLine(electronicResource.getInfo());
      }
    }
    static void Search() {
      Console.Write("Input author: ");
      string Value = Console.ReadLine();

      foreach(Book book in Books) {
        if (book.getAuthor() == Value) {
          Console.WriteLine(book.getInfo());
        }
      }
      foreach(Article article in Articles) {
        if (article.getAuthor() == Value) {
          Console.WriteLine(article.getInfo());
        }
      }
      foreach(ElectronicResource electronicResource in ElectronicResources) {
        if (electronicResource.getAuthor() == Value) {
          Console.WriteLine(electronicResource.getInfo());
        }
      }
    }
  }
  class Publisher {

    protected string Name;
    protected string Author;
    protected int PublishingYear;
    public Publisher(string name, string author) {
      Name = name;
      Author = author;
    }
    public string getAuthor() {
      return Author;
    }

    public string getInfo() {
      return $ "|---------------------------| \n Name: {Name}; \n Author: {Author}";
    }
  }
  class Book: Publisher {
    protected string Publicist;
    public Book(string name, string author, int year, string publicist): base(name, author) {
      PublishingYear = year;
      Publicist = publicist;
    }
    public new string getInfo() {
      return $ "{base.getInfo()} \n Publishing year: {PublishingYear}; \n Publicist: {Publicist} \n|---------------------------|";
    }
  }
  class Article: Publisher {
    protected string MagazineName;
    protected int MagazineNumber;
    public Article(string name, string author, int year, string magazineName, int magazineNumber): base(name, author) {
      PublishingYear = year;
      MagazineName = magazineName;
      MagazineNumber = magazineNumber;
    }
    public new string getInfo() {
      return $ "{base.getInfo()} \n Publishing year: {PublishingYear}; \n MagazineName: {MagazineName}; \n MagazineNumber: {MagazineNumber} \n|---------------------------|";
    }
  }
  class ElectronicResource: Publisher {
    protected string Link;
    protected string Anotation;
    public ElectronicResource(string name, string author, string link, string anotation): base(name, author) {
      Link = link;
      Anotation = anotation;
    }
    public new string getInfo() {
      return $ "{base.getInfo()} \n Link: {Link}; \n Anotation: {Anotation} \n|---------------------------|";
    }

  }
  class Interface {
    public static void getMenu() {
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("\tMENU");
      Console.WriteLine("\t1. Show all");
      Console.WriteLine("\t2. Search");
      Console.WriteLine("\t3. Clear console");
      Console.WriteLine("\t0. Exit");
      Console.WriteLine("|---------------------------|");
    }
    public static void getDeveloperName() {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("made by Vladislav Girchuk\n");
      Console.ResetColor();
    }
  }

}
