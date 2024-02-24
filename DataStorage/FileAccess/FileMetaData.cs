using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    //TODO - review implementation
    public class FileMetaData 
    {
        public FileExtension FileExtension { get; init; }
        public string FileDirectory { get; init; }
        public string FileName { get; init; }  = "PhoneBookRepository";

        public string FilePath => $"{FileDirectory}{FileName}.{FileExtension}";

        public FileMetaData(FileExtension fileFormat, string fileDirectory, string fileName = "PhoneBookRepository")
        {
            FileExtension = fileFormat;
            FileDirectory = fileDirectory;
            FileName = fileName;
        }

        public FileMetaData(Dictionary<string, string> fileMetaDataProperties)
        {
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                propertyInfo.SetValue(this, fileMetaDataProperties[propertyInfo.Name]);
            }
        }
    }
}
