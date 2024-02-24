using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {  
        private readonly IMenu _menus;
        private readonly IConsoleUI _userInterface;

        public PhoneBookApp(
            IMenu Menus,
            IConsoleUI userInterface)
        {
            _menus = Menus;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.PrintWelcomeScreen();

            int startchoice = _userInterface.PromptMenuChoice(_menus.GetStartOptions);
            _menus.InvokeStartMethod(startchoice);

            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");

                int choice = _userInterface.PromptMenuChoice(_menus.GetMainOptions);
                _menus.InvokeMainMethod(choice);
            }
        }
    }
}