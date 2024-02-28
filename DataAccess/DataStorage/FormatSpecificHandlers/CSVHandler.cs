using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    public class CSVHandler : GenericRepository
    {
        //TODO - Log rejected entries and properties
        //TODO - Log results
        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            //TODO - Implement Generic type on the collection type
            var register = new List<IGenericContact>();

            bool hasHeader = false;
            var headerValues = new Dictionary<string, string?>();

            string[] contacts = fileData.Split(Environment.NewLine);
            string[] header = contacts[0].Split(",");

            if (contacts is null || contacts.Length == 0) return register;

            var headerProperties = typeof(IGenericContact).GetProperties();
            //Parse header
            foreach (var headerValue in header)
            {
                foreach (var propertyName in headerProperties)
                {
                    if (headerValue.ToLower() == propertyName.Name.ToLower())
                    {
                        headerValues.Add(propertyName.Name, null);
                        hasHeader = true;
                        break;
                    }
                }
            }

            if (hasHeader)
            {
                contacts[0] = "";
            }
            else
            {
                //TODO - Log the errors
                return register;
            }

            //Parse Contact
            foreach (var contact in contacts)
            {
                if (contact.Length == 0) continue;

                var contactDataIndex = 0;
                string[] contactData = contact.Split(',');
                if (contactData.Length != header.Length) continue;

                var contactProperties = new Dictionary<string, string>();
                foreach (var property in headerValues.Keys)
                {
                    contactProperties.Add(property, contactData[contactDataIndex++]);
                }

                //TODO - Contact must have a name
                register.Add(new Contact(contactProperties));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            var csvBuilder = new StringBuilder();

            var propertyNames = typeof(IGenericContact).GetProperties().Select(n => n.ToString()).ToArray();

            if (propertyNames == null) return string.Empty; // No data to serialize

            csvBuilder.AppendLine(string.Join(",", propertyNames));

            foreach (var contact in register)
            {
                var contactValues = new List<string>();
                foreach (var property in propertyNames)
                {
                    var propertyInfo = contact.GetType().GetProperty(property);
                    if (propertyInfo != null)
                    {
                        var propertyValue = propertyInfo.GetValue(contact);
                        contactValues.Add(propertyValue != null ? propertyValue.ToString() : "");
                        break;
                    }

                    contactValues.Add(""); // Property not found, add empty value

                }
                csvBuilder.AppendLine(string.Join(",", contactValues));
            }

            return csvBuilder.ToString();
        }
    }

}