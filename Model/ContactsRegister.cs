using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.DataStorage.DataAccess;
using System.Collections.Generic;

namespace Console_PhoneBook.Model
{
    internal class ContactsRegister : IContactsRegister
    {
        public  IEnumerable<IGenericContact> Register { get; set; }

        public ContactsRegister()
        {
            Register = new List<IGenericContact>();

        }
    }
}
