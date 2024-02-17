using Console_PhoneBook.Model;

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

                if(userInput != null && userInput.Length > 0) isValidInput = true;

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
            PrintLine(@"
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

            PrintLine("Check GuiHub for more info https://github.com/JohnLacerdaOliveira/Console_PhoneBook");

            PressKeyToContinue();
        }
    }
}
