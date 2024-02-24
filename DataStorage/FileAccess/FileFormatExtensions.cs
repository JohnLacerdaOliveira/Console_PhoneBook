namespace Console_PhoneBook.DataStorage.FileAccess
{
    public static class FileFormatExtensions
    {
        public static IEnumerable<string> GetAllSupportedFileFormats(this FileExtension fileFormat) 
        {
            return Enum.GetValues(typeof(FileExtension)).Cast<FileExtension>().Select(e => e.ToString());
        }

    }
}
