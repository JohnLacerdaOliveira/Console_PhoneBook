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
                if(!int.TryParse(entryData[1], out int phoneNumber)) continue;

                register.Add(new Entry(name, phoneNumber));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericEntry> register)
        {

            var entriesAsCSV = new StringBuilder();
            var entriesAsText = new StringBuilder();

            foreach (var entry in register)
            {
                entriesAsText.Append(entry.Name + ",");
                entriesAsText.Append(entry.PhoneNumber);
                entriesAsText.Append(Environment.NewLine);
            }

            var csvHeader = new StringBuilder();
            string[] entryAsText = entriesAsText.ToString().Split(Environment.NewLine);

            //Serialize Header
            foreach(var propertyName in IGenericEntry.GetAllPropertiesNames())
            {
                csvHeader.Append(propertyName + ",");
            }

            var trimmedCsvHeader = csvHeader.ToString().Substring(0, csvHeader.Length - 1);
            entriesAsCSV.AppendLine(trimmedCsvHeader);

            //Serialize Body
            foreach (var entry in entryAsText)
            {
                if (entry.Length == 0) continue;

                entriesAsCSV.AppendLine(entry);
            }

            return entriesAsCSV.ToString();
        }
    }

}