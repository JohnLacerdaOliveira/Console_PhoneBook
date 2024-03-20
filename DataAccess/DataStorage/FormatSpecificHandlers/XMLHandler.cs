using Console_PhoneBook.Model;
using System.Xml.Serialization;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class XMLHandler : GenericRepository
    {
        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            if (string.IsNullOrEmpty(fileData))
            {
                return Enumerable.Empty<IGenericContact>();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                using (StringReader reader = new StringReader(fileData))
                {
                    return (List<Contact>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while parsing XML data.", ex);
            }
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            if (register == null)
            {
                throw new ArgumentNullException(nameof(register));
            }

            try
            {
                var contacts = register.OfType<Contact>().ToList();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, contacts);
                    return writer.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while serializing contacts to XML.", ex);
            }
        }
    }
}
