using Console_PhoneBook.App;
using Console_PhoneBook.App.ConsoleUI;
using Console_PhoneBook.Model;

namespace Console_PhoneBook
{
    internal class Program
    {
        private static IGenericUI _userInterface = new ConsoleUI();
        private static IPhoneBookOperations _phoneBookOperations = new PhoneBookOperations(_userInterface);
        private static IEntriesRepository _entriesRepository = new EntriesRepository(_phoneBookOperations);

        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _entriesRepository,
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