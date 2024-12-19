namespace LibraryManagement
{
    public class FileStorage : IFileSystemClient
    {
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void Save(string filePath, string data)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
