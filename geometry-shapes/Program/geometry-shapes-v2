using System;
using System.Collections.Generic;

namespace juice
{
    class TBody
    {
        public TBody() { }
        public virtual double calcS() { return 0; }
        public virtual double calcV() { return 0; }
        public virtual string getInfo() { return $"S: {calcS()} \t V: {calcV()}"; }
    }
    class TParalelepiped : TBody
    {
        protected double A, B, C;        
        public TParalelepiped() { }
        public TParalelepiped(double a, double b, double c){
            A = a;
            B = b;
            C = c;
        }   
        public void creatingNewParalelepiped()
        {
            Console.Write("A: ");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            B = Convert.ToDouble(Console.ReadLine());
            Console.Write("C (height): ");
            C = Convert.ToDouble(Console.ReadLine());
        }
        public override double calcS() { return 2 * (A * C + B * B + A * B); }
        public override double calcV() { return A * B * C; }
        public override string getInfo() { return $"A: {A} \t B: {B} \t C: {C} \t {base.getInfo()}"; }
    }
    class TBall : TBody
    {
        protected double R;
        public TBall(double r){
            R = r;
        }
        public TBall() { }
        public void creatingNewBall()
        {
            Console.Write("Radius: ");
            R = Convert.ToDouble(Console.ReadLine());
        }
        public override double calcS() { return 4 * Math.PI * Math.Pow(R, 2); }
        public override double calcV() { return (4 / 3) * Math.PI * Math.Pow(R, 3); }
        public override string getInfo()
        {
            return $"R: {R} \t {base.getInfo()}";
        }
    }
    class Program
    {
        static List<object> Figures = new List<object>();
        static void Main(string[] args)
        {
            bool t = true;

            while (t)
            {
                Interface.getMenu();
                int l = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (l)
                {
                    case 1: { Show(); break; }
                    case 2: { Input(); break; }
                    case 3: { AddN(); break; }
                    case 4: { Figures.Clear(); break; }
                    case 5: { break; }
                    case 0: { t = false; break; }
                }
            }
        }
        static void Show()
        {
            foreach(object obj in Figures)
            {
                if(obj is TBall)
                {
                    Interface.stringBall();
                    TBall temp = (TBall)obj;
                    Console.WriteLine(temp.getInfo());
                }
            }
            foreach(object obj in Figures)
            {
                if (obj is TParalelepiped)
                {
                    Interface.stringParalelepiped();
                    TParalelepiped temp = (TParalelepiped)obj;
                    Console.WriteLine(temp.getInfo());
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n Summary of SFigures: {SummaryAllSBodies()} \n");
            Console.ResetColor();
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
                            Console.WriteLine("Ball");
                            TBall temp = new TBall();
                            temp.creatingNewBall();
                            Figures.Add(temp);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Paralelepiped");
                            TParalelepiped temp = new TParalelepiped();
                            temp.creatingNewParalelepiped();
                            Figures.Add(temp);
                            break;
                        }
                    case 0: { x = false; break; }
                }
            }
        }
        static double SummaryAllSBodies()
        {
            double Summary = new double();

            foreach (object obj in Figures)
            {
                if(obj is TBall)
                {
                    TBall temp = (TBall)obj;
                    Summary += temp.calcS();
                }
                else
                {
                    TParalelepiped temp = (TParalelepiped)obj;
                    Summary += temp.calcS();
                }
            }

            return Summary;
        }
        static void AddN()
        {
            Random random = new Random();
            Interface.stringN();
            int temp = Convert.ToInt32(Console.ReadLine());
            int balls = random.Next(0, temp - 1);
            if (balls == 0) balls = 1;
            int paralepipeds = temp - balls;

            for (double i = 0; i < balls; i++)
            {
                TBall N = new TBall(random.Next(1, 20));
                Figures.Add(N);
            }
            for (double i = 0; i < paralepipeds; i++)
            {
                TParalelepiped N = new TParalelepiped(random.Next(1, 20), random.Next(1, 20), random.Next(1, 20));
                Figures.Add(N);
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
            Console.WriteLine("\t2. Input");
            Console.WriteLine("\t3. Add N random figures");
            Console.WriteLine("\t4. Clear list");
            Console.WriteLine("\t5. Clear console");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine("|---------------------------|");
        }
        public static void getDeveloperName()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("made by Vladislav Girchuk\n");
            Console.ResetColor();
        }
        public static void stringParalelepiped()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\tParalepiped: ");
            Console.ResetColor();
        }
        public static void stringBall()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tBall: ");
            Console.ResetColor();
        }
        public static void stringN()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\tN: ");
            Console.ResetColor();
        }
        public static void FindBy()
        {
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("\tINPUT");
            Console.WriteLine("\t1. TBall");
            Console.WriteLine("\t2. TParalepiped");
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
