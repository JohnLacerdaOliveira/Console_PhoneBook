using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.Model;
using Microsoft.VisualBasic.FileIO;

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

        private readonly IEntriesRepository _entriesRepository;
        private readonly IConsoleUI _userInterface;


        public PhoneBookApp(IEntriesRepository entriesRepository, IConsoleUI userInterface)
        {
            _entriesRepository = entriesRepository;
            _userInterface = userInterface;
        }

        public void Run()
        {
            while (true)
            {
                _userInterface.ClearConsole();
                _userInterface.PrintMessage("PhoneBook Menu:");
                _userInterface.PrintOptions(_appOptions);
                

                char choice = Convert.ToChar(_userInterface.GetUserInput());
                _userInterface.PrintMessage("");

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
                        _userInterface.PrintMessage("Invalid choice. Please try again.");
                        break;
                }
                _userInterface.PressKeyToContinue();
            }
        }
        public void ExitApplication()
        {
            _userInterface.PrintMessage("Exiting Phonebook. Goodbye!");
            _userInterface.PressKeyToContinue();
        }

    }
}