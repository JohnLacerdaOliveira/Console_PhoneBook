using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        private readonly IMenus _menus;
        private readonly IConsoleUI _userInterface;

        public PhoneBookApp(
            IMenus Menus,
            IConsoleUI userInterface)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _menus = Menus;
            _userInterface = userInterface;
        }

        public void Run()
        {
            _userInterface.PrintWelcomeScreen();

            int startchoice = _userInterface.PromptMenuChoice(_menus.Start.Keys);
            _menus.InvokeStartMethod(startchoice);

            while (true)
            {
                _userInterface.ClearAll();
                _userInterface.PrintLine("PhoneBook Menu:");

                int mainChoice = _userInterface.PromptMenuChoice(_menus.Main.Keys);
                _menus.InvokeMainMethod(mainChoice);
            }
        }
    }
}