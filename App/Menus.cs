using Console_PhoneBook.App.Functionality;

namespace Console_PhoneBook.App
{
    public class Menus : IMenu
    {
        private readonly IAppFunctionality _appFunctionality;

        public Menus(IAppFunctionality appFunctionality)
        {
            _appFunctionality = appFunctionality;
        }

        public Dictionary<string, Action<IAppFunctionality>> Start { get; init; } = new()
        {
            { "Import Phonebook", (func) => func.ImportPhoneBook() },
            { "New PhoneBook",(func) => func.CreateNewPhoneBook()},
            //TODO - create settings menu
            //{ "Settings", (func) => func.AppSettings() },
            { "Exit", (func) => func.ExitApplication() }
        };

        public Dictionary<string, Action<IAppFunctionality>> Main { get; init; } = new()
        {
            { "Import Phonebook", (func) => func.ImportPhoneBook() },
            { "View All Contacts", (func) => func.PrintAllContacts() },
            { "Search Contact", (func) => func.LiveSearch() },
            { "Add Contact", (func) => func.AddContact() },
            { "Edit Contact", (func) => func.EditContact() },
            { "Delete Contact", (func) => func.DeleteContact() },
            { "Export PhoneBook", (func) => func.ExportPhoneBook() },
            { "Exit", (func) => func.ExitApplication() }
        };

        public void InvokeStartMethod(int selectedOption)
        {
            var option = Start.ElementAt(selectedOption - 1);
            option.Value.Invoke(_appFunctionality);
        }

        public void InvokeMainMethod(int selectedOption)
        {
            var option = Main.ElementAt(selectedOption - 1);
            option.Value.Invoke(_appFunctionality);
        }
    }
}
