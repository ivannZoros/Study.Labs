using System;

namespace Study.Labs.Lab02
{
    class Program
    {
        static void Main(string[] args)
        {

            string choose;
            bool flag;
            do
            {
                flag = false;
                Console.WriteLine("Выбор задачи(1 или 2)");
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    Task01();
                }
                if (choose == "2")
                {
                    Task02();
                }
                else
                {
                    Console.WriteLine("Неверный выбор");
                    flag = true;
                }
            }
            while (flag == true);
        }

        private static void Task01()
        {
            Console.WriteLine("Вводите слова, завершая каждое нажатием Enter.\nДля выхода наберите exit.");
            string maxWord = "";

            var ans = Console.ReadLine();
            while (ans != "exit")
            {
                int lenght = ans.Length;

                if (lenght > maxWord.Length)
                {
                    maxWord = ans;
                }

                ans = Console.ReadLine();
            }
            Console.WriteLine($"{maxWord.ToUpper()}({maxWord.Length})");
        }

        private static void Task02()
        {
            Random random = new Random();
            int alltry = 0;
            int righttry = 0;

            Console.WriteLine("Введите число:");
            while (true)
            {
                string ans = Console.ReadLine();

                if (ans == "0" || ans == "1")
                {
                    int rand = random.Next(2);
                    alltry++;

                    if (ans == rand.ToString())
                    {
                        Console.WriteLine("Угадали");
                        righttry++;
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте снова");
                    }
                }
                else
                {
                    double percentage = Math.Round(righttry * 100.0 / alltry, 2);
                    Console.WriteLine($"Игра окончена со счетом {alltry}, угадано {percentage}% бросков.");
                    break;
                }
            }
        }
    }
}
