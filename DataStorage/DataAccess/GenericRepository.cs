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

        public void Save(IEnumerable<IGenericEntry> entriesRegister)
        {
            var entriesAsText = new StringBuilder();

            foreach (var entry in entriesRegister)
            {
                entriesAsText.Append(entry);
                entriesAsText.Append(Environment.NewLine);
            }

            Serialize(entriesAsText.ToString());
        }
    }
}