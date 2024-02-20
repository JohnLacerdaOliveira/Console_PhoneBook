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

            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("File data is null or empty.");
                return Enumerable.Empty<IGenericContact>();
            }

            try
            {
                // Deserialize JSON data to a list of Contact objects
                var contacts = JsonSerializer.Deserialize<List<Contact>>(fileData);

                // Convert each Contact object to IGenericContact and return as IEnumerable
                return contacts.Cast<IGenericContact>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return Enumerable.Empty<IGenericContact>();
            }
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            var jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine(JsonSerializer.Serialize(register, new JsonSerializerOptions { WriteIndented = true }));

            return jsonBuilder.ToString();
        }
    }
}
