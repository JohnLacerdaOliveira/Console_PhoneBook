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


        public void AddEntry(IEnumerable<IGenericEntry> register)
        {
            // TODO - Don't hard code list
            var asList = register as List<IGenericEntry>;


            //TODO - Make the input dynamic from the entry properties
            _userInterface.Print("Insert Name: ");
            string nameInput = _userInterface.GetUserInput();

            _userInterface.Print("Insert Number: ");
            int.TryParse(_userInterface.GetUserInput(), out int numberInput);

            var entry = new Entry(nameInput, numberInput);

            if (asList is not null) asList.Add(entry);

        }

        public void PrintAllEntries(IEnumerable<IGenericEntry> register)
        {
            foreach (var entry in register)
            {
                _userInterface.PrintLine(entry.ToString());
            }
        }
        public IGenericEntry SearchByName(IEnumerable<IGenericEntry> register)
        {
            _userInterface.Print("Name to search: ");
            string searchName = _userInterface.GetUserInput();

            foreach (var entry in register)
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

        public IGenericEntry LiveSearch(IEnumerable<IGenericEntry> register)
        {
            List<IGenericEntry> asList = register as List<IGenericEntry>;
            List<IGenericEntry> matches = new List<IGenericEntry>();

            ConsoleKeyInfo key;
            string input = "";

            do
            {
                _userInterface.Clear();
                _userInterface.PrintLine($"Search: {input}");


                if (input.Length != 0)
                {
                    matches = register.Where(entry => entry.ToString().Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                foreach (var match in matches)
                {
                    _userInterface.PrintLine(match.ToString());
                }

                if (matches.Count == 1) _userInterface.PrintLine("Press Enter to Select");

                key = Console.ReadKey(true);

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

            return matches.First();
        }

        public void EditEntry(IEnumerable<IGenericEntry> register)
        {
            // TODO - Don't hard code list
            List<string> entryPropertyNames = new List<string>();

            var contactToEdit = LiveSearch(register);

            if (contactToEdit is not null)
            {
                _userInterface.PrintMenu(IGenericEntry.GetAllPropertiesNames());

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
            _userInterface.PrintLine("No entry found with that name...");
        }

        public void DeleteEntry(IEnumerable<IGenericEntry> register)
        {
            // TODO - Don't hard code list
            var asList = register as List<IGenericEntry>;
            var contactToDelete = LiveSearch(register);

            if (contactToDelete is not null)
            {
                asList.Remove(contactToDelete);
                _userInterface.PrintLine($"{contactToDelete.Name} was removed");
                return;
            }

            _userInterface.PrintLine("No entry found with that name...");
        }
    }
}