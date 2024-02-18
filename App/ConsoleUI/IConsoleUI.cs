﻿using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.UserInterface
{
    public interface IConsoleUI
    {
        public abstract void Print(string message);
        public abstract void PrintLine(string message);
        public abstract void PrintEmptyLines(int numberOfEmptyLines);
        public abstract void PrintCentered(string message);
        public abstract void PrintMenu(IEnumerable<string> options);
        public abstract int ReadMenuCoice(IEnumerable<string> options);
        public abstract string ReadLine();
        public abstract ConsoleKeyInfo ReadKey(bool intercept);
        public abstract void PressKeyToContinue();
        public abstract void Clear();
        public abstract void SetCursorVisibilityTo(bool choice);
        public abstract void PrintWelcomeScreen();
        public abstract FileMetaData CreateNewFileMetadata();
    }
}
