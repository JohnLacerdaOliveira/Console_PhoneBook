﻿using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using Microsoft.Win32;

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

            while (true)
            {
                var answer = ReadKey(true).KeyChar.ToString().ToLower();

                if (answer == "y") return true;
                if (answer == "n") return false;

                PrintLine("Please enter 'y' for Yes or 'n' for No.");
            }
        }

        public int PromptMenuChoice(IEnumerable<string> options)
        {
            var counter = 1;

            foreach (var option in options)
            {
                PrintLine($"{counter++}. {option}");
            }

            while (true)
            {
                var key = ReadKey(true);

                if (char.IsDigit(key.KeyChar))
                {
                    int option = int.Parse(key.KeyChar.ToString());

                    if (option > 0 && option <= options.Count()) return option;
                }

                PrintLine("Invalid choice. Please enter a valid option.");
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
            PrintCentered("Press any key to continue...");
            PressKeyToContinue();
            Clear();
            SetCursorVisibilityTo(true);
        }

        public Dictionary<string, string?> GetFileMetaDataValues()
        {
            var fileMetaDataValues = new Dictionary<string, string?>()
            {
                ["fileDirectory"] = null,
                ["fileFormat"] = null
            };

            //Get fileDirectory
            if (PromptYesOrNo("Would you like to export to Desktop ?"))
            {
                fileMetaDataValues["fileDirectory"] = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
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
            IEnumerable<string> availableFileFormats = Enum.GetNames(typeof(FileFormat));


            PrintEmptyLines(2);
            PrintLine("Select export file format: ");
            int option = PromptMenuChoice(availableFileFormats);

            fileMetaDataValues["fileFormat"] = ((FileFormat)(option - 1)).ToString();

            return fileMetaDataValues;
        }

        public void TerminateExecution()
        {
            Environment.Exit(0);
        }
    }
}
