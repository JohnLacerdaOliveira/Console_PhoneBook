using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public class PhoneBookOperations : IPhoneBookOperations
    {
        private IGenericUI _userInterface;

        public PhoneBookOperations(IGenericUI userInterface)
        {
            _userInterface = userInterface;
        }


        public void AddContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;

            _userInterface.PrintMessage("Insert Name:");
            string nameInput = _userInterface.GetUserInput();

            _userInterface.PrintMessage("Insert Number");
            string numberInput = _userInterface.GetUserInput();

            int.TryParse(numberInput, out int number);

            var entry = new GenericEntry(nameInput, number);

            asList.Add(entry);

        }

        public void ViewAllContacts(IEnumerable<IGenericEntry> repository)
        {
            foreach (var entry in repository)
            {
                _userInterface.PrintMessage(entry.ToString());
            }
        }
        public IGenericEntry SearchContact(IEnumerable<IGenericEntry> repository)
        {
            _userInterface.PrintMessage("Name to search: ");
            string searchName = _userInterface.GetUserInput();

            foreach (var entry in repository)
            {
                if (searchName == entry.Name)
                {
                    _userInterface.PrintMessage(entry.ToString());
                    return entry;
                }
            }

            _userInterface.PrintMessage("No entry found with that name...");
            return null;
        }
        public void EditContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            List<string> entryPropertyNames = new List<string>();

            //TODO - Find amore apropriate place for this
            foreach (var propertyName in typeof(IGenericEntry).GetProperties())
            {
                entryPropertyNames.Add(propertyName.Name);
            }

            var contactToEdit = SearchContact(repository);

            if (contactToEdit is not null)
            {
                _userInterface.PrintOptions(entryPropertyNames);

                var userChoice = _userInterface.GetUserInput();

                //TODO - Choice validation should be dynamic
                if (userChoice == "1")
                {
                    _userInterface.PrintMessage("Insert new name:");
                    string newName = _userInterface.GetUserInput();

                    _userInterface.PrintMessage($"{contactToEdit.Name} updated to {newName}");
                    contactToEdit.Name = newName;
                    return;
                }

                if (userChoice == "2")
                {
                    _userInterface.PrintMessage("Insert new number:");
                    int.TryParse(_userInterface.GetUserInput(), out int newNumber);

                    _userInterface.PrintMessage($"{contactToEdit.Name} number {contactToEdit.PhoneNumber} updated to {newNumber}");

                    contactToEdit.PhoneNumber = newNumber;
                    return;
                }

            }
            _userInterface.PrintMessage("No entry found with that name...");
        }

        public void DeleteContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;
            var contactToDelete = SearchContact(repository);

            if (contactToDelete is not null)
            {
                asList.Remove(contactToDelete);
                _userInterface.PrintMessage($"{contactToDelete.Name} was removed");
                return;
            }

            _userInterface.PrintMessage("Contact was not found");
        }

    }
}