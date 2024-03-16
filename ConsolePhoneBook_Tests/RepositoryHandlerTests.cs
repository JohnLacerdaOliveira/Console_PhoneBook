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
        private readonly IEnumerable<IGenericContact> _testContacts = new List<IGenericContact>
        {
            new Contact { Name = "John Doe", PhoneNumber = "911234567" },
            new Contact { Name = "Jane Smith", PhoneNumber = "922345678" },
            new Contact { Name = "Michael Johnson", PhoneNumber = "933456789" }
        };

        private readonly string _testFilesFolderName = "TestData";
        private readonly string _fileName = "Test";
        private readonly string _testFilesDirectory = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName;

        private string _testDataFilePath;

        private Mock<CSVHandler> _csvHandlerMock;
        private Mock<JSONHandler> _jsonHandlerMock;
        private Mock<VCFHandler> _vcfHandlerMock;
        private Mock<XMLHandler> _xmlHandlerMock;

        [SetUp]
        public void Setup()
        {
            _testDataFilePath = Path.Combine(_testFilesDirectory, _testFilesFolderName);

            _csvHandlerMock = new Mock<CSVHandler>() { CallBase = true };
            _jsonHandlerMock = new Mock<JSONHandler>() { CallBase = true };
            _vcfHandlerMock = new Mock<VCFHandler>() { CallBase = true };
            _xmlHandlerMock = new Mock<XMLHandler>() { CallBase = true };
        }

        [Test]
        public void CSVParse_TestFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.csv,
                _testDataFilePath,
                _fileName);

            // Act
            var result = _csvHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _testContacts.Count());
        }

        [Test]
        public void CSVSerialize_TestContact_IsEqualToCSVTestFileContents()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.csv,
                _testDataFilePath,
                _fileName);

            var fileContent = File.ReadAllText(fileMetaData.FilePath);

            // Act
            var result = _csvHandlerMock.Object.Serialize(_testContacts);

            //Assert
            Assert.AreEqual(fileContent.Trim(), result.Trim());
        }

        [Test]
        public void JSONParse_TestFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.json,
                _testDataFilePath,
                _fileName);

            // Act
            var result = _jsonHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _testContacts.Count());

        }

        [Test]
        public void JSONSerialize_TestContact_IsEqualToJSONTestFileContents()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.json,
                _testDataFilePath,
                _fileName);

            var fileContent = File.ReadAllText(fileMetaData.FilePath);

            // Act
            var result = _jsonHandlerMock.Object.Serialize(_testContacts);

            //Assert
            Assert.AreEqual(fileContent.Trim(), result.Trim());
        }


        [Test]
        public void VCFParse_TestFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.vcf,
                _testDataFilePath,
                _fileName);

            // Act
            var result = _vcfHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _testContacts.Count());

        }

        [Test]
        public void VCFSerialize_TestContact_IsEqualToVCFTestFileContents()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.vcf,
                _testDataFilePath,
                _fileName);

            var fileContent = File.ReadAllText(fileMetaData.FilePath);

            // Act
            var result = _vcfHandlerMock.Object.Serialize(_testContacts);

            //Assert
            Assert.AreEqual(fileContent.Trim(), result.Trim());
        }

        [Test]
        public void XMLParse_TestFile_ReturnsParsedContacts()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.xml,
                _testDataFilePath,
                _fileName);

            // Act
            var result = _xmlHandlerMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.IsInstanceOf<IEnumerable<IGenericContact>>(result);
            Assert.IsTrue(result.Count() == _testContacts.Count());

        }

        [Test]
        public void XMLSerialize_TestContact_IsEqualToXMLTestFileContents()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                FileExtensions.xml,
                _testDataFilePath,
                _fileName);

            var fileContent = File.ReadAllText(fileMetaData.FilePath);

            // Act
            var result = _xmlHandlerMock.Object.Serialize(_testContacts);

            //Assert
            Assert.AreEqual(fileContent.Trim(), result.Trim());
        }
    }
}
