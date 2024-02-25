using Console_PhoneBook.App.Functionality;

namespace Console_PhoneBook.App
{
    public interface IMenus
    {
        public Dictionary<string, Action<IAppFunctionality>> Start { get; }
        public Dictionary<string, Action<IAppFunctionality>> Main { get; }
        public abstract void InvokeStartMethod(int selectedOption);
        public abstract void InvokeMainMethod(int selectedOption);
    }
}