namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string booksFilePath = "C:\\IT\\git\\Study.Labs\\LibraryManagement\\books.json";
            var fileStorage = new FileStorage();
            var repository = new BookRepository(booksFilePath, fileStorage);

            while (true) {

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Показать все книги");
                Console.WriteLine("4. Выполнить поиск книги");
                Console.WriteLine("5. Выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Вы выбрали действие добавить книгу");
                        AddBook(repository);
                        break;

                    case "2":
                        Console.WriteLine("Вы выбрали удалить добавить книгу");
                        RemoveBook(repository);
                        break;
                    case "3":
                        Console.WriteLine("Вы выбрали действие показать все книгу");
                        ShowAllBooks(repository);
                        break;
                    case "4":
                        Console.WriteLine("Вы выбрали действие выполнить поиск книги");
                        SearchBook(repository);
                        break;
                     case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
            
        }
        static void AddBook(BookRepository repository)
        {
            Console.Write("Введите название книги: ");
            var title = Console.ReadLine();
            Console.Write("Введите автора: ");
            var author = Console.ReadLine();
            Console.Write("Введите ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Введите год издания: ");
            var publicationYear = int.Parse(Console.ReadLine());

            var book = new Book
            {
                Title = title,
                Author = author,
                Isbn = isbn,
                PublicationYear = publicationYear
            };

            repository.AddBook(book);
            Console.WriteLine("Книга добавлена.");
        }
        static void RemoveBook(BookRepository repository)
        {
            var books = repository.GetAllBooks();

            Console.WriteLine("Выберите книгу для удаления");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books.ElementAt(i).Title} - {books.ElementAt(i).Author}");
            }

            var choice = int.Parse(Console.ReadLine());

            if(choice >= 0 &&  choice <= books.Count)
            {
                repository.RemoveBook(books.ElementAt(choice - 1));
                Console.WriteLine("Книга удалена");
            }
            else
            {
                Console.WriteLine("Неверный выбор");
            }
        }

        static void ShowAllBooks(BookRepository repository)
        {
            var books = repository.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста");
            }
            else
            {
                foreach (var book in books) 
                    Console.WriteLine($"{book.Title} - {book.Author} - {book.PublicationYear} - {book.Isbn}");
            }
        }
        static void SearchBook(BookRepository repository)
        {
            Console.WriteLine("Выберите критерий поиска:");
            Console.WriteLine("1. По названию");
            Console.WriteLine("2. По автору");
            Console.WriteLine("3. По ISBN");

            var choice = Console.ReadLine();
            string searchId;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите название книги:");
                    searchId = Console.ReadLine();
                    ShowSearchResults(repository.SearchBooks(searchId,SearchCriteria.Title));
                    break;
                case "2":
                    Console.WriteLine("Введите автора книги:");
                    searchId = Console.ReadLine();
                    ShowSearchResults(repository.SearchBooks(searchId, SearchCriteria.Author));
                    break;
                case "3":
                    Console.WriteLine("Введите ISBN книги:");
                    searchId = Console.ReadLine();
                    ShowSearchResults(repository.SearchBooks(searchId, SearchCriteria.Isbn));
                    break;
            }
        }
        static void ShowSearchResults(IReadOnlyCollection<Book> searchResults)
        {
            if (searchResults.Count == 0)
            {
                Console.WriteLine("Книги не найдены.");
            }
            else
            {
                Console.WriteLine("Результаты поиска:");
                foreach (var book in searchResults)
                {
                    Console.WriteLine($"{book.Title} - {book.Author} - {book.PublicationYear} - {book.Isbn}");
                }
            }
        }
    }
}