using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public class PhoneBookOperations : IPhoneBookOperations
    {
        private IConsoleUI _userInterface;

        public PhoneBookOperations(IConsoleUI userInterface)
        {
            _userInterface = userInterface;
        }


        public void AddContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;

            //TODO - 
            /*
            foreach(var property in IGenericEntry.GetAllPropertiesNames())
            {

            }
            */
            _userInterface.Write("Insert Name: ");
            string nameInput = _userInterface.GetUserInput();

            _userInterface.Write("Insert Number: ");
            string numberInput = _userInterface.GetUserInput();

            int.TryParse(numberInput, out int number);

            var entry = new Entry(nameInput, number);

            asList.Add(entry);

        }

        public void ViewAllContacts(IEnumerable<IGenericEntry> repository)
        {
            foreach (var entry in repository)
            {
                _userInterface.WriteLine(entry.ToString());
            }
        }
        public IGenericEntry SearchContact(IEnumerable<IGenericEntry> repository)
        {
            _userInterface.Write("Name to search: ");
            string searchName = _userInterface.GetUserInput();

            foreach (var entry in repository)
            {
                if (searchName == entry.Name)
                {
                    _userInterface.WriteLine(entry.ToString());
                    return entry;
                }
            }

            _userInterface.WriteLine("No entry found with that name...");
            return null;
        }
        public void EditContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            List<string> entryPropertyNames = new List<string>();

            var contactToEdit = SearchContact(repository);

            if (contactToEdit is not null)
            {
                
                _userInterface.PrintOptions(IGenericEntry.GetAllPropertiesNames());

                var userChoice = _userInterface.GetUserInput();

                //TODO - Choice validation should be dynamic
                if (userChoice == "1")
                {
                    _userInterface.WriteLine("Insert new name:");
                    string newName = _userInterface.GetUserInput();

                    _userInterface.WriteLine($"{contactToEdit.Name} updated to {newName}");
                    contactToEdit.Name = newName;
                    return;
                }

                if (userChoice == "2")
                {
                    _userInterface.WriteLine("Insert new number:");
                    int.TryParse(_userInterface.GetUserInput(), out int newNumber);

                    _userInterface.WriteLine($"{contactToEdit.Name} number {contactToEdit.PhoneNumber} updated to {newNumber}");

                    contactToEdit.PhoneNumber = newNumber;
                    return;
                }

            }
            _userInterface.WriteLine("No entry found with that name...");
        }

        public void DeleteContact(IEnumerable<IGenericEntry> repository)
        {
            // TODO - Don't hard code list
            var asList = repository as List<IGenericEntry>;
            var contactToDelete = SearchContact(repository);

            if (contactToDelete is not null)
            {
                asList.Remove(contactToDelete);
                _userInterface.WriteLine($"{contactToDelete.Name} was removed");
                return;
            }

            _userInterface.WriteLine("Contact was not found");
        }

    }
}