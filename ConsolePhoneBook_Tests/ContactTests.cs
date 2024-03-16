using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Constructor_WithValidDictionary_InitializesContact()
        {
            // Arrange
            var contactValues = new Dictionary<string, string>
            {
                { "Name", It.IsAny<string>() },
                { "PhoneNumber", It.IsAny<string>() }
            };

            // Act
            var contact = new Contact(contactValues);

            // Assert
            Assert.AreEqual(It.IsAny<string>(), contact.Name);
            Assert.AreEqual(It.IsAny<string>(), contact.PhoneNumber);
        }

        [TestCase("John Doe", "123456789")]
        public void ToString_ReturnsConcatenatedValues(string name, string phoneNumber)
        {
            // Arrange
            var contact = new Contact
            {
                Name = name,
                PhoneNumber = phoneNumber
            };

            // Act
            var result = contact.ToString();

            // Assert
            Assert.AreEqual($"{name} {phoneNumber}", result);
        }
    }
}
