using System;

namespace Study.Labs.Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            Task01();
            Task02();
        }
        private static void Task01()
        {
            Console.WriteLine("Введите год");
            var year = Console.ReadLine();
            int ans = int.Parse(year);
            var isLeapYear = IsLeapYear(ans);

            if (isLeapYear)
            {
                Console.WriteLine($"{year}: високосный");
            }
            else
            {
                Console.WriteLine($"{year}: невисокосный");
            }

        }
        private static void Task02()
        {
            Console.WriteLine("Введите значение температуры:");
            var temp =double.Parse( Console.ReadLine());
            Console.WriteLine("Введите значение шкалы:");
            var cout = Console.ReadLine();
            bool celsius;
            if (cout == "C" || cout == "c")
            {
                celsius = true;
            }
            else
            {
                celsius = false;
            }
            if (celsius)
            {
                Console.WriteLine(ConvertTemp(temp,celsius) + "F");
            }
            else
            {
                Console.WriteLine(ConvertTemp(temp, celsius) + "C");
            }
        

        }
        private static double ConvertTemp(double temp,bool celsius)
        {

            if (celsius)
            {
               return ((temp * 9) / 5 + 32);
            }
            else
            {
                return ((temp - 32) * 5 / 9);
            }
        }
        private static bool IsLeapYear(int ans)
        {
           
            if (ans % 400==0 || (ans % 4 == 0 && ans % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
