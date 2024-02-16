using Console_PhoneBook.App;

namespace Console_PhoneBook.Model
{
    public interface IEntriesRegister
    {
        public abstract IEnumerable<IGenericEntry> Entries { get; set; }
        public abstract void AddEntry();
        public abstract void PrintAllEntries();
        public abstract IGenericEntry SearchEntry();
        public abstract void EditEntry();
        public abstract void DeleteEntry();
    }
}
