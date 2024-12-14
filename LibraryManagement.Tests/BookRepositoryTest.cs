using Moq;
using System.Text.Json;

namespace LibraryManagement.Tests
{
    public class BookRepositoryTests
    {
        private readonly Mock<IFileSystemClient> _mockFileSystemClient;
        private readonly BookRepository _repository;
        private readonly string _testFilePath = "test.json";
        public BookRepositoryTests()
        {
            _mockFileSystemClient = new Mock<IFileSystemClient>();

            _mockFileSystemClient
                .Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);

            _mockFileSystemClient
               .Setup(x => x.ReadAllText(It.IsAny<string>()))
               .Returns("[]");

            _repository = new BookRepository(_testFilePath, _mockFileSystemClient.Object);
        }

        [Fact]
        public void GetAllBooks_WhenEmpty_ShouldReturnEmptyList()
        {
            //Act +Arrange
            var books = _repository.GetAllBooks();

            //Assert
            Assert.Empty(books);

        }

        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            //Arrange
            var book = new Book()
            {
                Title = "Title",
                Author = "Author",
                Isbn = "1",
                PublicationYear = 1
            };

            //Act
            _repository.AddBook(book);
            var allBooks = _repository.GetAllBooks();

            //Assert
            Assert.Single(allBooks);

        }

        [Fact]
        public void RemoveBook_ShouldRemoveBookFromList()
        {
            //Arrange
            var book = new Book()
            {
                Title = "Title",
                Author = "Author",
                Isbn = "1",
                PublicationYear = 1
            };

            //Act 
            _repository.AddBook(book);
            _repository.RemoveBook(book);

            var allBooks = _repository.GetAllBooks();

            //Assert
            Assert.Empty(allBooks);

        }

        [Fact]
        public void SearchBooks_ByTitle_ShouldReturnCorrectBooks()
        {
            //Arrange
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
            //Act 
            _repository.AddBook(book1);
            _repository.AddBook(book2);

            var result = _repository.SearchBooks("Title1", SearchCriteria.Title);
            //Assert
            Assert.Single(result);
            Assert.Equal(book1.Title, result.First().Title);

        }

        [Fact]
        public void SearchBooks_ByAuthor_ShouldReturnCorrectBooks()
        {
            //Arrange
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
            //Act 
            _repository.AddBook(book1);
            _repository.AddBook(book2);

            var result = _repository.SearchBooks("Author1", SearchCriteria.Author);

            //Assert
           Assert.Equal(book1.Author, result.First().Author);

        }

        [Fact]
        public void SearchBooks_ByIsbn_ShouldReturnCorrectBooks()
        {
            //Arrange
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
            //Act 
            _repository.AddBook(book1);
            _repository.AddBook(book2);

            var result = _repository.SearchBooks("1", SearchCriteria.Isbn);

            //Assert
            Assert.Equal(book1.Isbn, result.First().Isbn);


        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            //Arrange
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

            //Act 
            _repository.AddBook(book1);
            _repository.AddBook(book2);

            var books = _repository.GetAllBooks();

            //Assert
            Assert.Equal(2, books.Count);

        }

    }
}