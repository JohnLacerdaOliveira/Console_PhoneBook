using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    //TODO - review implementation
    public class FileMetaData 
    {
        public FileFormat FileFormat { get; init; }
        public string FileDirectory { get; init; }
        public string FileName { get; init; }  = "PhoneBookRepository";

        public string FilePath => $"{FileDirectory}{FileName}.{FileFormat}";

        public FileMetaData(Dictionary<string, string> fileMetaDataProperties)
        {
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                propertyInfo.SetValue(this, fileMetaDataProperties[propertyInfo.Name]);
            }
        }
    }
}
