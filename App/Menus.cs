using Console_PhoneBook.App.Functionality;

namespace Console_PhoneBook.App
{
    public class Menus : IMenus
    {
        private readonly IAppFunctionality _appFunctionality;

        public Menus(IAppFunctionality appFunctionality)
        {
            _appFunctionality = appFunctionality;
        }

        // Dictionary mapping menu options to corresponding actions for the start menu
        public Dictionary<string, Action<IAppFunctionality>> Start { get; init; } = new()
        {
            { "Demo PhoneBook", (func) => func.LoadDemoPhoneBook() },
            { "Import Phonebook", (func) => func.ImportPhoneBook() },
            { "New PhoneBook",(func) => func.CreateNewPhoneBook() },
            { "Exit", (func) => func.ExitApplication() }
        };

        // Dictionary mapping menu options to corresponding actions for the main menu
        public Dictionary<string, Action<IAppFunctionality>> Main { get; init; } = new()
        {
            { "Import Phonebook", (func) => func.ImportPhoneBook() },
            { "View All Contacts", (func) => func.PrintAllContacts() },
            { "Search Contact", (func) => func.Search() },
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
