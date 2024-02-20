using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;
using System.Text.Json;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class JSONHandler : GenericRepository
    {
        public JSONHandler(FileMetaData fileMetaData) : base(fileMetaData)
        {
        }

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var register = new List<IGenericContact>();

            if (string.IsNullOrEmpty(fileData)) return register;

            var contacts = JsonSerializer.Deserialize<List<Contact>>(fileData);

            foreach (var contact in contacts)
            {
                register.Add(contact);
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            var jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine(JsonSerializer.Serialize(register, new JsonSerializerOptions { WriteIndented = true }));

            return jsonBuilder.ToString();
        }
    }
}
