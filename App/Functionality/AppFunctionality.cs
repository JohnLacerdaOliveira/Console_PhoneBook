using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

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

            if (filePath is null || !File.Exists(filePath))
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

                foreach (var item in loadedContacts)
                {
                    _contactsRegister.Add(item);
                }


                _userInterface.ClearAll();
                _userInterface.PrintLine("");
                _userInterface.PrintLine("The following contacts were load from repository");
                _userInterface.PrintLine("");
                PrintAllContacts();
                return;
            }
            catch (Exception ex)
            {
                _userInterface.ClearAll();
                _userInterface.PrintLine($"An error occurred while loading the contacts: {ex.Message}");
                throw;
            }
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
                    if (file.EndsWith(filetype?.ToString()) &&
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

        public void PrintAllContacts() 
        {
            if (IsRegisterEmpty())
            {
                _userInterface.PrintLine("PhoneBook is empty! Press any key to continue.");
                _userInterface.ReadKey(true);
                return;
            }

            _userInterface.PrintAllContacts(_contactsRegister.Register);
        }
            

        public IGenericContact Search()
        {
            if (IsRegisterEmpty())
            {
                _userInterface.PrintLine("PhoneBook is empty! Press any key to continue.");
                _userInterface.ReadKey(true);
                return null;
            }

            IEnumerable<IGenericContact>? matches = default;

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
            if (IsRegisterEmpty())
            {
                _userInterface.PrintLine("PhoneBook is empty! Press any key to continue.");
                _userInterface.ReadKey(true);
                return;
            }

            var contactToEdit = Search();
            var genericContactProperties = typeof(IGenericContact).GetProperties().Select(p => p.Name);

            var menuChoice = _userInterface.PromptMenuChoice(genericContactProperties);

            var counter = 1;
            foreach (var property in genericContactProperties)
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
            if (IsRegisterEmpty()) 
            { 
                _userInterface.PrintLine("PhoneBook is empty! Press any key to continue.");
                _userInterface.ReadKey(true);
                return;
            }

            var contactToDelete = Search();
            _contactsRegister.Delete(contactToDelete);
            _userInterface.PrintLine($"{contactToDelete.Name} was removed");
        }

        private bool IsRegisterEmpty()
        {
            return !_contactsRegister.Register.Any();
        }

        public void ExportPhoneBook()
        {
            if (IsRegisterEmpty())
            {
                _userInterface.PrintLine("PhoneBook is empty! Press any key to continue.");
                _userInterface.ReadKey(true);
                return;
            }

            var fileMetaData = GetExportFileMetadata();

            var exportRepository = RepositoryFactory.GetRepository(fileMetaData.FileExtension);
            exportRepository.SaveToFile(_contactsRegister.Register, fileMetaData);

            _userInterface.PrintLine("");
            _userInterface.PrintLine($"Success, you'll find the export file in {fileMetaData.FilePath}");

        }

        private FileMetadata GetExportFileMetadata()
        {
            var fileMetaDataValues = _userInterface.GetFileMetaDataValues();
            bool isValidFileFormat = Enum.TryParse(fileMetaDataValues["FileExtension"], out FileExtensions fileFormat);

            return new FileMetadata(fileFormat, fileMetaDataValues["FileDirectory"]);
        }

        private FileMetadata GetImportFileMetadata(string filePath)
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

        public void LoadDemoPhoneBook()
        {
            var fileMetaData = GetImportFileMetadata(AppDomain.CurrentDomain.BaseDirectory + "/DemoPhoneBooks/PhoneBookRepository.csv");
            var repository = RepositoryFactory.GetRepository(fileMetaData.FileExtension);

            try
            {
                var loadedContacts = repository.LoadFromFile(fileMetaData);

                foreach (var item in loadedContacts)
                {
                    _contactsRegister.Add(item);
                }


                _userInterface.ClearAll();
                _userInterface.PrintLine("");
                _userInterface.PrintLine("The following contacts were load from repository");
                _userInterface.PrintLine("");
                PrintAllContacts();
                return;
            }
            catch (Exception ex)
            {
                _userInterface.ClearAll();
                _userInterface.PrintLine($"An error occurred while loading the contacts: {ex.Message}");
                throw;
            }
        }
    }
}