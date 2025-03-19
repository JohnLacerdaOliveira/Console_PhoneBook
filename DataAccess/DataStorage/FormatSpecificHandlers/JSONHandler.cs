using Console_PhoneBook.DataAccess.DataStorage;
using Console_PhoneBook.Model;
using System.Text.Json;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class JSONHandler : GenericRepository
    {
        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var register = new List<IGenericContact>();

            if (string.IsNullOrEmpty(fileData)) return register;

            var contacts = JsonSerializer.Deserialize<List<Contact>>(fileData);

            if (contacts is null || contacts.Count == 0) return register;

            return contacts;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            return JsonSerializer.Serialize(register, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
