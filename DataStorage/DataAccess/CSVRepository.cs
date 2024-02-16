using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public class CSVRepository : GenericRepository
    {
        public CSVRepository(FileMetaData fileMetaData) : base(fileMetaData)
        {
        }

        public override IEnumerable<IGenericEntry> Parse(string fileData)
        {
            List<IGenericEntry> register = new List<IGenericEntry>();
            string[] entries = fileData.Split(Environment.NewLine);

            foreach (var entry in entries)
            {
                if (entry.Length > 0)
                {
                    string[] entryData = entry.Split(',');

                    var name = entryData[0];
                    var phoneNumber = int.TryParse(entryData[1], out int number);

                    IGenericEntry genericEntry = new Entry(name, number);

                    register.Add(genericEntry);
                }

            }


            return register;
        }

        public override void Serialize(string entriesAsText)
        {
            var entriesAsCSV = new StringBuilder();

            string[] entryAsText = entriesAsText.Split(Environment.NewLine);

            foreach (var entry in entryAsText)
            {
                if (entry.Length > 0)
                {
                    string[] entryData = entry.Split(' ');

                    entriesAsCSV.Append(entryData[0] + ",");
                    entriesAsCSV.Append(entryData[1]);
                    entriesAsCSV.Append(Environment.NewLine);
                }

            }
            File.WriteAllText(_fileMetaData.FilePath, entriesAsCSV.ToString());
        }
    }

}