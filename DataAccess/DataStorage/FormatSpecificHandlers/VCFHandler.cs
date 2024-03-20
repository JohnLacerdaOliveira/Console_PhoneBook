using Console_PhoneBook.Model;
using System.Reflection;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess.FormatSpecificHandlers
{
    internal class VCFHandler : GenericRepository
    {
        private readonly string _contactDelimiter = "END:VCARD";
        private readonly string _tagDelimiter = ":";

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var register = new List<IGenericContact>();

            string[] vCards = fileData.Split(new[] { _contactDelimiter }, StringSplitOptions.RemoveEmptyEntries);

            if (string.IsNullOrEmpty(vCards.ToString())) return register;

            foreach (string vCard in vCards)
            {
                if (vCard.Length <= 3) continue;

                string[] vCardComponents = vCard.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                var contactProperties = new Dictionary<string, string>();

                foreach (string component in vCardComponents)
                {
                    var tag = component.Split(_tagDelimiter)[0].ToUpper();

                    if (VCardProperties.Map.Keys.Contains(tag))
                    {
                        contactProperties.Add(VCardProperties.Map[tag], component.Split(_tagDelimiter, 2)[1]);
                    }
                }
                register.Add(new Contact(contactProperties));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {
            StringBuilder vCards = new StringBuilder();

            foreach (var contact in register)
            {
                if (contact == null) continue;

                vCards.AppendLine("BEGIN:VCARD");
                vCards.AppendLine("VERSION:3.0");

                foreach (var propertyName in VCardProperties.Map.Values)
                {
                    if (typeof(IGenericContact).GetProperty(propertyName) is PropertyInfo property)
                    {
                        string key = VCardProperties.Map.FirstOrDefault(x => x.Value == propertyName).Key;
                        string? value = property.GetValue(contact)?.ToString();

                        if (!string.IsNullOrEmpty(value))
                        {
                            vCards.AppendLine($"{key}{_tagDelimiter}{value}");
                        }
                    }
                }

                vCards.AppendLine("END:VCARD");
                vCards.AppendLine();
            }

            return vCards.ToString();
        }
    }
}