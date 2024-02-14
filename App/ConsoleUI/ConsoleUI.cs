namespace Console_PhoneBook.App.ConsoleUI
{
    public class ConsoleUI : IGenericUI
    {

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOptions(IEnumerable<string> options)
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

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void PressKeyToContinue()
        {
            Console.ReadKey();
        }
    }
}
