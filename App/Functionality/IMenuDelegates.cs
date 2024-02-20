namespace Console_PhoneBook.App.Functionality
{
    public interface IMenuDelegates
    {
        public Dictionary<string, Action<IAppFunctionality>> Delegates { get; }
        public IEnumerable<string> Options { get; }
        void InvokeCorrespondingMethod(int selectedOption);
    }
}