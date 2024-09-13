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
        private readonly IEnumerable<IGenericContact> _testContacts = CommonTestData.TestContacts;
        private readonly string _fileName = CommonTestData.FileName;
        private string _testDataFilePath = CommonTestData.TestDataFilePath;

        private Mock<CSVHandler>? _csvHandlerMock;
        private Mock<JSONHandler>? _jsonHandlerMock;
        private Mock<VCFHandler>? _vcfHandlerMock;
        private Mock<XMLHandler>? _xmlHandlerMock;

        [OneTimeSetUp]
        public void Setup()
        {
            _csvHandlerMock = new Mock<CSVHandler>() { CallBase = true };
            _jsonHandlerMock = new Mock<JSONHandler>() { CallBase = true };
            _vcfHandlerMock = new Mock<VCFHandler>() { CallBase = true };
            _xmlHandlerMock = new Mock<XMLHandler>() { CallBase = true };
        }

        [Test]
        public void CSVParse_ReturnsEqualCollectionToTestContacts_WhenImportingFromCSVTestFile()
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
            CollectionAssert.AreEqual(result, _testContacts);
        }

        [Test]
        public void CSVSerialize_ReturnsEqualTextToCSVTestFile_WhenSerializingTestContacts()
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
        public void JSONParse_ReturnsEqualCollectionToTestContacts_WhenImportingFromJSONTestFile()
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
            CollectionAssert.AreEqual(result, _testContacts);

        }

        [Test]
        public void JSONSerialize_ReturnsEqualTextToJSONTestFile_WhenSerializingTestContacts()
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
        public void VCFParse_ReturnsEqualCollectionToTestContacts_WhenImportingFromVCFTestFile()
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
            CollectionAssert.AreEqual(result, _testContacts);

        }

        [Test]
        public void VCFSerialize_ReturnsEqualTextToVCFTestFile_WhenSerializingTestContacts()
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
        public void XMLParse_ReturnsEqualCollectionToTestContacts_WhenImportingFromXMLTestFile()
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
            CollectionAssert.AreEqual(result, _testContacts);

        }

        [Test]
        public void XMLSerialize_ReturnsEqualTextToXMLTestFile_WhenSerializingTestContacts()
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
