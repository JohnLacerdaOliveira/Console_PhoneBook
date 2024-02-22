using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> LoadDataFromFile(FileMetaData fileMetaData);
        public abstract void SaveDataToFile(IEnumerable<IGenericContact> register, FileMetaData fileMetaData);
    }
}
