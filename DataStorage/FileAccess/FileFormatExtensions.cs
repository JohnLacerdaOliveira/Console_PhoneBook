namespace Console_PhoneBook.DataStorage.FileAccess
{
    public static class FileFormatExtensions
    {

        public static IEnumerable<string> GetAllValuesAsStrings(this FileFormat fileFormat) 
        {
            return Enum.GetValues(typeof(FileFormat)).Cast<FileFormat>().Select(e => e.ToString());
        }

    }
}
