using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Reflection;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    public class VCFHandler : GenericRepository 
    {

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var register = new List<IGenericContact>();
            

            var delimiter = "END:VCARD";
            string[] vCards = fileData.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            if (vCards is null || vCards.Length == 0) return register;

            foreach (string vCard in vCards)
            {
                if (vCard.Length <= 3) continue;

                string[] vCardComponents = vCard.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var contactProperties = new Dictionary<string, string>();
                //TODO Implement a dictionary of vCard tags and iterate over it
                foreach (string component in vCardComponents)
                {

                    //TODO - filter for uppercase letters to indicate a tag
                    var tag = component.Split(":")[0];

                    foreach (var key in VCardProperties.Map.Keys)
                    {
                        if (tag.Equals(key))
                        {
                            contactProperties.Add(VCardProperties.Map[key], component.Split(":")[1]);
                            break;
                        }
                    }
                }

               
                register.Add(new Contact(contactProperties));
            }

            return register;
        }

        //TODO - Aplly the same dynamic approach as in the CSV REpository
        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            StringBuilder vCards = new StringBuilder();

            foreach (var contact in register)
            {
                if (contact is null) continue;

                vCards.AppendLine("BEGIN:VCARD");
                vCards.AppendLine("VERSION:3.0");

                foreach (var value in VCardProperties.Map.Values)
                {
                    PropertyInfo? property = typeof(IGenericContact).GetProperty(value, BindingFlags.IgnoreCase);

                    if (property != null)
                    {
                        string key = VCardProperties.Map.FirstOrDefault(x => x.Value == value).Key;
                        vCards.AppendLine($"{key}:{property.GetValue(contact)}");
                    }
                }

                vCards.AppendLine("END:VCARD");
            }

            return vCards.ToString();
        }
    }

}