using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.DataStorage.DataAccess;
using System.Collections.Generic;

namespace Console_PhoneBook.Model
{
    internal class ContactsRegister : IContactsRegister
    {
        public  IEnumerable<IGenericContact> Contacts { get; set; }
        private readonly IPhoneBookFunctionality _phoneBookFunctionality;

        public ContactsRegister(IPhoneBookFunctionality phoneBookFunctionality)
        {
            Contacts = new List<IGenericContact>();
            _phoneBookFunctionality = phoneBookFunctionality;
        }

        public void AddContact()
        {
            _phoneBookFunctionality.AddContact(Contacts); 
        }

        public void PrintAllContacts()
        {
            _phoneBookFunctionality.PrintAllContacts(Contacts);

        }

        public IGenericContact SearchContact()
        {
            return _phoneBookFunctionality.LiveSearch(Contacts);

        }

        public void EditContact()
        {
            _phoneBookFunctionality.EditContact(Contacts);
        }

        public void DeleteContact()
        {
            _phoneBookFunctionality.DeleteContact(Contacts);

        }
    }
}
