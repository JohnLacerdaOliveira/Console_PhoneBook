using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> LoadDataFromFile();
        public abstract void SaveDataToFile(IEnumerable<IGenericContact> register);
    }
}
