using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;
using Console_PhoneBook.DataStorage.FileAccess;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    static class RepositoryFactory
    {
        public static IGenericRepository GetRepository(FileFormat fileFormat)
        {
            if (fileFormat == FileFormat.csv) return new CSVHandler();
            if (fileFormat == FileFormat.vcf) return new VCFHandler();
            if (fileFormat == FileFormat.json) return new JSONHandler();

            throw new ArgumentException("Apropriate repository for given File Format could not be found");
        }
    }
}
