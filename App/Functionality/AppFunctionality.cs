using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public class AppFunctionality : IAppFunctionality
    {
        private readonly IConsoleUI _userInterface;
        private readonly IGenericRepository _dataRepository;
        private List<IGenericContact> Register { get; set; }

        public AppFunctionality(
            IConsoleUI userInterface,
            IGenericRepository genericRepository,
            IContactsRegister contactsRegister)
        {
            _userInterface = userInterface;
            _dataRepository = genericRepository;
            //TODO - There must be a better way to deal with this
            Register = contactsRegister.Register as List<IGenericContact>;
        }

        public void ImportPhoneBook()
        {

            //TODO - menu option so import behaves acording to user preferences
            List<IGenericContact> loadedContacts;

            try
            {
                loadedContacts = _dataRepository.LoadDataFromFile() as List<IGenericContact>;

            }
            catch (Exception)
            {
                throw;
            }

            Register = loadedContacts;
            _userInterface.PrintLine("The following contacts were load from repository");
            PrintAllContacts();
            return;
        }

        public void PrintAllContacts() => _userInterface.PrintAllContacts(Register);

        public IGenericContact LiveSearch()
        {
            var matches = new List<IGenericContact>();

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
                    matches = Register.Where(contact => contact.ToString().Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
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

        public void AddContact()
        {
            var contact = new Dictionary<string, string>();

            foreach (var property in IGenericContact.GetAllPropertiesNames())
            {
                _userInterface.Print($"Insert {property}: ");

                contact[property] = _userInterface.ReadLine(); //ReadLine already implements some basic verification

            }
            //TODO - inplement a Contact contructor that takes a dictionary as input
            Register.Add(new Contact(contact));

        }

        public void EditContact()
        {
            var contactToEdit = LiveSearch();

            //TODO - See the need for IGenericContact.GetAllPropertiesNames()
            var contactProperties = contactToEdit.GetType().GetFields().Select(field => field.Name).ToArray();
            var menuChoice = _userInterface.PromptMenuChoice(contactProperties);

            var counter = 1;
            foreach (var property in contactProperties)
            {
                if (menuChoice == counter)
                {
                    _userInterface.Print($"Insert new {property}: ");
                    string value = _userInterface.ReadLine();

                    contactToEdit.GetType().GetProperty(property).SetValue(contactToEdit, value);
                }

                counter++;
            }
        }

        public void DeleteContact()
        {
            var contactToDelete = LiveSearch();

            Register.Remove(contactToDelete);
            _userInterface.PrintLine($"{contactToDelete.Name} was removed");
            return;

        }

        public void ExportPhoneBook()
        {
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();


            bool isValidFileFormat = Enum.TryParse(fileMetaDataValues["fileFormat"], out FileFormat fileFormat);
            bool isValidFileDirectory = fileMetaDataValues["fileDirectory"] is not null;

            if (isValidFileFormat && isValidFileDirectory)
            {
                var exportMetaData = new FileMetaData(fileFormat, fileMetaDataValues["fileDirectory"]);
                var exportRepository = exportMetaData.GetRepository();
                exportRepository.SaveDataToFile(Register);

                _userInterface.PrintLine("");
                _userInterface.PrintLine($"Success, you'll find the export file in {exportMetaData.FilePath}");
            }
        }

        public void ExitApplication()
        {
            _userInterface.PrintLine("All new contacts added will be added to the repository");
            _dataRepository.SaveDataToFile(Register);
            _userInterface.PrintLine("Exiting Phonebook. Goodbye!");
            _userInterface.PressKeyToContinue();
            _userInterface.TerminateExecution();
        }
    }
}