using Console_PhoneBook.App;

namespace Console_PhoneBook.Model
{
    internal class EntriesRepository : IEntriesRepository
    {
        private List<IGenericEntry> _entries { get; set; }
        public IPhoneBookOperations _phoneBookOperations;

        public EntriesRepository(IPhoneBookOperations phoneBookOperations)
        {
            _entries = new List<IGenericEntry>();
            _phoneBookOperations = phoneBookOperations;
        }

        public void AddContact()
        {
            _phoneBookOperations.AddContact(_entries);


        }

        public void ViewAllContacts()
        {
            _phoneBookOperations.ViewAllContacts(_entries);

        }

        public IGenericEntry SearchContact()
        {
            return _phoneBookOperations.SearchContact(_entries);

        }

        public void EditContact()
        {
            _phoneBookOperations.EditContact(_entries);
        }

        public void DeleteContact()
        {
            _phoneBookOperations.DeleteContact(_entries);

        }

        public void ExitApplication()
        {
            Console.WriteLine("Exiting Phonebook. Goodbye!");
            Console.ReadLine();
        }
    }
}
