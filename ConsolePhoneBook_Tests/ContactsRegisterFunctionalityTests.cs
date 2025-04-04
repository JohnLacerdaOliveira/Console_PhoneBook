﻿using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    [TestFixture]
    internal class ContactsRegisterFunctionalityTests
    {
        private Contact _contactMock = CommonTestData.ContactMock;

        [Test]
        public void Constructor_CreatesRegisterSuccssefully_OnInstantiation()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();

            // Act
            var register = contactsRegister.Register;

            // Assert
            Assert.IsNotNull(register);
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(register);
        }

        [Test]
        public void Add_ContactAddedSuccessfully_WhenContactIsAdded()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();

            // Act
            contactsRegister.Add(_contactMock);

            // Assert
            Assert.AreEqual(1, contactsRegister.Register.Count());
            Assert.IsTrue(contactsRegister.Register.Contains(_contactMock));
        }

        [Test]
        public void Delete_ContactDeletedSuccessfully_WhenContactIsDeleted()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();
            contactsRegister.Add(_contactMock);

            // Act
            contactsRegister.Delete(_contactMock);

            // Assert
            Assert.AreEqual(0, contactsRegister.Register.Count());
            Assert.IsFalse(contactsRegister.Register.Contains(_contactMock));
        }

        [Test]
        public void Clear_RegisterClearedSuccessfully_WhenRegisterIsCleared()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();
            contactsRegister.Add(_contactMock);

            // Act
            contactsRegister.Clear();

            // Assert
            Assert.AreEqual(0, contactsRegister.Register.Count());
            Assert.IsFalse(contactsRegister.Register.Contains(_contactMock));
        }
    }
}
