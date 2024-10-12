using Study.Labs.Lab04.Entities;
using Study.Labs.Lab04.Helpers;
using System;

namespace Study.Labs.Lab04
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
                Console.WriteLine("Выбор задачи(1,2,3)");
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    Task01();
                }
                if (choose == "2")
                {
                    Task02();
                }
                if (choose == "3")
                {
                    Task03();
                }
                else
                {
                    Console.WriteLine("Неверный выбор");
                    flag = true;
                }
            }
            while (flag == true);




            Employee employee = new Employee();

            Console.WriteLine(employee.DoWork());

            employee = new Groundskeeper();

            Console.WriteLine(employee.DoWork());
        }

        static void Task01()
        {
            var trainArray = new[]
            {
                new Train() {Number = "П-1",DestinationPoint = "LA",DeparturePoint = "Omsk",NumberOfSeats = 200},
                new Train() {Number = "П-2",DestinationPoint = "NY",DeparturePoint = "Mexico",NumberOfSeats = 300 },
                new Train() {Number = "П-3",DestinationPoint = "LA",DeparturePoint = "NY",NumberOfSeats = 400},
                new Train() {Number = "П-4",DestinationPoint = "CA",DeparturePoint = "EU",NumberOfSeats = 500},
                new Train() {Number = "П-5",DestinationPoint = "Africa",DeparturePoint = "Ireland",NumberOfSeats = 600},
                };

            var foundTrain = TrainHelper.FindTrain(trainArray, "П-1");
            TrainHelper.PrintTrain(foundTrain);
            foundTrain = TrainHelper.FindMaxSeatsTrain(trainArray);
            Console.WriteLine("Поезд с max местами:");
            TrainHelper.PrintTrain(foundTrain);

        }
        static void Task02()
        {
            var foodArray = new[]
            {
                new Product() {Name = "Молоко",Category = "Напиток",Ingredients = "молоко,вода",ShelfLife = 30},
                new Product() {Name = "Хлеб",Category = "Еда",Ingredients = "вода,мука,молоко",ShelfLife = 7},
                new Product() {Name = "Чай",Category = "Напиток",Ingredients = "вода,чайный пакетик",ShelfLife = 10},
                new Product() {Name = "Кофе",Category = "Напиток",Ingredients = "вода,кофе",ShelfLife = 5},
                new Product() {Name = "Сардельки",Category = "Еда",Ingredients = "мясо",ShelfLife = 31},
                new Product() {Name = "Кока-кола",Category = "Напиток",Ingredients = "сахар,вода,краситель",ShelfLife = 30},
                new Product() {Name = "Чак-чак",Category = "Еда",Ingredients = "мед,мука,масло",ShelfLife = 15},
                new Product() {Name = "Колбаса",Category = "Напиток",Ingredients = "мясо",ShelfLife = 20},
                new Product() {Name = "Чай черный",Category = "Напиток",Ingredients = "вода,чайный пакетик",ShelfLife = 90},
                new Product() {Name = "Вода",Category = "Напиток",Ingredients = "вода",ShelfLife = 60},
                };
            var foundProducts = ProductHelper.FindProducts(foodArray, "вода");
            foreach (var product in foundProducts)
            {
                ProductHelper.PrintProduct(product);
            }
        }
        static void Task03()
        {
            var EmployeeArray = new[]
            {
                new Employee() {LastName = "Иванов",FirstName = "Иван",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2010,Post = "Машинист"},
                new Employee() {LastName = "Иванов",FirstName = "Сергей",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2010,Post = "Проводик"},
                new Employee() {LastName = "Иванов",FirstName = "Артем",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2011,Post = "Проводник"},
                new Employee() {LastName = "Иванов",FirstName = "Андрей",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2011,Post = "Машинист"},
                new Employee() {LastName = "Иванов",FirstName = "Вадим",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2012,Post = "Проводник"},
                new Employee() {LastName = "Иванов",FirstName = "Дмитрий",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2013,Post = "Проводник"},
                new Employee() {LastName = "Иванов",FirstName = "Егор",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2014,Post = "Охранник"},
                new Employee() {LastName = "Иванов",FirstName = "Федор",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2015,Post = "Проводник"},
                new Employee() {LastName = "Иванов",FirstName = "Илья",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2016,Post = "Проводник"},
                new Employee() {LastName = "Иванов",FirstName = "Александр",MiddleName = "Иванович",Adress = "Улица Пушкина",HireYear = 2017,Post = "Проводник"},
            };
            var foundEmployee = EmployeeHelper.FindEmployee(EmployeeArray, "Охранник");
            foreach(var employee in foundEmployee)
            {
                EmployeeHelper.PrintEmployee(employee);
                Console.WriteLine("----------------");
            }
            Console.WriteLine("++++++++++++");
            var foundOldestEmployee = EmployeeHelper.FindOldestEmployee(EmployeeArray);
            foreach (var employee in foundOldestEmployee)
            {
                EmployeeHelper.PrintEmployee(employee);
                Console.WriteLine("----------------");
            }

        }
    }

}
