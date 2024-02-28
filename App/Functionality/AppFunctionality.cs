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
        private readonly IRegister _contactsRegister;

        public AppFunctionality(
            IConsoleUI userInterface, 
            IRegister contactsRegister
            )
        {
            _userInterface = userInterface;
            _contactsRegister = contactsRegister;
        }

        //Redundant but whatever
        public void CreateNewPhoneBook()
        {
            _contactsRegister.Clear();
        }

        public void ImportPhoneBook()
        {
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
                var loadedContacts = repository.LoadFromFile(fileMetaData);
               
                foreach(var item in loadedContacts)
                {
                    _contactsRegister.Add(item);
                }

            }
            catch (Exception)
            {
                throw;
            }

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

        public void PrintAllContacts() => _userInterface.PrintAllContacts(_contactsRegister.Register);

        public IGenericContact Search()
        {
            IEnumerable<IGenericContact> matches = default;

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
                    matches = _contactsRegister.Register.Where(contact => contact.ToString().Contains(input, StringComparison.OrdinalIgnoreCase));
                }

                _userInterface.PrintAllContacts(matches, false);

                if (matches.Count() == 1) _userInterface.PrintLine("\nPress Enter to Select");

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

            } while (key.Key != ConsoleKey.Enter || matches.Count() != 1);

            _userInterface.SetCursorVisibilityTo(true);
            return matches.First();
        }

        public void AddContact()
        {
            var contactProperties = new Dictionary<string, string>();

            foreach (var property in typeof(IGenericContact).GetProperties())
            {
                _userInterface.Print($"Insert {property.Name}: ");

                //ReadLine already implements some basic verification
                contactProperties[property.Name] = _userInterface.ReadLine(); 
            }

            _contactsRegister.Add(new Contact(contactProperties));
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
            _contactsRegister.Delete(contactToDelete);
            _userInterface.PrintLine($"{contactToDelete.Name} was removed");      
        }

        public void ExportPhoneBook()
        {
            if (_contactsRegister.Register.Count() == 0)
            {
                _userInterface.PrintLine("");
                _userInterface.PrintLine("There are no contacts to export...");
                _userInterface.ReadKey(true);
                return;
            }

            var fileMetaData = GetExportFileMetadata();

            var exportRepository = RepositoryFactory.GetRepository(fileMetaData.FileExtension);
            exportRepository.SaveToFile(_contactsRegister.Register, fileMetaData);

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
            if (_contactsRegister.Register is not null)
            {
                if (_contactsRegister.Register.Count() != 0)
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