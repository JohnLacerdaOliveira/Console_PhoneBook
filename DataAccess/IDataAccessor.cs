using Console_PhoneBook.Model;

namespace Console_PhoneBook.DataAccess
{
    public interface IDataAccessor
    {
        public abstract IEnumerable<IGenericEntry> Save(IEntriesRepository repository);
        public abstract void Read();
    }
}
