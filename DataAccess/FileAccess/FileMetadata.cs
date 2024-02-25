namespace Console_PhoneBook.DataStorage.FileAccess
{
    public class FileMetadata
    {
        public FileExtensions FileExtension { get; init; }
        public string FileDirectory { get; init; }
        public string FileName { get; init; }
        public string FilePath => $"{FileDirectory}\\{FileName}.{FileExtension}";

        public FileMetadata(FileExtensions fileFormat, string fileDirectory)
        {
            FileExtension = fileFormat;
            FileDirectory = fileDirectory;
            FileName = $"PhoneBook {DateTime.Now.Date.ToString("dd-MM-yyyy")}";
        }

        public FileMetadata(FileExtensions fileFormat, string fileDirectory, string fileName)
        {
            FileExtension = fileFormat;
            FileDirectory = fileDirectory;
            FileName = fileName;
        }
    }
}
