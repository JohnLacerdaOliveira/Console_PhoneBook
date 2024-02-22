﻿namespace Console_PhoneBook.App.Functionality
{
    public class MenuDelegates : IMenuDelegates
    {
        private readonly IAppFunctionality _appFunctionality;
        public IEnumerable<string> Options => MainMenu.Keys;

        public Dictionary<string, Action<IAppFunctionality>> MainMenu { get; init; } = new Dictionary<string, Action<IAppFunctionality>>
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

 
        public MenuDelegates(IAppFunctionality appFunctionality)
        {
            _appFunctionality = appFunctionality;
        }

        public void InvokeCorrespondingMethod(int selectedOption)
        {
            var option = MainMenu.ElementAt(selectedOption - 1);
            option.Value.Invoke(_appFunctionality);
        }
    }
}
