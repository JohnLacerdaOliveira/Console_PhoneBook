using Console_PhoneBook.DataStorage.DataAccess;
using Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers;

namespace Console_PhoneBook.DataStorage.FileAccess
{
    public class FileMetaData
    {
        private readonly FileFormat _fileFormat;
        private readonly string _fileDirectory;
        private const string _fileName = "PhoneBookRepository";
        public string FilePath => $"{_fileDirectory}{_fileName}.{_fileFormat}";

        public FileMetaData(FileFormat fileFormat, string fileDirectory = "")
        {
            _fileFormat = fileFormat;
            _fileDirectory = fileDirectory;
        }

        public IGenericRepository GetRepository()
        {
            if (this._fileFormat == FileFormat.csv) return new CSVHandler(this);
            if (this._fileFormat == FileFormat.vcf) return new VCFHandler(this);
            if (this._fileFormat == FileFormat.json) return new JSONHandler(this);


            throw new ArgumentException("Apropriate repository for given File Format could not be found");
        }
    }
}
