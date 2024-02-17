using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public abstract class GenericRepository : IGenericRepository
    {
        protected readonly FileMetaData _fileMetaData;

        public GenericRepository(FileMetaData fileMetaData)
        {
            _fileMetaData = fileMetaData;
        }

        public abstract IEnumerable<IGenericEntry> Parse(string fileData);
        public abstract string Serialize(string entriesAsText);

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
                entriesAsText.Append(entry.Name + ",");
                entriesAsText.Append(entry.PhoneNumber);
                entriesAsText.Append(Environment.NewLine);
            }

            File.WriteAllText(_fileMetaData.FilePath,Serialize(entriesAsText.ToString()));
        }
    }
}