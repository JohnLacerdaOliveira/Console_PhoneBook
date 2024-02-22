using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        public Dictionary<string, Action<IAppFunctionality>> StartMenu { get; init; } = new Dictionary<string, Action<IAppFunctionality>>
        {
            { "Import Phonebook", (func) => func.ImportPhoneBook() },
            { "Create new PhoneBook", null},
            { "Settings", (func) => func.DeleteContact() },
            { "Exit", (func) => func.ExitApplication() }
        };

        //TODO - Still need to understand this
        private readonly IMenuDelegates _mainMenu;
        private readonly IAppFunctionality _appFunctionality;
        private readonly IConsoleUI _userInterface;


        public PhoneBookApp(
            IMenuDelegates MenuDelegates,
            IAppFunctionality appFunctionality,
            IConsoleUI userInterface)
        {
            _mainMenu = MenuDelegates;
            _appFunctionality = appFunctionality;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.PrintWelcomeScreen();

            int startchoice = _userInterface.PromptMenuChoice(StartMenu.Keys);
            _mainMenu.InvokeCorrespondingMethod(startchoice);

            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");

                int choice = _userInterface.PromptMenuChoice(_mainMenu.Options);
                _mainMenu.InvokeCorrespondingMethod(choice);
            }
        }
    }
}