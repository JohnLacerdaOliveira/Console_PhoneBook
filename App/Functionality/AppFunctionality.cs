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
            IConsoleUI userInterface)
        {
            _userInterface = userInterface;
        }

        //TODO - It is a bit stupid this method works empty
        public void CreateNewPhoneBook()
        {
            Register = new List<IGenericContact>();
        }

        public void ImportPhoneBook()
        {
            //TODO - menu option so import behaves acording to user preferences
            List<IGenericContact> loadedContacts;

            var candidates = LookUpValidFilesToImport();
            var filePath = _userInterface.PromptImport(candidates);

            if (filePath is null)
            {
                _userInterface.PrintLine("");
                _userInterface.PrintLine("Application will start will blank PhoneBook");
                _userInterface.ReadKey(true);
                CreateNewPhoneBook();
                return;
            }

            //TODO - create new file metadata intance to pass the correct handler to the Load Data
            //GetFileMetaData();


            try
            {
                loadedContacts = _dataRepository.LoadDataFromFile(GetExportFileMetaData()) as List<IGenericContact>;

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

        private IEnumerable<string> LookUpValidFilesToImport()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories);

            var supportedFileTypes = FileFormat.json.GetAllSupportedFileFormats();
            List<string> validFilesToImport = new List<string>();

            foreach (var file in files)
            {
                foreach (var filetype in supportedFileTypes)
                {
                    if (file.EndsWith(filetype) &&
                        !file.Contains("runtime") &&
                        !file.Contains("dep"))
                    {
                        validFilesToImport.Add(file);
                    }
                }
            }
            return validFilesToImport;
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

            var fileMetaData = GetExportFileMetaData();



            var exportRepository = RepositoryFactory.GetRepository(fileMetaData.FileFormat);
            exportRepository.SaveDataToFile(Register, fileMetaData);

            _userInterface.PrintLine("");
            _userInterface.PrintLine($"Success, you'll find the export file in {fileMetaData.FilePath}");

        }

        //TODO - review implementation
        public FileMetaData GetExportFileMetaData()
        {
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();

            bool isValidFileFormat = Enum.TryParse(fileMetaDataValues["fileFormat"], out FileFormat fileFormat);
            bool isValidFileDirectory = fileMetaDataValues["fileDirectory"] is not null;

            if (isValidFileFormat && isValidFileDirectory)
            {
                return new FileMetaData(fileMetaDataValues);
            }

            throw new NotImplementedException();
        }

        //TODO - review implementation
        public FileMetaData GetImportFileMetaData(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);
            var fileName = Path.GetFileName(filePath);
            var fileDirectory = Path.GetDirectoryName(filePath);

           
            
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();

            bool isValidFileFormat = Enum.TryParse(fileMetaDataValues["fileFormat"], out FileFormat fileFormat);
            bool isValidFileDirectory = fileMetaDataValues["fileDirectory"] is not null;
            if (isValidFileFormat && isValidFileDirectory)
            {
                new FileMetaData(fileMetaDataValues);
            }

            throw new NotImplementedException();
        }

        public void ExitApplication()
        {
            //TODO - rethink auto save 

            //_userInterface.PrintLine("All new contacts added will be added to the repository");
            // _dataRepository.SaveDataToFile(Register);
            _userInterface.PrintLine("Exiting Phonebook. Goodbye!");
            _userInterface.PressKeyToContinue();
            _userInterface.TerminateExecution();
        }
    }
}