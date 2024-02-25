using Console_PhoneBook.App;
using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;

namespace Console_PhoneBook
{
    internal sealed class Program
    {
        //User Interface
        private static IConsoleUI _userInterface = new ConsoleUI();

        //Functionality
        private static IAppFunctionality _appFunctionality = new AppFunctionality(_userInterface);
        private static IMenus _mainMenuDelegates = new Menus(
            _appFunctionality);

        //Application Workflow
        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _mainMenuDelegates,
            _userInterface);

        static void Main(string[] args)
        {
            try
            {
                _phoneBookApp.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("global catch:");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}