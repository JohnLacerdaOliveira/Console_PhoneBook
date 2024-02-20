using Console_PhoneBook.App;
using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook
{
    internal sealed class Program
    {
        //User Interface
        private static IConsoleUI _userInterface = new ConsoleUI();

        //Data Access
        private static FileMetaData _fileMetaData = new FileMetaData(FileFormat.json);
        private static IGenericRepository _dataRepository = _fileMetaData.GetRepository();

        //Model
        private static IContactsRegister _contactsRegister = new ContactsRegister();

        //Functionality
        private static IAppFunctionality _appFunctionality = new AppFunctionality(
            _userInterface,
            _dataRepository,
            _contactsRegister,
            _fileMetaData);
        private static IMenuDelegates _menuDelegates = new MenuDelegates(
            _appFunctionality);


        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _menuDelegates,
            _appFunctionality,
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