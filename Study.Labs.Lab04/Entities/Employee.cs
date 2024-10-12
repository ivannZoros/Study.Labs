namespace Study.Labs.Lab04.Entities
{
    class Employee
    {
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Adress;
        public int HireYear;
        public string Post;

        public virtual string DoWork() => $"Сотрудник \"Сотрудник\" выполняет работу";
        
    }
}
