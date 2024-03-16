using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    [TestFixture]
    internal class GenericRegisterTests
    {
        private Contact _testContactMock;

        [SetUp]
        public void Setup()
        {
            _testContactMock = new Contact
            {
                Name = It.IsAny<string>(),
                PhoneNumber = It.IsAny<string>()
            };
        }

        [Test]
        public void Constructor_RegisterInitialized()
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
        public void Add_ContactAddedSuccessfully()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();

            // Act
            contactsRegister.Add(_testContactMock);

            // Assert
            Assert.AreEqual(1, contactsRegister.Register.Count());
            Assert.IsTrue(contactsRegister.Register.Contains(_testContactMock));
        }


        [TestCase("AnyName","000000000")]
        public void Edit_ContactEditedSuccessfully(string newName, string newNumber)
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();
            contactsRegister.Add(_testContactMock);

            // Act
            _testContactMock.Name = newName;
            _testContactMock.PhoneNumber = newNumber;
            contactsRegister.Edit(_testContactMock);

            // Assert
            Assert.AreEqual(1, contactsRegister.Register.Count());
            Assert.IsTrue(contactsRegister.Register.Any(n => n.Name.Equals(newName)));
            Assert.IsTrue(contactsRegister.Register.Any(n => n.PhoneNumber.Equals(newNumber)));
        }

        [Test]
        public void Edit_NonExistentContact_ShouldFail()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();

            // Act
            contactsRegister.Edit(_testContactMock);

            // Assert
            Assert.AreEqual(0, contactsRegister.Register.Count());
            Assert.IsFalse(contactsRegister.Register.Any(c => c.Name.Equals(It.IsAny<string>)));
            Assert.IsFalse(contactsRegister.Register.Any(c => c.PhoneNumber.Equals(It.IsAny<string>)));
        }

        [Test]
        public void Delete_ContactDeletedSuccessfully()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();
            contactsRegister.Add(_testContactMock);

            // Act
            contactsRegister.Delete(_testContactMock);

            // Assert
            Assert.AreEqual(0, contactsRegister.Register.Count());
            Assert.IsFalse(contactsRegister.Register.Contains(_testContactMock));
        }

        [Test]
        public void Clear_RegisterClearedSuccessfully()
        {
            // Arrange
            var contactsRegister = new ContactsRegister<List<IGenericContact>>();
            contactsRegister.Add(_testContactMock);

            // Act
            contactsRegister.Clear();

            // Assert
            Assert.AreEqual(0, contactsRegister.Register.Count());
        }
    }
}
