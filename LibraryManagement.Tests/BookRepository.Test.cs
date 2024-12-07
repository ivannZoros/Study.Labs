using Xunit;
using LibraryManagement;
using System.Runtime.InteropServices;

namespace LibraryManagement.Tests
{
    public class BookRepositoryTests
    {
        private readonly BookRepository _repository;
        private string _testFilePath = "C:\\Users\\Елена Елисеева\\Downloads\\Study.Labs\\Study.Labs\\LibraryManagement.Tests\\booksTests.json";
        public BookRepositoryTests()
        {
            _repository = new BookRepository(_testFilePath);
        }

        private void ClearBookList()
        {
            var allBooks = _repository.GetAllBooks();

            foreach (var book in allBooks.ToList()) 
            {
                _repository.RemoveBook(book);
            }
        }

        [Fact]
        public void GetAllBooks_ShouldReturnListOfBooks()
        {
            ClearBookList();
            var books = _repository.GetAllBooks();
            Assert.NotNull(books); 
        }
        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            ClearBookList();
            var book = new Book() 
            { Title = "Title", 
              Author = "Author",
              Isbn = "1",
              PublicationYear = 1
            };
            var expectedCount = _repository.GetAllBooks().Count()+1;

            _repository.AddBook(book);
            var actualBooks = _repository.GetAllBooks();

            Assert.Equal(expectedCount, actualBooks.Count());
        }
        [Fact]
        public void RemoveBook_ShouldRemoveBookFromList()
        {
            ClearBookList();
            var book = new Book()
            {
                Title = "Title",
                Author = "Author",
                Isbn = "1",
                PublicationYear = 1
            };
            var expectedCount = _repository.GetAllBooks().Count;


            _repository.AddBook(book);
            _repository.RemoveBook(book);

            var actualBooks = _repository.GetAllBooks();

            Assert.Equal(expectedCount, actualBooks.Count);
        }

        [Fact]
        public void SearchBooks_ByTitle_ShouldReturnCorrectBooks()
        {
            ClearBookList();
            var book1 = new Book()
            {
                Title = "Title1",
                Author = "Author1",
                Isbn = "1",
                PublicationYear = 1
            };
            var book2 = new Book()
            {
                Title = "Title2",
                Author = "Author2",
                Isbn = "2",
                PublicationYear = 2
            };

            _repository.AddBook(book1);
            _repository.AddBook(book2);


            var result = _repository.SearchBooks("Title1", SearchCriteria.Title);
            Assert.Equal(book1.Title, result[0].Title);
        }
        [Fact]
        public void SearchBooks_ByAuthor_ShouldReturnCorrectBooks()
        {
            ClearBookList();
            var book1 = new Book()
            {
                Title = "Title1",
                Author = "Author1",
                Isbn = "1",
                PublicationYear = 1
            };
            var book2 = new Book()
            {
                Title = "Title2",
                Author = "Author2",
                Isbn = "2",
                PublicationYear = 2
            };

            _repository.AddBook(book1);
            _repository.AddBook(book2);


            var result = _repository.SearchBooks("Author1", SearchCriteria.Author);
            Assert.Equal(book1.Author, result[0].Author);
        }
        [Fact]
        public void SearchBooks_ByIsbn_ShouldReturnCorrectBooks()
        {
            ClearBookList();
            var book1 = new Book()
            {
                Title = "Title1",
                Author = "Author1",
                Isbn = "1",
                PublicationYear = 1
            };
            var book2 = new Book()
            {
                Title = "Title2",
                Author = "Author2",
                Isbn = "2",
                PublicationYear = 2
            };

            _repository.AddBook(book1);
            _repository.AddBook(book2);


            var result = _repository.SearchBooks("1", SearchCriteria.Isbn);
            Assert.Equal(book1.Isbn, result[0].Isbn);
        }
        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            ClearBookList();
            var book1 = new Book()
            {
                Title = "Title1",
                Author = "Author1",
                Isbn = "1",
                PublicationYear = 1
            };
            var book2 = new Book()
            {
                Title = "Title2",
                Author = "Author2",
                Isbn = "2",
                PublicationYear = 2
            };
            _repository.AddBook(book1);
            _repository.AddBook(book2);

            var books = _repository.GetAllBooks();
            


            Assert.Equal(2, books.Count);
        }

    }
}