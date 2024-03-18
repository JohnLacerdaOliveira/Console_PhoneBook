using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;
using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using Moq;
using NUnit.Framework;

namespace ConsolePhoneBook_Tests
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        private Mock<GenericRepository> _genericRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _genericRepositoryMock = new Mock<GenericRepository>();
        }

        [Test]
        public void LoadFromFile_ReturnsEmptyCollection_WhenFileDirectoryDoesNotExist()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                It.IsAny<FileExtensions>(),
                It.IsAny<string>());

            // Act
            var result = _genericRepositoryMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.AreEqual(result, Enumerable.Empty<IGenericContact>());
        }

        [Test]
        public void LoadFromFile_ReturnsEmptyCollection_WhenFilePathDoesNotExist()
        {
            // Arrange
            var fileMetaData = new FileMetadata(
                It.IsAny<FileExtensions>(),
                It.IsAny<string>(),
                It.IsAny<string>());

            // Act
            var result = _genericRepositoryMock.Object.LoadFromFile(fileMetaData);

            // Assert
            Assert.AreEqual(result, Enumerable.Empty<IGenericContact>());
        }
    }
}
