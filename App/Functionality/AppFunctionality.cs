using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public class AppFunctionality : IAppFunctionality
    {
        private readonly IConsoleUI _userInterface;
        private List<IGenericContact> Register { get; set; }
        private readonly IGenericRepository _dataRepository;

        public AppFunctionality(
            IConsoleUI userInterface,
            IContactsRegister contactsRegister,
            IGenericRepository genericRepository)
        {
            _userInterface = userInterface;
            Register = contactsRegister.Register as List<IGenericContact>;
            _dataRepository = genericRepository;
        }


        public void AddContact()
        {
            var input = new Dictionary<string, string>();

            foreach (var property in IGenericContact.GetAllPropertiesNames())
            {
                _userInterface.Print($"Insert {property}: ");
                string value = _userInterface.ReadLine();

                //TODO - Validate input new Contact input
                if (value is not null && value.Length > 0)
                {
                    input[property] = value;
                }
            }
            //TODO - inplement a Contact contructor that takes a dictionary as input
            Register.Add(new Contact(input["Name"], input["PhoneNumber"]));

        }

        public void PrintAllContacts()
        {
            foreach (var contact in Register)
            {
                _userInterface.PrintLine(contact.ToString());
            }

            _userInterface.PressKeyToContinue();
        }

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

        public void EditContact()
        {
            var contactToEdit = LiveSearch();

            //TODO - See the need for IGenericContact.GetAllPropertiesNames()
            var contactProperties = contactToEdit.GetType().GetFields().Select(field => field.Name).ToArray();

            _userInterface.PrintMenu(contactProperties);
            var menuChoice = _userInterface.ReadMenuCoice(contactProperties);

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

        public void ExportAllContacts()
        {
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();


            bool isValidFileFormat = Enum.TryParse<FileFormat>(fileMetaDataValues["fileFormat"], out FileFormat fileFormat);
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
        }

        public void LoadData()
        {
            List<IGenericContact> tryLoad;

            try
            {
                tryLoad = _dataRepository.LoadDataFromFile() as List<IGenericContact>;

            }
            catch (Exception ex)
            {
                throw;
            }

            Register = tryLoad;
            _userInterface.PrintLine("The following contacts were load from repository");
            PrintAllContacts();
            _userInterface.PressKeyToContinue();
            return;
        }
    }
}