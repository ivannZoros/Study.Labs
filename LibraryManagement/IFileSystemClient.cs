﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
   public interface IFileSystemClient
    {
        bool Exists(string filePath);
        string ReadAllText(string filePath);
        void Save(string filePath, string data);
    }
}
