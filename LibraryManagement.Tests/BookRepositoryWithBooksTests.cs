using Moq;
using System.Text.Json;


namespace LibraryManagement.Tests
{
    public class BookRepositoryTestsWithBooksTests
    {
        //написать тест который В правильный момент вызывается метод Save через Verify
        private readonly Mock<IFileSystemClient> _mockFileSystemClient;
        private readonly BookRepository _repository;
        private readonly string _testFilePath = "test.json";
        public BookRepositoryTestsWithBooksTests()
        {
            _mockFileSystemClient = new Mock<IFileSystemClient>();
            var serializeOfBooks = JsonSerializer.Serialize(
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
               .Returns(serializeOfBooks);

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
                Title = "Title 1",
                Author = "Author 1",
                Isbn = "111",
                PublicationYear = 2001
            };

            _repository.AddBook(newBook);

            // Act
            var searchResults = _repository.SearchBooks("Author 1", SearchCriteria.Author);
            var bookToRemove = searchResults.First(); 
            _repository.RemoveBook(bookToRemove);

            var allBooks = _repository.GetAllBooks();

            // Assert
            Assert.DoesNotContain(bookToRemove,allBooks); 
        }

        [Fact]
        public void SearchBooks_ByAuthor_ShouldReturnExistingBooks()
        {
            // Act
            var result = _repository.SearchBooks("Author 1", SearchCriteria.Author);

            // Assert
            Assert.Single(result);
            Assert.Equal("Author 1", result.First().Author);
        }

        [Fact]
        public void AddBook_ShouldCallSaveMethodOnce()
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

            // Assert
            _mockFileSystemClient.Verify(x => x.Save(It.IsAny<string>()), Times.Once);
        }
    }
}
