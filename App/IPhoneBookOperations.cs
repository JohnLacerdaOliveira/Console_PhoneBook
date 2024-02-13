using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public interface IPhoneBookOperations
    {
        public abstract void AddContact(List<IGenericEntry> repository);
        public abstract void ViewAllContacts(List<IGenericEntry> repository);
        public abstract IGenericEntry SearchContact(List<IGenericEntry> repository);
        public abstract void EditContact(List<IGenericEntry> repository);
        public abstract void DeleteContact(List<IGenericEntry> repository);
    }
}