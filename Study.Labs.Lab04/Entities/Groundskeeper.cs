namespace Study.Labs.Lab04.Entities
{
    class Groundskeeper : Employee
    {
        //public string FirstName;
        //public string LastName;
        //public string MiddleName;
        //public string Adress;
        //public int HireYear;
        //public string Post;

        public Groundskeeper()
        {
            FirstName = "Test";
        }

        public override string DoWork() => $"Сотрудник \"Садовник\" выполняет работу";
    }
}
