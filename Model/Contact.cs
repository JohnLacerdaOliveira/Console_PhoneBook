using System.Text;
using System.Text.Json.Serialization;

namespace Console_PhoneBook.Model
{
    public class Contact : IGenericContact
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }

        [JsonConstructor]
        public Contact()
        {

        }

        public Contact(Dictionary<string, string> contactValues)
        {

            foreach (var propertyInfo in GetType().GetProperties())
            {
                propertyInfo.SetValue(this, contactValues[propertyInfo.Name]);
            }
        }


        public override string ToString()
        {
            var description = new StringBuilder();

            foreach (var property in GetType().GetProperties())
            {
                description.Append($"{property.GetValue(this)} ");
            }

            return description.ToString().Trim();
        }
    }
}
