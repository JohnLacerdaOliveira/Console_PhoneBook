using Console_PhoneBook.App;
using Console_PhoneBook.Model;

namespace Console_PhoneBook
{
    internal class Program
    {
        private static IPhoneBookOperations _phoneBookOperations = new PhoneBookOperations();
        private static IEntriesRepository _entriesRepository = new EntriesRepository(_phoneBookOperations);

        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _entriesRepository);

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