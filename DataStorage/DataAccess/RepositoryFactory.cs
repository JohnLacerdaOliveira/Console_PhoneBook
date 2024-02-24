using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;
using Console_PhoneBook.DataStorage.FileAccess;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    static class RepositoryFactory
    {
        public static IGenericRepository GetRepository(FileExtension fileFormat)
        {
            if (fileFormat == FileExtension.csv) return new CSVHandler();
            if (fileFormat == FileExtension.vcf) return new VCFHandler();
            if (fileFormat == FileExtension.json) return new JSONHandler();

            throw new ArgumentException("Apropriate repository for given File Format could not be found");
        }
    }
}
