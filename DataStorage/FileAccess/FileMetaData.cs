using Console_PhoneBook.DataStorage.DataAccess;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    public class FileMetaData
    {
        public string FileName { get; init; }
        public FileFormat FileFormat { get; init; }

        public FileMetaData(string fileName, FileFormat saveFormat)
        {
            FileName = fileName;
            FileFormat = saveFormat;
        }

        public string FilePath => $"{FileName}.{FileFormat}";

        public IRepository GetRepository() 
        {
            if (this.FileFormat == FileFormat.csv) return new CSVRepository(this);
            if (this.FileFormat == FileFormat.vcf) return new VCFRepository(this);

            throw new ArgumentException("Apropriate repository for given File Format could not be instantiated");
        }

    }
}
