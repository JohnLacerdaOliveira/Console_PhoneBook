using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IRepository
    {
        public abstract void Save(IEntriesRegister repository);
        public abstract IEnumerable<IGenericEntry> Read();
    }
}
