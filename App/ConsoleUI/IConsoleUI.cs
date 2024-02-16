namespace Console_PhoneBook.App.UserInterface
{
    public interface IConsoleUI
    {
        public void Print(string message);
        public void PrintLine(string message);
        public void PrintMenu(IEnumerable<string> options);
        public string GetUserInput();
        public void Clear();
        public void PressKeyToContinue();
    }
}
