using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.UserInterface
{
    public class ConsoleUI : IConsoleUI
    {
        public string? PromptImport(IEnumerable<string> candidates)
        {

            if (candidates.Count() == 0)
            {
                ClearAll();
                if (PromptYesOrNo("There appear to be no valid PhoneBooks, skip import")) return null;

                //TODO
                PrintLine("TODO : enter custom filepath with valid Phonebook...");
                return null;
            }

            if (candidates.Count() > 0)
            {
                ClearAll();
                if (PromptYesOrNo($"{candidates.Count()} PhoneBooks were found would, select one to import?"))
                {

                    ClearAll();
                    PrintLine("Select a PhoneBook:");

                    var shortenedCandidates = new List<string>();
                    foreach (var filePath in candidates)
                    {
                        shortenedCandidates.Add(filePath.Split("\\").Last());
                    }

                    Print("");
                    int choice = PromptMenuChoice(shortenedCandidates);

                    var index = 1;
                    foreach (var candidate in candidates)
                    {
                        if (index++ == choice) return candidate;
                    }

                }

                return null;
            }
            return null;

        }
        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOnce(string message)
        {
            Print("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            Print(message);
        }

        public void PrintAllContacts(IEnumerable<IGenericContact> register)
        {
            foreach (var contact in register)
            {
                PrintLine(contact.ToString());
            }

            PressKeyToContinue();
        }

        public void PrintEmptyLines(int numberOfEmptyLines)
        {
            for (int i = 1; i <= numberOfEmptyLines; i++)
            {
                PrintLine("");
            }
        }

        //TODO - Print Centered Works ok but not great
        public void PrintCentered(string message)
        {
            int width = Console.WindowWidth;
            string[] lines = message.Split(Environment.NewLine);

            // Calculate the number of spaces needed to center the text
            int longestLineLength = lines.Max(line => line.Length);
            int padding = (width - longestLineLength) / 2;

            // Print each line with the appropriate padding
            foreach (string line in lines)
            {
                PrintLine(line.PadLeft(padding + line.Length));
            }
        }

        public bool PromptYesOrNo(string question)
        {
            PrintLine($"{question} (Y/N):");
            PrintLine("");

            while (true)
            {
                var answer = ReadKey(true).KeyChar.ToString().ToLower();

                if (answer == "y") return true;
                if (answer == "n") return false;

                PrintOnce("Please enter 'y' for Yes or 'n' for No.");
            }
        }

        public int PromptMenuChoice(IEnumerable<string> options)
        {
            var counter = 1;

            foreach (var option in options)
            {
                PrintLine($"{counter++}. {option}");
            }

            PrintLine("");
            while (true)
            {
                var key = ReadKey(true);

                if (char.IsDigit(key.KeyChar))
                {
                    int option = int.Parse(key.KeyChar.ToString());

                    if (option > 0 && option <= options.Count()) return option;
                }
 
                PrintOnce("Invalid choice. Please enter a valid option.");
            }
        }

        public string ReadLine()
        {
            while (true)
            {
                string? userInput = Console.ReadLine();

                if (userInput != null && userInput.Length > 0) return userInput;
            }
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }


        public void PressKeyToContinue()
        {
            ReadKey(true);
        }

        public void ClearAll()
        {
            Console.Clear();
        }

        public void SetCursorVisibilityTo(bool choice)
        {
            Console.CursorVisible = choice;
        }

        public void PrintWelcomeScreen()
        {
            SetCursorVisibilityTo(false);
            string a = "Ctrl+Click to view on GitHub/JohnLacerdaOliveira/Console_PhoneBook";
            string hyperlink = $"\u001B]8;;https://github.com/JohnLacerdaOliveira/Console_PhoneBook\a{a}\u001B]8;;\a";

            var logo = (@"
           ____                      _                      
          / ___|___  _ __  ___  ___ | | ___                 
         | |   / _ \| '_ \/ __|/ _ \| |/ _ \                
         | |__| (_) | | | \__ \ (_) | |  __/                
          \____\___/|_| |_|___/\___/|_|\___|                
  ____  _                      ____              _    
 |  _ \| |__   ___  _ __   ___| __ )  ___   ___ | | __
 | |_) | '_ \ / _ \| '_ \ / _ \  _ \ / _ \ / _ \| |/ /
 |  __/| | | | (_) | | | |  __/ |_) | (_) | (_) |   < 
 |_|   |_| |_|\___/|_| |_|\___|____/ \___/ \___/|_|\_\            
");
            PrintCentered(logo);
            PrintEmptyLines(2);
            PrintCentered(hyperlink.PadLeft(155));
            PrintEmptyLines(6);
            PrintCentered("Press any key to continue...");
            PressKeyToContinue();
            ClearAll();
            SetCursorVisibilityTo(true);
        }

        public Dictionary<string, string?> GetFileMetaDataValues()
        {
            var fileMetaDataValues = new Dictionary<string, string?>();
            var properties = typeof(FileMetadata).GetProperties();

            foreach (var property in properties)
            {
                fileMetaDataValues.Add(property.Name, null);
            }

            //Get fileDirectory
            if (PromptYesOrNo("Would you like to export to Desktop ?"))
            {
                fileMetaDataValues["FileDirectory"] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                string directory;
                Print("Enter file directory: ");

                while (true)
                {
                    directory = ReadLine();

                    if (Directory.Exists(directory))
                    {
                        fileMetaDataValues["fileDirectory"] = directory;
                        break;
                    }
                }
            }

            //Get fileFormat
            IEnumerable<string> availableFileFormats = Enum.GetNames(typeof(FileExtensions));


            PrintLine("");
            PrintLine("Select export file format: ");
            int option = PromptMenuChoice(availableFileFormats);

            fileMetaDataValues["FileExtension"] = ((FileExtensions)(option - 1)).ToString();

            return fileMetaDataValues;
        }

        public void TerminateExecution()
        {
            Environment.Exit(0);
        }
    }
}
