using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Console_PhoneBook.Model
{
    public class Entry : IGenericEntry
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public Entry(string name, int phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public IEnumerable<string> GetAllPropertiesNames()
        {
            Type type = this.GetType();

            var properties = Array.ConvertAll(type.GetProperties(), p => p.Name);

            return properties;

        }

        public override string ToString()
        {
            var description = new StringBuilder();
            var thisProperties = this.GetType().GetProperties();

            foreach (PropertyInfo property in thisProperties)
            {
                description.Append($"{property.Name}: {property.GetValue(this)}\n");
            }

            return description.ToString();  
        }
    }
}
