﻿using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook.App.Functionality
{
    public interface IAppFunctionality
    {
        public abstract void CreateNewPhoneBook();
        public abstract void ImportPhoneBook();
        public abstract void PrintAllContacts();
        public abstract IGenericContact Search();
        public abstract void AddContact();
        public abstract void EditContact();
        public abstract void DeleteContact();
        public abstract void ExportPhoneBook();
        public abstract void ExitApplication();
        void LoadDemoPhoneBook();
    }
}