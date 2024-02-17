using Console_PhoneBook.DataStorage.DataAccess;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    public class FileMetaData
    {
        private readonly FileFormat _fileFormat;
        private readonly string _fileLocation;
        private const string _fileName = "PhoneBookRepository";
        public string FilePath => $"{_fileLocation}{_fileName}.{_fileFormat}";

        public FileMetaData(FileFormat fileFormat, string fileLocation = "")
        {
            _fileFormat = fileFormat;
            _fileLocation = fileLocation;
        }

        public IGenericRepository GetRepository() 
        {
            if (this._fileFormat == FileFormat.csv) return new CSVRepository(this);
            if (this._fileFormat == FileFormat.vcf) return new VCFRepository(this);

            throw new ArgumentException("Apropriate repository for given File Format could not be found");
        }

    }
}
