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

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            List<IGenericContact> register = new List<IGenericContact>();
            string[] entries = fileData.Split(Environment.NewLine);

            foreach (var contact in entries)
            {
                if (contact.Length == 0) continue;

                string[] contactData = contact.Split(',');

                var name = contactData[0];
                var phoneNumber = contactData[1];

                register.Add(new Contact(name, phoneNumber));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {

            var contactsAsCSV = new StringBuilder();
            var entriesAsText = new StringBuilder();

            foreach (var contact in register)
            {
                entriesAsText.Append(contact.Name + ",");
                entriesAsText.Append(contact.PhoneNumber);
                entriesAsText.Append(Environment.NewLine);
            }

            var csvHeader = new StringBuilder();
            string[] contactAsText = entriesAsText.ToString().Split(Environment.NewLine);

            //Serialize Header
            foreach (var propertyName in IGenericContact.GetAllPropertiesNames())
            {
                csvHeader.Append(propertyName + ",");
            }

            var trimmedCsvHeader = csvHeader.ToString().Substring(0, csvHeader.Length - 1);
            contactsAsCSV.AppendLine(trimmedCsvHeader);

            //Serialize Body
            foreach (var contact in contactAsText)
            {
                if (contact.Length == 0) continue;

                contactsAsCSV.AppendLine(contact);
            }

            return contactsAsCSV.ToString();
        }
    }

}