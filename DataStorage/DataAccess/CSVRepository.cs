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
                if (entry.Length == 0) continue;

                string[] entryData = entry.Split(',');

                var name = entryData[0];
                if(!int.TryParse(entryData[1], out int number)) continue;

                register.Add(new Entry(name, number));
            }

            return register;
        }

        public override string Serialize(string entriesAsText)
        {
            var csvHeader = new StringBuilder();
            var entriesAsCSV = new StringBuilder();
            string[] entryAsText = entriesAsText.Split(Environment.NewLine);

            foreach(var propertyName in IGenericEntry.GetAllPropertiesNames())
            {
                csvHeader.Append(propertyName + ",");
            }

            var trimmedCsvHeader = csvHeader.ToString().Substring(0, csvHeader.Length - 1);
            entriesAsCSV.AppendLine(trimmedCsvHeader);

            foreach (var entry in entryAsText)
            {
                if (entry.Length == 0) continue;

                entriesAsCSV.AppendLine(entry);
            }

            return entriesAsCSV.ToString();
        }
    }

}