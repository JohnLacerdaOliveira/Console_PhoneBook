using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IPhoneBookFunctionality
    {
        public abstract void AddEntry(IEnumerable<IGenericEntry> register);
        public abstract void PrintAllEntries(IEnumerable<IGenericEntry> register);
        public abstract IGenericEntry SearchByName(IEnumerable<IGenericEntry> register);
        public IGenericEntry LiveSearch(IEnumerable<IGenericEntry> register);
        public abstract void EditEntry(IEnumerable<IGenericEntry> register);
        public abstract void DeleteEntry(IEnumerable<IGenericEntry> register);
    }
}