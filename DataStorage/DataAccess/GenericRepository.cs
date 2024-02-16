using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public abstract class GenericRepository : IRepository
    {
        protected readonly FileMetaData _fileMetaData;

        public GenericRepository(FileMetaData fileMetaData)
        {
            _fileMetaData = fileMetaData;
        }

        public abstract IEnumerable<IGenericEntry> Parse(string fileData);
        public abstract void Serialize(string entriesAsText);

        public IEnumerable<IGenericEntry> Load()
        {
            string? fileData = default;

            if (!File.Exists(_fileMetaData.FilePath)) File.Create(_fileMetaData.FilePath);


            try
            {
                fileData = File.ReadAllText(_fileMetaData.FilePath);
            }
            catch (Exception)
            {
                throw new IOException($"An error occcured while reading from the file: {_fileMetaData.FilePath}");
            }


            if (fileData.Length == 0) return new List<Entry>();

            return Parse(fileData);

        }

        public void Save(IEnumerable<IGenericEntry> register)
        {
            var entriesAsText = new StringBuilder();

            foreach (var entry in register)
            {
                entriesAsText.Append(entry);
                entriesAsText.Append(Environment.NewLine);
            }

            Serialize(entriesAsText.ToString());
        }

        public bool IsFilePathValid()
        {
            var filePath = _fileMetaData.FilePath;

            if (filePath is null) return false;
            if (filePath.Length == 0) return false;

            foreach (var extension in Enum.GetValues(typeof(FileFormat)))
            {
                string extensionAsString = extension.ToString().ToLower();
                if (!filePath.EndsWith(extensionAsString))
                {
                    return false;
                }
            }
            return true;
        }



    }

}