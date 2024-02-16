using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.DataStorage.DataAccess;
using System.Collections.Generic;

namespace Console_PhoneBook.Model
{
    internal class EntriesRegister : IEntriesRegister
    {
        public  IEnumerable<IGenericEntry> Entries { get; set; }
        private readonly IPhoneBookFunctionality _phoneBookFunctionality;

        public EntriesRegister(IPhoneBookFunctionality phoneBookFunctionality)
        {
            Entries = new List<IGenericEntry>();
            _phoneBookFunctionality = phoneBookFunctionality;
        }

        public void AddEntry()
        {
            _phoneBookFunctionality.AddEntry(Entries); 
        }

        public void PrintAllEntries()
        {
            _phoneBookFunctionality.PrintAllEntries(Entries);

        }

        public IGenericEntry SearchEntry()
        {
            return _phoneBookFunctionality.SearchEntry(Entries);

        }

        public void EditEntry()
        {
            _phoneBookFunctionality.EditEntry(Entries);
        }

        public void DeleteEntry()
        {
            _phoneBookFunctionality.DeleteEntry(Entries);

        }
    }
}
