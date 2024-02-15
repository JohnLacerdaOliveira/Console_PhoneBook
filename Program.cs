using Console_PhoneBook.App;
using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook
{
    internal class Program
    {
        //User Interface
        private static IConsoleUI _userInterface = new ConsoleUI();

        //Data Access
        private static FileMetaData _fileMetaData = new FileMetaData("PhoneBookRepository", FileFormat.csv);
        private static IRepository _dataAccessor = new GenericRepository(_fileMetaData);

        //Functionality
        private static IPhoneBookOperations _phoneBookOperations = new PhoneBookOperations(_userInterface);

        //Model
        private static IEntriesRegister _entriesRepository = new EntriesRegister(_phoneBookOperations);

        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _entriesRepository,
            _userInterface,
            _dataAccessor);

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