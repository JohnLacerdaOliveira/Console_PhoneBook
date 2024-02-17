using Console_PhoneBook.DataStorage.FileAccess;
using System;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

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

        public void PrintMenu(IEnumerable<string> options)
        {
            var counter = 1;

            foreach (var option in options)
            {
                Console.WriteLine($"{counter++}. {option}");
            }
        }

        public string GetUserInput()
        {
            string? userInput;
            bool isValidInput = false;

            do
            {
                userInput = Console.ReadLine();

                if (userInput != null && userInput.Length > 0) isValidInput = true;

            } while (!isValidInput);

            return userInput;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void PressKeyToContinue()
        {
            Console.ReadKey();
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        public void SetCursorVisibilityTo(bool choice)
        {
            Console.CursorVisible = choice;
        }

        public void PrintWelcomeScreen()
        {
            var welcomeScreen = (@"
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
            int width = Console.WindowWidth;

            // Split the string into an array of lines
            string[] lines = welcomeScreen.Split(Environment.NewLine);

            // Calculate the number of spaces needed to center the text
            int longestLineLength = lines.Max(line => line.Length);
            int padding = (width - longestLineLength) / 2;

            // Print each line with the appropriate padding
            foreach (string line in lines)
            {
                PrintLine(line.PadLeft(padding + line.Length));
            }

            PressKeyToContinue();
            Clear();
        }

        public FileMetaData GetFileMetadata()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            
            
            // Get all enum values as strings
            IEnumerable<string> availableFileFormats = Enum.GetValues(typeof(FileFormat))
                                                   .Cast<FileFormat>()
                                                   .Select(e => e.ToString());
           

            int selectedOption = default;
            bool IsValidOption = false;
        
            do
            {
                Clear();
                PrintLine("Select export file type");
                PrintMenu(availableFileFormats);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string input= keyInfo.KeyChar.ToString();

                int.TryParse(input, out int option);

                for (int i = 1; i <= availableFileFormats.Count(); i++)
                {
                    if(option == i)
                    {
                        selectedOption = option;
                        IsValidOption = true;
                        break;
                    }
                }
                

            } while (!IsValidOption);

            FileFormat enumValue = (FileFormat)(selectedOption - 1);

            PrintLine($"You'll find the .{enumValue} file on your desktop");

            return new FileMetaData(enumValue,desktopPath);

        }
    }
}
