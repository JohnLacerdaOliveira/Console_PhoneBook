namespace Console_PhoneBook.App.Functionality
{
    public interface IMenu
    {
        public Dictionary<string, Action<IAppFunctionality>> Main { get; }
        public Dictionary<string, Action<IAppFunctionality>> Start { get; }
        public abstract void InvokeStartMethod(int selectedOption);
        public abstract void InvokeMainMethod(int selectedOption);
    }
}