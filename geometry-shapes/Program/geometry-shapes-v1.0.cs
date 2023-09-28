using System;
using System.Collections.Generic;

namespace juice
{
    class TBody
    {
        protected double S, V;
        public TBody() { }
        public virtual string getInfo() { return $"S: {S} \n V: {V}"; }
    }
    class TParalelepiped : TBody
    {
        protected double A;
        protected double B;
        protected double C;
        public TParalelepiped(double a, double b, double c){
            A = a;
            B = b;
            C = c;

            S = SReturner(A, B, C);
            V = VReturner(A, B, C);
        }
        public TParalelepiped() { }

        public void creatingNewParalelepiped()
        {
            Console.Write("A: ");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            B = Convert.ToDouble(Console.ReadLine());
            Console.Write("C: ");
            C = Convert.ToDouble(Console.ReadLine());

            S = SReturner(A, B, C);
            V = VReturner(A, B, C);
        }
        public double SReturner(double A, double B, double C)
        {
            return 2 * (A * C + B * B + A * B);
        }
        public double VReturner(double A, double B, double C)
        {
            return A * B * C;
        }
        public override string getInfo()
        {
            return $"A: {A} \n B: {B} \n C: {C} \n {base.getInfo()}";
        }
    }
    class TBall : TBody
    {
        static public double R;
        public TBall(double r){
            R = r;
            S = 4 * Math.PI * Math.Pow(R, 2);
            V = (4 / 3) * Math.PI * Math.Pow(R, 3);
        }
        public TBall() { }
        public void creatingNewBall()
        {
            Console.Write("Radius: ");
            R = Convert.ToDouble(Console.ReadLine());
            S = SReturner(R);
            V = VReturner(R);
        }
        public double SReturner(double R)
        {
            return 4 * Math.PI * Math.Pow(R, 2);
        }
        public double VReturner(double R)
        {
            return (4 / 3) * Math.PI * Math.Pow(R, 3);
        }
        public override string getInfo()
        {
            return $"R: {R} \n {base.getInfo()}";
        }
    }
    class Program
    {
        static List<object> Figures = new List<object>();
        static void Main(string[] args)
        {
            TParalelepiped Paralelepiped = new TParalelepiped();
            Paralelepiped.creatingNewParalelepiped();

            TBall Ball = new TBall();
            Ball.creatingNewBall();

            Console.WriteLine(Paralelepiped.getInfo());
            Console.WriteLine(Ball.getInfo());
        }
    }
}
