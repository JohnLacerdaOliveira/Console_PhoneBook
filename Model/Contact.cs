using System.Text;
using System.Text.Json.Serialization;

namespace Console_PhoneBook.Model
{
    public class Contact : IGenericContact
    {
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Organization { get; set; }
        public string? Title { get; set; }
        public string? Role { get; set; }
        public string? Note { get; set; }


        [JsonConstructor]
        public Contact() { }

        public Contact(Dictionary<string, string> importedValues)
        {
            foreach (var property in GetType().GetProperties())
            {
                Type currentType = property.PropertyType;

                if (importedValues.TryGetValue(property.Name, out string? value))
                {
                    property.SetValue(this, value);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (IGenericContact)obj;
            return Name == other.Name && PhoneNumber == other.PhoneNumber;
        }


        public override string ToString()
        {
            var description = new StringBuilder();

            foreach (var propertyInfo in GetType().GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(this);

                if (propertyValue != null) description.AppendLine($"{propertyValue} ");

            }

            return description.ToString();
        }
    }
}
