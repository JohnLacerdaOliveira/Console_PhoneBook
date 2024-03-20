using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    internal static class CommonTestData
    {
        private static readonly string _testFilesFolderName = "TestData";
        private static readonly string _testFilesDirectory = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName;

        internal static string FileName { get; } = "Test";
        internal static string TestDataFilePath { get; } = Path.Combine(_testFilesDirectory, _testFilesFolderName);

        internal static Contact BasicContactMock { get; } = new Contact
        {
            Name = It.IsAny<string>(),
            PhoneNumber = It.IsAny<string>()
        };

        internal static IEnumerable<IGenericContact> TestContacts { get; } = new List<IGenericContact>
        {
            new Contact
            {
                Name = "John Doe",
                Nickname = "Johnny",
                PhoneNumber = "+1234567890",
                Email = "john.doe@example.com",
                BirthDay = "1980-01-01",
                Address = "123 Main St, City, Country",
                Organization = "Example Corp",
                Title = "Software Engineer",
                Role = "Developer",
                Note = "This is a note about John Doe.",
            },
            new Contact
            {
                Name = "Alice Smith",
                Nickname = "Ali",
                PhoneNumber = "+1987654321",
                Email = "alice.smith@example.com",
                BirthDay = "1990-05-15",
                Address = "456 Oak St, Town, Country",
                Organization = "ABC Company",
                Title = "Marketing Manager",
                Role = "Manager",
                Note = "This is a note about Alice Smith.",
            },
            new Contact
            {
                Name = "Bob Johnson",
                Nickname = "Bobby",
                PhoneNumber = "+1122334455",
                Email = "bob.johnson@example.com",
                BirthDay = "1985-08-20",
                Address = "789 Maple Ave, Village, Country",
                Organization = "XYZ Corporation",
                Title = "Sales Representative",
                Role = "Sales",
                Note = "This is a note about Bob Johnson.",
            }
        };
    }
}
