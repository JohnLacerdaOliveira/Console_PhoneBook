using Console_PhoneBook.App.Functionality;
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
        "Save Contacts",
        "Exit"};

        private readonly IEntriesRegister _entriesRegister;
        private readonly IConsoleUI _userInterface;
        private readonly IGenericRepository _dataRepository;


        public PhoneBookApp(
            IEntriesRegister entriesRegister,
            IConsoleUI userInterface,
            IGenericRepository dataRepository)
        {
            _entriesRegister = entriesRegister;
            _userInterface = userInterface;
            _dataRepository = dataRepository;
        }

        public void Run()
        {
            LoadData();
            
            while (true)
            {
                _userInterface.Clear();
                _userInterface.PrintLine("PhoneBook Menu:");
                _userInterface.PrintMenu(_appOptions);


                string choice = _userInterface.GetUserInput();
                _userInterface.PrintLine("");

                switch (choice)
                {
                    case "1": // Add Contact
                        _entriesRegister.AddEntry();
                        break;
                    case "2":  // View All Contacts
                        _entriesRegister.PrintAllEntries();
                        break;
                    case "3": // Search Contact
                        _entriesRegister.SearchEntry();
                        break;
                    case "4": // Edit Contact
                        _entriesRegister.EditEntry();
                        break;
                    case "5": // Delete Contact
                        _entriesRegister.DeleteEntry();
                        break;
                    case "6": // Delete Contact
                        SaveContacts();
                        break;
                    case "7":  // Exit
                        ExitApplication();
                        return;
                    default:
                        _userInterface.PrintLine("Invalid choice. Please try again.");
                        break;
                }
                _userInterface.PressKeyToContinue();
            }
        }
        public void LoadData()
        {
            _entriesRegister.Entries = _dataRepository.Load();
            _userInterface.PrintLine("The following contacts were load from repository");
            _entriesRegister.PrintAllEntries();
            _userInterface.PressKeyToContinue();
        }

        public void SaveContacts() 
        {
            _userInterface.PrintLine("All new contacts added will be added to the repository");
            _dataRepository.Save(_entriesRegister.Entries);
        }

        public void ExitApplication()
        {
            SaveContacts();
            _userInterface.PrintLine("Exiting Phonebook. Goodbye!");
        }

    }
}