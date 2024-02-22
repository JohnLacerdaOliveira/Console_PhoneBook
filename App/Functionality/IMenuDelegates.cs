namespace Console_PhoneBook.App.Functionality
{
    public interface IMenuDelegates
    {
        public Dictionary<string, Action<IAppFunctionality>> MainMenu { get; }
        public IEnumerable<string> Options { get; }
        void InvokeCorrespondingMethod(int selectedOption);
    }
}