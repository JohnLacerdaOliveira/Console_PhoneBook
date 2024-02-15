namespace Console_PhoneBook.App.UserInterface
{
    public interface IConsoleUI
    {
        public void Write(string message);
        public void WriteLine(string message);
        public void PrintOptions(IEnumerable<string> options);
        public string GetUserInput();
        public void ClearConsole();
        public void PressKeyToContinue();
    }
}
