using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        //TODO - Still need to understand this
        private MenuDelegates _menuDelegates;
        private readonly IAppFunctionality _appFunctionality;
        private readonly IConsoleUI _userInterface;


        public PhoneBookApp(
            MenuDelegates menuDelegates,
            IAppFunctionality appFunctionality,
            IConsoleUI userInterface)
        {
            _menuDelegates = menuDelegates;
            _appFunctionality = appFunctionality;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.PrintWelcomeScreen();
            _appFunctionality.ImportPhoneBook();

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