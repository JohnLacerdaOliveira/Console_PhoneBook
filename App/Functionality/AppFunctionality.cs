using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace Console_PhoneBook.App.Functionality
{
    public class AppFunctionality : IAppFunctionality
    {
        private readonly IConsoleUI _userInterface;

        private List<IGenericContact> Register { get; set; } = new List<IGenericContact>();

        public AppFunctionality(
            IConsoleUI userInterface/*,
            IContactsRegister register*/)
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
            List<IGenericContact> loadedContacts;

            var candidates = LookUpValidFilesToImport();
            var filePath = _userInterface.PromptImport(candidates);

            if (filePath is null)
            {
                _userInterface.ClearAll();
                _userInterface.PrintLine("Application will start will blank PhoneBook");
                _userInterface.PrintLine("");
                _userInterface.PrintLine("Press any key to continue...");
                _userInterface.ReadKey(true);
                CreateNewPhoneBook();
                return;
            }
     
            var fileMetaData = GetImportFileMetadata(filePath);
            var repository = RepositoryFactory.GetRepository(fileMetaData.FileExtension);

            try
            {
                loadedContacts = repository.LoadFromFile(fileMetaData) as List<IGenericContact>;

            }
            catch (Exception)
            {
                throw;
            }

            Register = loadedContacts;
            _userInterface.ClearAll();
            _userInterface.PrintLine("");
            _userInterface.PrintLine("The following contacts were load from repository");
            _userInterface.PrintLine("");
            PrintAllContacts();
            return;
        }

        private IEnumerable<string> LookUpValidFilesToImport()
        {
            List<string> validFilesToImport = new List<string>();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] candidateFiles = Directory.GetFiles(currentDirectory, "*", SearchOption.AllDirectories);

            var supportedFileTypes = Enum.GetValues(typeof(FileExtensions));

            foreach (var file in candidateFiles)
            {
                foreach (var filetype in supportedFileTypes)
                {
                    if (file.EndsWith(filetype.ToString()) &&
                        !file.Contains("runtime") &&
                        !file.Contains("dep"))
                    {
                        validFilesToImport.Add(file);
                        break;
                    }
                }
            }
            return validFilesToImport;
        }

        public void PrintAllContacts() => _userInterface.PrintAllContacts(Register);

        public IGenericContact Search()
        {
            var matches = new List<IGenericContact>();

            ConsoleKeyInfo key;
            string input = "";

            do
            {
                _userInterface.ClearAll();
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
            var contactProperties = new Dictionary<string, string>();

            foreach (var property in typeof(IGenericContact).GetProperties())
            {
                _userInterface.Print($"Insert {property.Name}: ");

                contactProperties[property.Name] = _userInterface.ReadLine(); //ReadLine already implements some basic verification

            }

            Register.Add(new Contact(contactProperties));
        }

        public void EditContact()
        {
            var contactToEdit = Search();
            var contactProperties = typeof(IGenericContact).GetProperties().Select(p => p.Name);

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
            var contactToDelete = Search();
            Register.Remove(contactToDelete);
            _userInterface.PrintLine($"{contactToDelete.Name} was removed");      
        }

        public void ExportPhoneBook()
        {
            if (Register.Count() == 0)
            {
                _userInterface.PrintLine("");
                _userInterface.PrintLine("There are no contacts to export...");
                _userInterface.ReadKey(true);
                return;
            }

            var fileMetaData = GetExportFileMetadata();

            var exportRepository = RepositoryFactory.GetRepository(fileMetaData.FileExtension);
            exportRepository.SaveToFile(Register, fileMetaData);

            _userInterface.PrintLine("");
            _userInterface.PrintLine($"Success, you'll find the export file in {fileMetaData.FilePath}");

        }

        //TODO - review implementation
        public FileMetadata GetExportFileMetadata()
        {
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();
            bool isValidFileFormat = Enum.TryParse(fileMetaDataValues["FileExtension"], out FileExtensions fileFormat);

            // TODO - fails to export to a file that doesn't already exists


            if (isValidFileFormat)
            {
                return new FileMetadata(fileFormat, fileMetaDataValues["FileDirectory"]);
            }

            throw new NotImplementedException();
        }

        //TODO - review implementation
        public FileMetadata GetImportFileMetadata(string filePath)
        {
            var fileName = Path.GetFileName(filePath).Split(".")[0];
            var fileExtension = Path.GetFileName(filePath).Split(".")[1];
            var fileDirectory = Path.GetDirectoryName(filePath);

            Enum.TryParse(fileExtension, out FileExtensions extension);

            return new FileMetadata(extension, fileDirectory, fileName);
        }

        public void ExitApplication()
        {
            if (Register is not null)
            {
                if (Register.Count() != 0)
                {
                    var shouldSave = _userInterface.PromptYesOrNo("Save contacts before exiting?");

                    if (shouldSave)
                    {
                        ExportPhoneBook();
                    }
                }
            }

            _userInterface.ClearAll();
            _userInterface.PrintLine("Exiting Phonebook. Goodbye!");
            _userInterface.PressKeyToContinue();
            _userInterface.TerminateExecution();
        }
    }
}