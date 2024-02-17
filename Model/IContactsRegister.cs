using Console_PhoneBook.App;

namespace Console_PhoneBook.Model
{
    public interface IContactsRegister
    {
        public abstract IEnumerable<IGenericContact> Contacts { get; set; }
        public abstract void AddContact();
        public abstract void PrintAllContacts();
        public abstract IGenericContact SearchContact();
        public abstract void EditContact();
        public abstract void DeleteContact();
    }
}
