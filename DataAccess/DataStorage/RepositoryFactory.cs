using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;
using Console_PhoneBook.DataStorage.FileAccess;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    static class RepositoryFactory
    {
        public static IGenericRepository GetRepository(FileExtensions fileExtension)
        {
            if (fileExtension == FileExtensions.csv) return new CSVHandler();
            if (fileExtension == FileExtensions.vcf) return new VCFHandler();
            if (fileExtension == FileExtensions.json) return new JSONHandler();
            if (fileExtension == FileExtensions.xml) return new XMLHandler();

            throw new ArgumentException("Apropriate repository for given File Format could not be found");
        }
    }
}
