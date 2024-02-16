using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public class PhoneBookFunctionality : IPhoneBookFunctionality
    {
        private IConsoleUI _userInterface;

        public PhoneBookFunctionality(IConsoleUI userInterface)
        {
            _userInterface = userInterface;
        }


        public void AddContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;

            //TODO - perhaps  use a dictionary with wht property names as keys
            /*
            foreach(var property in IGenericEntry.GetAllPropertiesNames())
            {

            }
            */
            _userInterface.Print("Insert Name: ");
            string nameInput = _userInterface.GetUserInput();

            _userInterface.Print("Insert Number: ");
            string numberInput = _userInterface.GetUserInput();

            int.TryParse(numberInput, out int number);

            var entry = new Entry(nameInput, number);

            asList.Add(entry);

        }

        public void ViewAllContacts(IEnumerable<IGenericEntry> repository)
        {
            foreach (var entry in repository)
            {
                _userInterface.PrintLine(entry.ToString());
            }
        }
        public IGenericEntry SearchContact(IEnumerable<IGenericEntry> repository)
        {
            _userInterface.Print("Name to search: ");
            string searchName = _userInterface.GetUserInput();

            foreach (var entry in repository)
            {
                if (searchName == entry.Name)
                {
                    _userInterface.PrintLine(entry.ToString());
                    return entry;
                }
            }

            _userInterface.PrintLine("No entry found with that name...");
            return null;
        }
        public void EditContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            List<string> entryPropertyNames = new List<string>();

            var contactToEdit = SearchContact(repository);

            if (contactToEdit is not null)
            {

                _userInterface.PrintMenu(IGenericEntry.GetAllPropertiesNames());

                var userChoice = _userInterface.GetUserInput();

                //TODO - Choice validation should be dynamic
                if (userChoice == "1")
                {
                    _userInterface.PrintLine("Insert new name:");
                    string newName = _userInterface.GetUserInput();

                    _userInterface.PrintLine($"{contactToEdit.Name} updated to {newName}");
                    contactToEdit.Name = newName;
                    return;
                }

                if (userChoice == "2")
                {
                    _userInterface.PrintLine("Insert new number:");
                    int.TryParse(_userInterface.GetUserInput(), out int newNumber);

                    _userInterface.PrintLine($"{contactToEdit.Name} number {contactToEdit.PhoneNumber} updated to {newNumber}");

                    contactToEdit.PhoneNumber = newNumber;
                    return;
                }

            }
            _userInterface.PrintLine("No entry found with that name...");
        }

        public void DeleteContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;
            var contactToDelete = SearchContact(repository);

            if (contactToDelete is not null)
            {
                asList.Remove(contactToDelete);
                _userInterface.PrintLine($"{contactToDelete.Name} was removed");
                return;
            }

            _userInterface.PrintLine("Contact was not found");
        }

    }
}