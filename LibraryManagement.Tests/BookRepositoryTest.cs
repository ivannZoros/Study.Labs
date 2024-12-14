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
            //Act + Arrange
            var books = _repository.GetAllBooks();

            //Assert
            Assert.Empty(books);

        }

        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            //Arrange + Act
            _repository.AddBook(TestBook1);
            var allBooks = _repository.GetAllBooks();

            //Assert
            Assert.Single(allBooks);

        }

        [Fact]
        public void RemoveBook_ShouldRemoveBookFromList()
        {


            //Arrange + Act
            _repository.AddBook(TestBook1);
            _repository.RemoveBook(TestBook1);

            var allBooks = _repository.GetAllBooks();

            //Assert
            Assert.Empty(allBooks);

        }

        [Fact]
        public void SearchBooks_ByTitle_ShouldReturnCorrectBooks()
        {
            //Arrange + Act 
            _repository.AddBook(TestBook1);
            _repository.AddBook(TestBook2);

            var result = _repository.SearchBooks("Title1", SearchCriteria.Title);
            //Assert
            Assert.Single(result);
            Assert.Equal(TestBook1.Title, result.First().Title);

        }

        [Fact]
        public void SearchBooks_ByAuthor_ShouldReturnCorrectBooks()
        {
            //Arrange + Act 
            _repository.AddBook(TestBook1);
            _repository.AddBook(TestBook2);

            var result = _repository.SearchBooks("Author1", SearchCriteria.Author);

            //Assert
           Assert.Equal(TestBook1.Author, result.First().Author);

        }

        [Fact]
        public void SearchBooks_ByIsbn_ShouldReturnCorrectBooks()
        {
            //Arrange + Act 
            _repository.AddBook(TestBook1);
            _repository.AddBook(TestBook2);

            var result = _repository.SearchBooks("1", SearchCriteria.Isbn);

            //Assert
            Assert.Equal(TestBook1.Isbn, result.First().Isbn);


        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {

            //Arrange + Act 
            _repository.AddBook(TestBook1);
            _repository.AddBook(TestBook2);

            var books = _repository.GetAllBooks();

            //Assert
            Assert.Equal(2, books.Count);

        }

        private static Book TestBook1 = new Book
        {
            Title = "Title1",
            Author = "Author1",
            Isbn = "1",
            PublicationYear = 1
        };
        private static Book TestBook2 = new Book
        {
            Title = "Title2",
            Author = "Author2",
            Isbn = "2",
            PublicationYear = 2
        };

    }
}