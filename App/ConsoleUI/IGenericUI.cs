using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_PhoneBook.App.UserInterface
{
    public interface IGenericUI
    {
        public void PrintMessage(string message);

        public void PrintOptions(IEnumerable<string> options);

        public string GetUserInput();

        public void ClearConsole();

        public void PressKeyToContinue();
    }
}
