using System.Reflection;
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


        public override string ToString()
        {
            var thisProperties = this.GetType().GetProperties();
            var description = new StringBuilder();

            foreach (var property in thisProperties)
            {
                description.Append($"{property.GetValue(this)} ");
            }

            return description.ToString();
        }
    }
}
