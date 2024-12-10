using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class FileStorage : IFileSystemClient
    {
        private readonly string _filePath;

        public FileStorage(string filePath)
        {
            _filePath = filePath;
        }

        public bool Exists(string filePath)
        {
            return File.Exists(_filePath);
        }
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void Save(string data)
        {
            File.WriteAllText(_filePath, data);
        }
    }
}
