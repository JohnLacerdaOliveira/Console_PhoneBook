using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.UserInterface
{
    public interface IConsoleUI
    {
        public abstract string? PromptImport(IEnumerable<string> candidates);
        public abstract void Print(string message);
        public abstract void PrintLine(string message);
        public abstract void PrintOnce(string message);
        public abstract void PrintAllContacts(IEnumerable<IGenericContact> register);
        public abstract void PrintEmptyLines(int numberOfEmptyLines);
        public abstract void PrintCentered(string message);
        public abstract bool PromptYesOrNo(string question);
        public abstract int PromptMenuChoice(IEnumerable<string> options);
        public abstract string ReadLine();
        public abstract ConsoleKeyInfo ReadKey(bool intercept);
        public abstract void PressKeyToContinue();
        public abstract void ClearAll();
        public abstract void SetCursorVisibilityTo(bool choice);
        public abstract void PrintWelcomeScreen();
        public abstract Dictionary<string, string?> GetFileMetaDataValues();
        public abstract void TerminateExecution();
    }
}
