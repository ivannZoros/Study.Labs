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
        public string Load()
        {
            if(File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
            return 0;
        }

        public void Save(string data)
        {
            File.WriteAllText(_filePath, data);
        }
    }
}
