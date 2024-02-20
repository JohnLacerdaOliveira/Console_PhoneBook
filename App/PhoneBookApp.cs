using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        //TODO - Still need to understand this
        private IMenuDelegates _menu;
        private readonly IAppFunctionality _appFunctionality;
        private readonly IConsoleUI _userInterface;

        public PhoneBookApp(
            IMenuDelegates menuDelegates,
            IAppFunctionality appFunctionality,
            IConsoleUI userInterface)
        {
            _menu = menuDelegates;
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

                int choice = _userInterface.PromptMenuChoice(_menu.Options);
                _menu.InvokeCorrespondingMethod(choice);
            }
        }
    }
}