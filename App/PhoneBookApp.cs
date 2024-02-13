using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        private readonly IEntriesRepository _entriesRepository;


        public PhoneBookApp(IEntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;

        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("PhoneBook Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View All Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                char choice = Console.ReadKey().KeyChar;

                
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        // Add Contact
                        _entriesRepository.AddContact();
                        break;
                    case '2':
                        // View All Contacts
                        _entriesRepository.ViewAllContacts();
                        break;
                    case '3':
                        // Search Contact
                        _entriesRepository.SearchContact();
                        break;
                    case '4':
                        // Edit Contact
                        _entriesRepository.EditContact();
                        break;
                    case '5':
                        // Delete Contact
                        _entriesRepository.DeleteContact();
                        break;
                    case '6':
                        // Exit
                        _entriesRepository.ExitApplication();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}