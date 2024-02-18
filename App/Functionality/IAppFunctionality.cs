using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IAppFunctionality
    {
        public abstract void AddContact();
        public abstract void PrintAllContacts();
        public abstract IGenericContact LiveSearch();
        public abstract void EditContact();
        public abstract void DeleteContact();
        public abstract void ExportAllContacts();
        public abstract void ExitApplication();
        public abstract void LoadData();
    }
}