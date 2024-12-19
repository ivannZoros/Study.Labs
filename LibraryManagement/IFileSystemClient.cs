namespace LibraryManagement
{
    public interface IFileSystemClient
    {
        bool Exists(string filePath);
        string ReadAllText(string filePath);
        void Save(string filePath, string data);
    }
}
