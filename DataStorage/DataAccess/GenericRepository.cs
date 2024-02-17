using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public abstract class GenericRepository : IGenericRepository
    {
        protected readonly FileMetaData _fileMetaData;

        public GenericRepository(FileMetaData fileMetaData)
        {
            _fileMetaData = fileMetaData;
        }

        public abstract IEnumerable<IGenericContact> Parse(string fileData);
        public abstract string Serialize(IEnumerable<IGenericContact> register);

        public IEnumerable<IGenericContact> LoadDataFromFile()
        {
            string? fileData = default;

            if (!File.Exists(_fileMetaData.FilePath)) File.Create(_fileMetaData.FilePath);

            try
            {
                fileData = File.ReadAllText(_fileMetaData.FilePath);
            }
            catch (Exception)
            {
                throw new IOException($"An error occcured while reading from the file: {_fileMetaData.FilePath}");
            }

            if (fileData.Length == 0) return new List<Contact>();

            return Parse(fileData);

        }

        public void SaveDataToFile(IEnumerable<IGenericContact> register)
        {
            
            File.WriteAllText(_fileMetaData.FilePath,Serialize(register));
        }
    }
}