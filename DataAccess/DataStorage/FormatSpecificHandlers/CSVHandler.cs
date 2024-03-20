using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class CSVHandler : GenericRepository
    {
        private readonly string _delimiter = ";";
        private readonly string[] _contactProperties = typeof(IGenericContact).GetProperties().Select(n => n.Name).ToArray();

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            //TODO - Implement Generic type on the collection type
            var register = new List<IGenericContact>();

            if(string.IsNullOrEmpty(fileData)) return register;

            bool hasHeader = false;
            var headerValues = new Dictionary<string, string>();

            string[] contacts = fileData.Split(Environment.NewLine);
            string[] header = contacts[0].Split(_delimiter);

            foreach (var headerValue in header)
            {
                foreach (var propertyName in _contactProperties)
                {
                    if (headerValue.ToLower() == propertyName.ToLower())
                    {
                        headerValues.Add(propertyName, string.Empty);
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

            foreach (var contact in contacts)
            {
                if (contact.Length == 0) continue;

                var contactDataIndex = 0;
                string[] contactData = contact.Split(_delimiter);
                if (contactData.Length != header.Length) continue;

                var contactArguments = new Dictionary<string, string>();
                foreach (var property in headerValues.Keys)
                {
                    contactArguments.Add(property, contactData[contactDataIndex++]);
                }

                //TODO - Contact must have a name
                register.Add(new Contact(contactArguments));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            var csvBuilder = new StringBuilder();

            csvBuilder.AppendLine(string.Join(_delimiter, _contactProperties));

            foreach (var contact in register)
            {
                var contactValues = new List<string>();
                foreach (var property in _contactProperties)
                {
                    var propertyInfo = contact.GetType().GetProperty(property);
                    var propertyValue = propertyInfo.GetValue(contact);

                    if (propertyValue != null)
                    {
                        contactValues.Add(propertyValue.ToString());

                    }
                }
                csvBuilder.AppendLine(string.Join(_delimiter, contactValues));
            }

            return csvBuilder.ToString();
        }
    }

}