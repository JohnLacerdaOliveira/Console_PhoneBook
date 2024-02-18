using Console_PhoneBook.DataStorage.FileAccess;

namespace Console_PhoneBook.App.UserInterface
{
    public class ConsoleUI : IConsoleUI
    {
        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
        public void PrintEmptyLines(int numberOfEmptyLines)
        {
            for (int i = 0; i < numberOfEmptyLines; i++)
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

        public void PrintMenu(IEnumerable<string> options)
        {
            var counter = 1;

            foreach (var option in options)
            {
                PrintLine($"{counter++}. {option}");
            }
        }

        public int ReadMenuCoice(IEnumerable<string> options)
        {
            do
            {
                var key = Console.ReadKey(intercept: true);

                if (char.IsDigit(key.KeyChar))
                {
                    int option = int.Parse(key.KeyChar.ToString());

                    if (option > 0 && option <= options.Count()) return option;
                }

                PrintLine("Invalid choice. Please enter a valid option.");

            } while (true);

        }

        public string ReadLine()
        {
            do
            {
                string? userInput = Console.ReadLine();

                if (userInput != null && userInput.Length > 0) return userInput;

            } while (true);
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }


        public void PressKeyToContinue()
        {
            Console.ReadKey();
        }
        public void Clear()
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
            PrintCentered("Press any key to continue...".PadRight(40));
            PressKeyToContinue();
            Clear();
            SetCursorVisibilityTo(true);
        }

        public FileMetaData CreateNewFileMetadata()
        {

            //TODO - All this logic doesn't belong to the UI class, UI only gets the input, all the rest should be moved to AppFunctionality Class
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";


            // Get all enum values as strings
            IEnumerable<string> availableFileFormats = Enum.GetValues(typeof(FileFormat)).Cast<FileFormat>().Select(e => e.ToString());

            int selectedOption = default;
            bool IsValidOption = false;
            int option;

            Clear();
            PrintLine("Select export file type");
            PrintMenu(availableFileFormats);

            option = ReadMenuCoice(availableFileFormats);

            FileFormat enumValue = (FileFormat)(option - 1);

            PrintLine($"You'll find the .{enumValue} file on your desktop");

            return new FileMetaData(enumValue, desktopPath);

        }
    }
}
