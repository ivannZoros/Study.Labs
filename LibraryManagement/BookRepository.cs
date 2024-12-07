﻿using System.Text.Json;
using System.Text.Json.Serialization;


namespace LibraryManagement
{
    public class BookRepository
    {

        private readonly IFileSystemClient _fileSystemClient;
        private List<Book> _books = new List<Book>();
        private bool _isBookLoaded = false;
        public BookRepository(string filePath, IFileSystemClient storage) 
        {
            _fileSystemClient = storage;
            LoadBooks();
        }
 //LAZY<> тип для ленивой загрузки  
 //MOQ - библиотека для создания заглушен при тестировании .Сделать абстракцию от файловой системы
        private void LoadBooks()
        {
            if(_isBookLoaded == false) { 
                //if (File.Exists(_booksFilePath))
                if (_fileSystemClient.Exists(_booksFilePath))
                {
                    var jsonString = File.ReadAllText(_booksFilePath);
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
                File.WriteAllText(_booksFilePath, jsonString);
 
        }
        public List<Book> SearchBooks(string searchId, SearchCriteria criteria)
        {
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
            _books.Add(book);
            SaveBooks();
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }


        public void RemoveBook(Book book)
        {
            _books.Remove(book);
            SaveBooks();
        }


    }
}
