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
        private int DeletingNumber;
        private string Info;
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
        public int getDeletingNumber() {
            return DeletingNumber;
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
            List Personel = new List();
            Accounts(Personel);
            List deletingindexAmount = new List();
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
        static void Add(List Personel) {
            Console.Clear();
            Staff st = new Staff();
            st.creatingNewEmployer();
            Personel.Add(st);
        }
        static void Show(List Personel) {
            Console.Clear();
            foreach(var index in Personel) {
                getInfo(index);
            }
        }
        static void Sort(List Personel) {
            Console.Clear();
            Console.WriteLine("Sort by: ");
            Interface.getBySort();
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice) {
            case 1: {
                BubbleGum(Personel);
                break;
            }
            }
        }
        static void Delete(List Personel) {
            Console.Clear();
            Console.WriteLine("Delete by: ");
            Interface.getByDelete();
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice) {
            case 1: {
                Console.WriteLine("Deleting index: ");
                int deleteIndex = Int32.Parse(Console.ReadLine());
                Personel.RemoveAt(deleteIndex);
                break;
            }
            case 2: {
                List deletingindexAmount = new List();
                Console.WriteLine("Deleting name: ");
                string deleteName = Console.ReadLine();
                foreach(var index in Personel) {
                    if (index.getName() == deleteName) deletingindexAmount.Add(Personel.IndexOf(index));
                }
                for (int index = (deletingindexAmount.Count) - 1; index >= 0; index--) {
                    Personel.RemoveAt(deletingindexAmount[index]);
                }
                break;
            }
            case 3: {
                List deletingindexAmount = new List();
                Console.WriteLine("Deleting number: ");
                int deleteNumber = Int32.Parse(Console.ReadLine());
                foreach(var index in Personel) {
                    if (index.getNumber() == deleteNumber) deletingindexAmount.Add(Personel.IndexOf(index));
                }
                for (int index = (deletingindexAmount.Count) - 1; index >= 0; index--) {
                    Personel.RemoveAt(deletingindexAmount[index]);
                }
                break;
            }
            case 4: {
                List deletingindexAmount = new List();
                Console.WriteLine("Deleting category: ");
                int deleteСategory = Int32.Parse(Console.ReadLine());
                foreach(var index in Personel) {
                    if (index.getCategory() == deleteСategory) deletingindexAmount.Add(Personel.IndexOf(index));
                }
                for (int index = (deletingindexAmount.Count) - 1; index >= 0; index--) {
                    Personel.RemoveAt(deletingindexAmount[index]);
                }
                break;
            }
            case 5: {
                List deletingindexAmount = new List();
                Console.WriteLine("Deleting number of department: ");
                int deleteNumberOfDepartment = Int32.Parse(Console.ReadLine());
                foreach(var index in Personel) {
                    if (index.getNumberDepartment() == deleteNumberOfDepartment) deletingindexAmount.Add(Personel.IndexOf(index));
                }
                for (int index = (deletingindexAmount.Count) - 1; index >= 0; index--) {
                    Personel.RemoveAt(deletingindexAmount[index]);
                }
                break;
            }
            case 6: {
                List deletingindexAmount = new List();
                Console.WriteLine("Deleting number of kids: ");
                int deleteNumberOfKids = Int32.Parse(Console.ReadLine());
                foreach(var index in Personel) {
                    if (index.getNumberKids() == deleteNumberOfKids) deletingindexAmount.Add(Personel.IndexOf(index));
                }
                for (int index = (deletingindexAmount.Count) - 1; index >= 0; index--) {
                    Personel.RemoveAt(deletingindexAmount[index]);
                }
                break;
            }
            case 7: {
                List deletingindexAmount = new List();
                foreach(var index in Personel) deletingindexAmount.Add(Personel.IndexOf(index));
                for (int index = (Personel.Count) - 1; index >= 0; index--) Personel.RemoveAt(deletingindexAmount[index]);
                break;
            }
            case 0: {
                break;
            }
            default: {
                Console.WriteLine("Delete by: ");
                Interface.getByDelete();
                choice = Int32.Parse(Console.ReadLine());
                break;
            }
            }
        }
        static void Search(List Personel) {
            Console.Clear();
            Console.WriteLine("Search: ");
            string value = Console.ReadLine();
            foreach(var index in Personel) {
                if (Convert.ToString(index.getNumber()) == value || Convert.ToString(index.getName().ToLower()) == value.ToLower() || Convert.ToString(index.getCategory()) == value || Convert.ToString(index.getNumberDepartment()) == value || Convert.ToString(index.getNumberKids()) == value) {
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
        static List BubbleGum(List Personel) {
            Staff temp = new Staff();
            for (int i = 0; i < Personel.Count(); i++) {
                for (int j = 0; j < Personel.Count() - i - 1; j++) {
                    char y = Convert.ToString(Personel[j].getName())[0];
                    char u = Convert.ToString(Personel[j + 1].getName())[0];
                    if (y > u) {
                        temp = Personel[j];
                        Personel[j] = Personel[j + 1];
                        Personel[j + 1] = temp;
                    }
                }
            }
            return Personel;
        }
        public static void Accounts(List Personel) {
            Staff account_first = new Staff(1, "Vaalera", 2, 125, 3);
            Staff account_third = new Staff(2, "Victor", 2, 126, 5);
            Staff account_second = new Staff(1, "Valera", 3, 125, 5);
            Staff account_fourth = new Staff(0, "Andrew", 1, 129, 1);
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
            Console.WriteLine("made by Vladislav Hirchuk\n");
            Console.ResetColor();
        }
    }
}
