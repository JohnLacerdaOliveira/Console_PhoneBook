using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataAccess.DataStorage
{
    public abstract class GenericRepository : IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> Parse(string fileData);
        public abstract string Serialize(IEnumerable<IGenericContact> register);

        public IEnumerable<IGenericContact> LoadFromFile(FileMetadata fileMetaData)
        {
            string? fileData = string.Empty;

            if (!File.Exists(fileMetaData.FilePath)) return Enumerable.Empty<IGenericContact>();

            try
            {
                fileData = File.ReadAllText(fileMetaData.FilePath);
                if (fileData.Length == 0) return Enumerable.Empty<IGenericContact>();
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occcured while reading from the file: {fileMetaData.FilePath}", ex);
            }

            return Parse(fileData);
        }

        public void SaveToFile(IEnumerable<IGenericContact> register, FileMetadata fileMetaData)
        {
            if (string.IsNullOrEmpty(fileMetaData?.FilePath))
                throw new ArgumentException("Invalid file metadata.");

            File.WriteAllText(fileMetaData.FilePath, Serialize(register));
        }
    }
}