using System.Reflection;
using System.Text;

namespace Console_PhoneBook.Model
{
    public class Contact : IGenericContact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }


        public override string ToString()
        {
            var description = new StringBuilder();

            foreach (var propertyName in IGenericContact.GetAllPropertiesNames())
            {
                description.Append($"{this.GetType().GetProperty(propertyName).GetValue(this)} ");
            }

            return description.ToString();
        }
    }
}
