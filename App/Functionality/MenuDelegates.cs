namespace Console_PhoneBook.App.Functionality
{
    public class MenuDelegates : Dictionary<string, Action<IAppFunctionality>>
    {
        public MenuDelegates()
        {
            Add("Import Phonebook", (func) => func.ImportPhoneBook());
            Add("View All Contacts", (func) => func.PrintAllContacts());
            Add("Search Contact", (func) => func.LiveSearch());
            Add("Add Contact", (func) => func.AddContact());
            Add("Edit Contact", (func) => func.EditContact());
            Add("Delete Contact", (func) => func.DeleteContact());
            Add("Export PhoneBook", (func) => func.ExportPhoneBook());
            Add("Exit", (func) => func.ExitApplication());
        }
    }
}
