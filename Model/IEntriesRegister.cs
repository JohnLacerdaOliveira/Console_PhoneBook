using Console_PhoneBook.App;

namespace Console_PhoneBook.Model
{
    public interface IEntriesRegister
    {
        public abstract void AddContact();
        public abstract void ViewAllContacts();
        public abstract IGenericEntry SearchContact();
        public abstract void EditContact();
        public abstract void DeleteContact();
    }
}
