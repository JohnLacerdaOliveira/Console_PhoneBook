using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    internal static class CommonTestData
    {
        internal static Contact ContactMock { get; } = new Contact
        {
            Name = It.IsAny<string>(),
            PhoneNumber = It.IsAny<string>()
        };

    internal static IEnumerable<IGenericContact> TestContacts { get; } = new List<IGenericContact>
        {
            new Contact { Name = "John Doe", PhoneNumber = "911234567" },
            new Contact { Name = "Jane Smith", PhoneNumber = "922345678" },
            new Contact { Name = "Michael Johnson", PhoneNumber = "933456789" }
        };

        private static readonly string _testFilesFolderName = "TestData";
        private static readonly string _testFilesDirectory = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName;

        internal static string FileName { get; } = "Test";
        internal static string TestDataFilePath { get; } = Path.Combine(_testFilesDirectory, _testFilesFolderName);
    }
}
