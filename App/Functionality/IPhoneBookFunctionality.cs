using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IPhoneBookFunctionality
    {
        public abstract void AddEntry(IEnumerable<IGenericEntry> repository);
        public abstract void PrintAllEntries(IEnumerable<IGenericEntry> repository);
        public abstract IGenericEntry SearchEntry(IEnumerable<IGenericEntry> repository);
        public abstract void EditEntry(IEnumerable<IGenericEntry> repository);
        public abstract void DeleteEntry(IEnumerable<IGenericEntry> repository);
    }
}