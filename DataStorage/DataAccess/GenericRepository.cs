using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public abstract class GenericRepository : IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> Parse(string fileData);
        public abstract string Serialize(IEnumerable<IGenericContact> register);

        public IEnumerable<IGenericContact> LoadDataFromFile(FileMetaData fileMetaData)
        {
            string? fileData = default;

            if (!File.Exists(fileMetaData.FilePath)) File.Create(fileMetaData.FilePath);

            try
            {
                fileData = File.ReadAllText(fileMetaData.FilePath);
                if (fileData.Length == 0) return new List<IGenericContact>();
            }
            catch (Exception)
            {
                throw new IOException($"An error occcured while reading from the file: {fileMetaData.FilePath}");
            }
 
            return Parse(fileData);
        }

        public void SaveDataToFile(IEnumerable<IGenericContact> register, FileMetaData fileMetaData)
        {
            File.WriteAllText(fileMetaData.FilePath,Serialize(register));
        }
    }
}