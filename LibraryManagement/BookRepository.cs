﻿using System.Text.Json;
using System.Text.Json.Serialization;


namespace LibraryManagement
{
    public class BookRepository
    {
        private readonly string _bookFilePath;
        private readonly IFileSystemClient _fileSystemClient;
        private List<Book> _books = new List<Book>();
        private bool _isBookLoaded = false;
        
        public BookRepository(string filePath, IFileSystemClient storage) 
        {
            _bookFilePath = filePath;
            _fileSystemClient = storage;
            LoadBooks();
        }
      
        public IReadOnlyCollection<Book> SearchBooks(string searchId, SearchCriteria criteria)
        {
            criteria.HasFlag(SearchCriteria.Title);
            List<Book> results = new List<Book>();
            if(criteria.HasFlag(SearchCriteria.Title)) 
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
            _books.Add(book);
            SaveBooks();
        }

        public IReadOnlyCollection<Book> GetAllBooks()
        {
            return _books;
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
            SaveBooks();
        }

        private void LoadBooks()
        {
            if (_isBookLoaded == false)
            {
                if (_fileSystemClient.Exists(_bookFilePath))
                {
                    var jsonString = _fileSystemClient.ReadAllText(_bookFilePath);
                    _books = JsonSerializer.Deserialize<List<Book>>(jsonString);
                }
                else
                {
                    _books = new List<Book>();
                }
                _isBookLoaded = true;
            }
        }

        private void SaveBooks()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var jsonString = JsonSerializer.Serialize(_books, options);
            _fileSystemClient.Save(_bookFilePath,jsonString);

        }
    }
}
