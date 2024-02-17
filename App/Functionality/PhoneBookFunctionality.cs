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


        public void AddContact(IEnumerable<IGenericContact> register)
        {
            // TODO - Don't hard code list
            var asList = register as List<IGenericContact>;


            //TODO - Make the input dynamic from the contact properties
            _userInterface.Print("Insert Name: ");
            string nameInput = _userInterface.GetUserInput();

            _userInterface.Print("Insert Number: ");
            int.TryParse(_userInterface.GetUserInput(), out int numberInput);

            var contact = new Contact(nameInput, numberInput);

            if (asList is not null) asList.Add(contact);

        }

        public void PrintAllContacts(IEnumerable<IGenericContact> register)
        {
            foreach (var contact in register)
            {
                _userInterface.PrintLine(contact.ToString());
            }
        }
        public IGenericContact SearchByName(IEnumerable<IGenericContact> register)
        {
            _userInterface.Print("Name to search: ");
            string searchName = _userInterface.GetUserInput();

            foreach (var contact in register)
            {
                if (searchName == contact.Name)
                {
                    _userInterface.PrintLine(contact.ToString());
                    return contact;
                }
            }

            _userInterface.PrintLine("No contact found with that name...");
            return null;
        }

        public IGenericContact LiveSearch(IEnumerable<IGenericContact> register)
        {
            List<IGenericContact> asList = register as List<IGenericContact>;
            List<IGenericContact> matches = new List<IGenericContact>();

            ConsoleKeyInfo key;
            string input = "";

            do
            {
                _userInterface.Clear();
                _userInterface.SetCursorVisibilityTo(false);
                _userInterface.PrintLine($"Search: {input}\n");

                if (input.Length == 0) matches = new List<IGenericContact>();

                if (input.Length != 0)
                {
                    matches = register.Where(contact => contact.ToString().Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                foreach (var match in matches)
                {
                    _userInterface.PrintLine(match.ToString());
                }

                if (matches.Count == 1) _userInterface.PrintLine("\nPress Enter to Select");

                key = _userInterface.ReadKey(true);

                if (key.Key != ConsoleKey.Escape)
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        input += key.KeyChar;
                    }
                }

            } while (key.Key != ConsoleKey.Enter || matches.Count != 1);

            _userInterface.SetCursorVisibilityTo(true);
            return matches.First();
        }

        public void EditContact(IEnumerable<IGenericContact> register)
        {
            // TODO - Don't hard code list
            List<string> contactPropertyNames = new List<string>();

            var contactToEdit = LiveSearch(register);

            if (contactToEdit is not null)
            {
                _userInterface.PrintMenu(IGenericContact.GetAllPropertiesNames());

                var userChoice = _userInterface.GetUserInput();

                //TODO - Choice validation should be dynamic
                if (userChoice == "1")
                {
                    _userInterface.Print("Insert new name:");
                    string newName = _userInterface.GetUserInput();

                    _userInterface.PrintLine($"{contactToEdit.Name} updated to {newName}");
                    contactToEdit.Name = newName;
                    return;
                }

                if (userChoice == "2")
                {
                    _userInterface.Print("Insert new number:");
                    int.TryParse(_userInterface.GetUserInput(), out int newNumber);

                    _userInterface.PrintLine($"{contactToEdit.Name} number {contactToEdit.PhoneNumber} updated to {newNumber}");
                    contactToEdit.PhoneNumber = newNumber;
                    return;
                }

            }
            _userInterface.PrintLine("No contact found with that name...");
        }

        public void DeleteContact(IEnumerable<IGenericContact> register)
        {
            // TODO - Don't hard code list
            var asList = register as List<IGenericContact>;
            var contactToDelete = LiveSearch(register);

            if (contactToDelete is not null)
            {
                asList.Remove(contactToDelete);
                _userInterface.PrintLine($"{contactToDelete.Name} was removed");
                return;
            }

            _userInterface.PrintLine("No contact found with that name...");
        }
    }
}