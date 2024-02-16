﻿using Console_PhoneBook.App.Functionality;
using System.Collections.Generic;

namespace Console_PhoneBook.Model
{
    internal class EntriesRegister : IEntriesRegister
    {
        private IEnumerable<IGenericEntry> _entries;
        private IPhoneBookFunctionality _phoneBookOperations;

        public EntriesRegister(IPhoneBookFunctionality phoneBookOperations)
        {
            _entries = new List<IGenericEntry>();
            _phoneBookOperations = phoneBookOperations;
        }

        public void AddContact()
        {
            _phoneBookOperations.AddContact(_entries);
            _entries.GetType();
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
    }
}
