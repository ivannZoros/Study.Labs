using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace LibraryManagement
{
    public class BookRepository
    {

        private readonly string _booksFilePath = "C:\\Users\\Елена Елисеева\\Downloads\\Study.Labs\\Study.Labs\\LibraryManagement\\books.json";
        private List<Book> _books = new List<Book>();
        public BookRepository(string filePath) 
        {
            _booksFilePath = filePath;
            LoadBooks(_booksFilePath);
        }
 
        private void LoadBooks(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var jsonString = File.ReadAllText(filePath);
                    _books = JsonSerializer.Deserialize<List<Book>>(jsonString);
                }
                else
                {
                    _books = new List<Book>();
                }
            } catch (Exception ex) {
                Console.Write($"Ошибка чтения файла: {ex.Message}");
                _books = new List<Book>();
            }

        }
        private void SaveBooks()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                var jsonString = JsonSerializer.Serialize(_books, options);
                File.WriteAllText(_booksFilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи файла: {ex.Message}");
            }
        }
        public List<Book> SearchBooks(string searchId, SearchCriteria criteria)
        {
            LoadBooks(_booksFilePath);
            List<Book> results = new List<Book>();
            switch (criteria)
            {
                case SearchCriteria.Title:
                    foreach (var book in _books) {
                        if(book.Title == searchId) 
                        results.Add(book);
                    }
                    break;
                case SearchCriteria.Author:
                    foreach (var book in _books)
                    {
                        if (book.Author == searchId)
                            results.Add(book);
                    }
                    break;
                case SearchCriteria.Isbn:
                    foreach (var book in _books)
                    {
                        if (book.Isbn == searchId)
                            results.Add(book);
                    }
                    break;
            }
            return results;
        }
        public void AddBook(Book book)
        {
            LoadBooks(_booksFilePath);
            _books.Add(book);
            SaveBooks();
        }

        public List<Book> GetAllBooks()
        {
            LoadBooks(_booksFilePath);
            return _books;
        }


        public void RemoveBook(Book book)
        {

            _books.Remove(book);
            SaveBooks();
        }


    }
}
