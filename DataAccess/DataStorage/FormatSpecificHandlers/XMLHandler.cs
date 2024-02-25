using Console_PhoneBook.Model;
using System.Xml.Serialization;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class XMLHandler : GenericRepository
    {
        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var register = new List<IGenericContact>();
            if (string.IsNullOrEmpty(fileData)) return register;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (StringReader reader = new StringReader(fileData))
            {
                return (List<IGenericContact>)serializer.Deserialize(reader);
            }
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, register);
                return writer.ToString();
            }
        }
    }
}
