using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.UserInterface
{
    public interface IConsoleUI
    {
        public abstract void Print(string message);
        public abstract void PrintLine(string message);
        public abstract void PrintMenu(IEnumerable<string> options);
        public abstract string GetUserInput();
        public abstract void Clear();
        public abstract void PressKeyToContinue();
    }
}
