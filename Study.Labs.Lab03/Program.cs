using System;

namespace Study.Labs.Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task();
            task.a = int.Parse(Console.ReadLine());
            task.b = int.Parse(Console.ReadLine());
            task.c = int.Parse(Console.ReadLine());

            Solver solver = new Solver();
            var rootCount = solver.Solve(task.a,task.b,task.c,out var x1, out var x2);

            if (rootCount == 2)
            {
                Console.WriteLine($"x1 = {x1}\nx2 = {x2} ");
            }
            else if (rootCount == 1)
            {
                Console.WriteLine($"x = {x1}");
            }
            else
            {
                Console.WriteLine("Действительных корней нет");
            }
        }
    }
    class Task
    {
        public double a;
        public double b;
        public double c;
    }
    class Solver
    {
        private double Discriminant(double a,double b,double c)
        {
            return Math.Pow(b, 2.0) - 4 * a * c;
        }

        private double Discriminant(Task task)
        {
            return Math.Pow(task.b, 2.0) - 4 * task.a * task.c;
        }

        public int Solve(double a, double b,double c,out double x1,out double x2)
        {
            if (Discriminant(a,b,c) > 0.0)
            {
                x1 = (-b + Math.Sqrt(Discriminant(a, b, c))) / (2 * a);
                x2 = (-b - Math.Sqrt(Discriminant(a, b, c))) / (2 * a);
                return 2;
            }

            else if (Discriminant(a, b, c) == 0.0)
            {
                x1 = -b / (2 * a);
                x2 = 0;
                return 1;
            }
            else
            {
                x1 = 0;
                x2 = 0;
                return 0;
            }
        }

        public Solution Solve(Task task)
        {
            Solution solution = new Solution();
            double discriminant = Discriminant(task);
            if (discriminant > 0.0)
            {
                solution.x1 = (-task.b + Math.Sqrt(discriminant)) / (2 * task.a);
                solution.x2 = (-task.b - Math.Sqrt(discriminant)) / (2 * task.a);
                solution.y = 2;
            }

            else if (discriminant == 0.0)
            {
                solution.x1 = -task.b / (2 * task.a);
                solution.y = 1;
            }
            else
            {
                solution.y = 0;
            }

            return solution;
        }
    }
        class Solution
    {
        public double x1;
        public double x2;
        public double y;

    }
}
