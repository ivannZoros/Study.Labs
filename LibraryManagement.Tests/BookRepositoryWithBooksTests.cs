using Moq;
using System.Text.Json;


namespace LibraryManagement.Tests
{
    public class BookRepositoryTestsWithBooksTests
    {
        private readonly Mock<IFileSystemClient> _mockFileSystemClient;
        private readonly BookRepository _repository;
        private readonly string _testFilePath = "test.json";
        public BookRepositoryTestsWithBooksTests()
        {
            _mockFileSystemClient = new Mock<IFileSystemClient>();
            var listOfBooks = JsonSerializer.Serialize(
                new List<Book>
            {
                new Book
                {
                    Title = "Title 1",
                    Author = "Author 1",
                    Isbn = "111",
                    PublicationYear = 2001
                },
                new Book
                {
                    Title = "Title 2",
                    Author = "Author 2",
                    Isbn = "222",
                    PublicationYear = 2002
                }
            });
            _mockFileSystemClient
                .Setup(x => x.Exists(It.IsAny<string>()))
                .Returns(true);

            _mockFileSystemClient
               .Setup(x => x.ReadAllText(It.IsAny<string>()))
               .Returns(listOfBooks);

            _repository = new BookRepository(_testFilePath, _mockFileSystemClient.Object);
        }
        [Fact]
        public void AddBook_ShouldAddBookToExistingList()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Title",
                Author = "New Author",
                Isbn = "333",
                PublicationYear = 2003
            };

            // Act
            _repository.AddBook(newBook);
            var allBooks = _repository.GetAllBooks();

            // Assert
            Assert.Equal(3, allBooks.Count); 
        }
        [Fact]
        public void RemoveBook_ShouldRemoveBookFromExistingList()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "New Title",
                Author = "New Author",
                Isbn = "333",
                PublicationYear = 2003
            };

            // Act
            _repository.AddBook(newBook);
            _repository.RemoveBook(newBook);
            var allBooks = _repository.GetAllBooks();

            // Assert
            Assert.Equal(2,allBooks.Count); 
        }
        [Fact]
        public void SearchBooks_ByAuthor_ShouldReturnExistingBooks()
        {
            // Arrange + Act
            var result = _repository.SearchBooks("Author 1", SearchCriteria.Author);

            // Assert
            Assert.Single(result);
            Assert.Equal("Author 1", result.First().Author);
        }
    }
}
