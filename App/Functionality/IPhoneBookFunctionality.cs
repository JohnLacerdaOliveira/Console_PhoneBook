using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IPhoneBookFunctionality
    {
        public abstract void AddContact(IEnumerable<IGenericContact> register);
        public abstract void PrintAllContacts(IEnumerable<IGenericContact> register);
        public abstract IGenericContact SearchByName(IEnumerable<IGenericContact> register);
        public IGenericContact LiveSearch(IEnumerable<IGenericContact> register);
        public abstract void EditContact(IEnumerable<IGenericContact> register);
        public abstract void DeleteContact(IEnumerable<IGenericContact> register);
    }
}