using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IGenericRepository
    {
        public abstract IEnumerable<IGenericEntry> Load();
        public abstract void Save(IEnumerable<IGenericEntry> entriesRegister);
    }
}
