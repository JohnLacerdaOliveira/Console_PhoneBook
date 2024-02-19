using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Console_PhoneBook.Model
{
    public class Contact : IGenericContact
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public Contact(Dictionary<string, string> contactValues) 
        {
            //TODO - Validate if Name has value?
            foreach(var propertyInfo in this.GetType().GetProperties())
            {
                propertyInfo.SetValue(this, contactValues[propertyInfo.Name]);
            }
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
