﻿using Console_PhoneBook.App;
using Console_PhoneBook.App.Functionality;
using Console_PhoneBook.App.UserInterface;
using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

namespace Console_PhoneBook
{
    internal class Program
    {
        //User Interface
        private static IConsoleUI _userInterface = new ConsoleUI();

        //Data Access
        private static FileMetaData _fileMetaData = new FileMetaData(FileFormat.vcf);
        private static IGenericRepository _dataRepository = _fileMetaData.GetRepository();

        //Functionality
        private static IPhoneBookFunctionality _phoneBookOperations = new PhoneBookFunctionality(_userInterface);

        //Model
        private static IContactsRegister _entriesRegistry = new ContactsRegister(_phoneBookOperations);

        private static PhoneBookApp _phoneBookApp = new PhoneBookApp(
            _entriesRegistry,
            _userInterface,
            _dataRepository);

        static void Main(string[] args)
        {
            try
            {
                _phoneBookApp.Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine("global catch:");
                Console.WriteLine(ex.ToString());
            }
        }

    }
}