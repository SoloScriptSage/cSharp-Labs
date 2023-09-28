using System;
using System.Collections.Generic;
using System.Linq;

namespace realing {
  class Staff {
    private int Number;
    private string Name;
    private int Category;
    private int NumberDepartment;
    private int NumberKids;

    public Staff() {}
    public Staff(int number, String name, int category, int numberDepartment, int kidsNumber) {
      Number = number;
      Name = name;
      Category = category;
      NumberDepartment = numberDepartment;
      NumberKids = kidsNumber;
    }
    public string getName() {
      return Name;
    }
    public int getNumber() {
      return Number;
    }
    public int getCategory() {
      return Category;
    }
    public int getNumberDepartment() {
      return NumberDepartment;
    }
    public int getNumberKids() {
      return NumberKids;
    }
    public string Stringmetod(int choice) {
      if (choice == 1) return getName();
      else return "nothing";
    }
    public int Intmetod(int choice) {
      if (choice == 2) return getNumber();
      if (choice == 3) return getCategory();
      if (choice == 4) return getNumberDepartment();
      if (choice == 5) return getNumberKids();
      else return 0;
    }
    public void creatingNewEmployer() {
      Console.Clear();
      Console.WriteLine($"-------------------------------");
      Console.WriteLine($"CREATING NEW EMPLOYER");
      Console.WriteLine($"-------------------------------");
      Console.WriteLine("Enter a number, name, category, number of department and number of kids");

      Number = Int32.Parse(Console.ReadLine());
      Name = Console.ReadLine();
      Category = Int32.Parse(Console.ReadLine());
      NumberDepartment = Int32.Parse(Console.ReadLine());
      NumberKids = Int32.Parse(Console.ReadLine());
    }
  }
  class Program {
    static void Main(string[] args) {
      Interface.getDeveloperName();
      List < Staff > Personel = new List < Staff > ();
      Accounts(Personel);

      int k = -1;
      while (k != 0) {

        Interface.getMenu();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\nChoice: ");
        Console.ResetColor();

        int l = Int32.Parse(Console.ReadLine());

        switch (l) {
        case 1: {

          Add(Personel);
          break;
        }
        case 2: {
          Delete(Personel);
          break;
        }
        case 3: {
          Show(Personel);
          break;
        }
        case 4: {
          Search(Personel);
          break;
        }
        case 5: {
          Sort(Personel);
          break;
        }
        case 6: {
          Console.Clear();
          break;
        }
        case 0: {
          Interface.getDeveloperName();
          k = Exit(k);
          break;
        }
        }
      }

    }
    static void Add(List < Staff > Personel) {
      Console.Clear();
      Staff st = new Staff();
      st.creatingNewEmployer();
      Personel.Add(st);
    }
    static void Show(List < Staff > Personel) {
      Console.Clear();
      foreach(var index in Personel) {
        getInfo(index);
      }
    }
    static void Sort(List < Staff > Personel) {
      Console.Clear();
      Console.WriteLine("Sort by: ");
      Interface.getBySort();
      int choice = Int32.Parse(Console.ReadLine());
      BubbleGum(Personel, choice);
    }
    static void Delete(List < Staff > Personel) {
      Console.Clear();
      Console.WriteLine("Delete: ");

      string value = Console.ReadLine();

      for (int index = (Personel.Count) - 1; index >= 0; index--) {
        if (
          Convert.ToString(Personel[index].getNumber()) == value ||
          Convert.ToString(Personel[index].getName().ToLower()) == value.ToLower() ||
          Convert.ToString(Personel[index].getCategory()) == value ||
          Convert.ToString(Personel[index].getNumberDepartment()) == value ||
          Convert.ToString(Personel[index].getNumberKids()) == value) {
          Personel.RemoveAt(index);
        }
      }
    }
    static void Search(List < Staff > Personel) {
      Console.Clear();
      Console.WriteLine("Search: ");

      string value = Console.ReadLine();

      foreach(var index in Personel) {
        if (
          Convert.ToString(index.getNumber()) == value ||
          Convert.ToString(index.getName().ToLower()) == value.ToLower() ||
          Convert.ToString(index.getCategory()) == value ||
          Convert.ToString(index.getNumberDepartment()) == value ||
          Convert.ToString(index.getNumberKids()) == value) {
          getInfo(index);
        }
      }
    }
    static void getInfo(Staff index) {
      Console.WriteLine("|---------------------------|");
      Console.WriteLine($"Number: { index.getNumber()}");
      Console.WriteLine($"Name: { index.getName()}");
      Console.WriteLine($"Category: {index.getCategory()}");
      Console.WriteLine($"Number of Department: {index.getNumberDepartment()}");
      Console.WriteLine($"Number of kids: {index.getNumberKids()}");
      Console.WriteLine("|---------------------------|");
    }
    static int Exit(int k) {
      k = 0;
      return k;
    }
    static void BubbleGum(List < Staff > Personel, int choice) {
      Staff temp = new Staff();

      for (int i = 0; i < Personel.Count(); i++) {
        for (int j = 0; j < Personel.Count() - i - 1; j++) {
          if (Personel[j].Stringmetod(choice)[0] > Personel[j + 1].Stringmetod(choice)[0] || Personel[j].Intmetod(choice) > Personel[j + 1].Intmetod(choice)) {
            temp = Personel[j];
            Personel[j] = Personel[j + 1];
            Personel[j + 1] = temp;
          }
        }
      }
    }
    public static void Accounts(List < Staff > Personel) {
      Staff account_first = new Staff(12, "Vaalera", 22, 125, 322);
      Staff account_third = new Staff(25, "Victor", 23, 126, 531);
      Staff account_second = new Staff(51, "Valera", 35, 125, 5421);
      Staff account_fourth = new Staff(50, "Andrew", 17, 129, 1551);
      Personel.Add(account_first);
      Personel.Add(account_second);
      Personel.Add(account_third);
      Personel.Add(account_fourth);
    }

  }
  class Interface {
    public static void getMenu() {
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("\tMENU");
      Console.WriteLine("\t1. Add");
      Console.WriteLine("\t2. Delete");
      Console.WriteLine("\t3. Show all");
      Console.WriteLine("\t4. Search");
      Console.WriteLine("\t5. Sort");
      Console.WriteLine("\t6. Clear console");
      Console.WriteLine("\t0. Exit");
      Console.WriteLine("|---------------------------|");
    }
    public static void getByDelete() {
      Console.WriteLine("|---------------------------|");
      Console.WriteLine("\t1. Index");
      Console.WriteLine("\t2. Name");
      Console.WriteLine("\t3. Number");
      Console.WriteLine("\t4. Category");
      Console.WriteLine("\t5. Number of Department");
      Console.WriteLine("\t6. Number of kids");
      Console.WriteLine("\t7. DELETE ALL ACCOUNTS");
      Console.WriteLine("\t0. Exit");
      Console.WriteLine("|---------------------------|");
    }
    public static void getBySort() {
      Console.WriteLine("---------------------------");
      Console.WriteLine("\t1. Name");
      Console.WriteLine("\t2. Number");
      Console.WriteLine("\t3. Category");
      Console.WriteLine("\t4. Number of Department");
      Console.WriteLine("\t5. Number of kids");
      Console.WriteLine("\t0. Exit");
      Console.WriteLine("---------------------------");
    }
    public static void getDeveloperName() {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("made by Vladislav Girchuk\n");
      Console.ResetColor();
    }
  }

}
