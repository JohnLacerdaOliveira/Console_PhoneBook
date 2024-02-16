using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IPhoneBookFunctionality
    {
        public abstract void AddContact(IEnumerable<IGenericEntry> repository);
        public abstract void ViewAllContacts(IEnumerable<IGenericEntry> repository);
        public abstract IGenericEntry SearchContact(IEnumerable<IGenericEntry> repository);
        public abstract void EditContact(IEnumerable<IGenericEntry> repository);
        public abstract void DeleteContact(IEnumerable<IGenericEntry> repository);
    }
}