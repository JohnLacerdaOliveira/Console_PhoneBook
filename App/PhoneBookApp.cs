using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        //TODO - Still need to understand this
        public Dictionary<string, Action<IAppFunctionality>> _menuDelegates = new Dictionary<string, Action<IAppFunctionality>>()
        {
            ["Add Contact"] = (func) => func.AddContact(),
            ["View All Contacts"] = (func) => func.PrintAllContacts(),
            ["Search Contact"] = (func) => func.LiveSearch(),
            ["Edit Contact"] = (func) => func.EditContact(),
            ["Delete Contact"] = (func) => func.DeleteContact(),
            ["Export PhoneBook"] = (func) => func.ExportAllContacts(),
            ["Exit"] = (func) => func.ExitApplication()
        };

        private readonly IAppFunctionality _appFunctionality;
        private readonly IConsoleUI _userInterface;


        public PhoneBookApp(
            IAppFunctionality appFunctionality,
            IConsoleUI userInterface)
        {
            _appFunctionality = appFunctionality;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.PrintWelcomeScreen();
            _appFunctionality.LoadData();

            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");

                int choice = _userInterface.PromptMenuChoice(_menuDelegates.Keys);
                _menuDelegates.ElementAt(choice - 1).Value.Invoke(_appFunctionality);
            }
        }
    }
}