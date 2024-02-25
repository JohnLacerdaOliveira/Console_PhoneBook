using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> LoadFromFile(FileMetadata fileMetaData);
        public abstract void SaveToFile(IEnumerable<IGenericContact> register, FileMetadata fileMetaData);
    }
}
