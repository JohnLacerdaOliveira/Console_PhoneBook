using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    [TestFixture]
    internal class RepositoryHandlerTests
    {
        private const int _numberOfTestContacts = 20;
        private readonly string _testFilesFolderName = "TestData";
        private readonly string _fileName = "Test";
        private readonly string _testFilesDirectory = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName;

        private string testDataFilePath;

        private Mock<CSVHandler> _csvHandlerMock;
        private Mock<JSONHandler> _jsonHandlerMock;
        private Mock<VCFHandler> _vcfHandlerMock;
        private Mock<XMLHandler> _xmlHandlerMock;

        [SetUp]
        public void Setup()
        {
            testDataFilePath = Path.Combine(_testFilesDirectory, _testFilesFolderName);
            _csvHandlerMock = new Mock<CSVHandler>() { CallBase = true };
            _jsonHandlerMock = new Mock<JSONHandler>() { CallBase = true };
            _vcfHandlerMock = new Mock<VCFHandler>() { CallBase = true };
            _xmlHandlerMock = new Mock<XMLHandler>() { CallBase = true };
        }

        [Test]
        public void LoadFromFile_ValidCSVFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.csv,
                testDataFilePath,
                _fileName);

            // Act
            var result = _csvHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [Test]
        public void LoadFromFile_ValidJSONFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.json,
                testDataFilePath,
                _fileName);

            // Act
            var result = _jsonHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _numberOfTestContacts);

        }


        [Test]
        public void LoadFromFile_ValidVCFNFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.vcf,
                testDataFilePath,
                _fileName);

            // Act
            var result = _vcfHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _numberOfTestContacts);

        }

        [Test]
        public void LoadFromFile_ValidXMLFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.xml,
                testDataFilePath,
                _fileName);

            // Act
            var result = _xmlHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _numberOfTestContacts);

        }
    }
}
