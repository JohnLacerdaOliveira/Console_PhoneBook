using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public class PhoneBookApp
    {
        //TODO - Think of a way to store this and make the app dynamic to it
        private readonly List<string> _appOptions = new List<string>() {
        "Add Contact",
        "View All Contacts",
        "Search Contact",
        "Edit Contact",
        "Delete Contact",
        "Exit"};

        private readonly IEntriesRegister _entriesRepository;
        private readonly IConsoleUI _userInterface;
        private readonly IRepository _dataAccessor;


        public PhoneBookApp(
            IEntriesRegister entriesRepository,
            IConsoleUI userInterface,
            IRepository dataAccessor)
        {
            _entriesRepository = entriesRepository;
            _userInterface = userInterface;
            _dataAccessor = dataAccessor;
        }


        public void LoadData()
        {
            _dataAccessor.Read();
            _userInterface.PrintLine("The following contacts were load from repository");
            _entriesRepository.ViewAllContacts();
        }
        public void Run()
        {
            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");
                _userInterface.PrintMenu(_appOptions);


                char choice = Convert.ToChar(_userInterface.GetUserInput());
                _userInterface.PrintLine("");

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
                        ExitApplication();
                        return;
                    default:
                        _userInterface.PrintLine("Invalid choice. Please try again.");
                        break;
                }
                _userInterface.PressKeyToContinue();
            }
        }
        public void ExitApplication()
        {
            _userInterface.PrintLine("Exiting Phonebook. Goodbye!");
            _userInterface.PressKeyToContinue();
        }

    }
}