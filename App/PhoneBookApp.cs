using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {  
        //TODO - Still need to understand this
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

            int startchoice = _userInterface.PromptMenuChoice(_menus.Start.Keys);
            _menus.InvokeStartMethod(startchoice);

            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");

                int choice = _userInterface.PromptMenuChoice(_menus.Main.Keys);
                _menus.InvokeMainMethod(choice);
            }
        }
    }
}