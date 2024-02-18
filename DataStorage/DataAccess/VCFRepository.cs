using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Text;

namespace Console_PhoneBook.DataStorage.DataAccess
{
    //TODO - implement VCF Parsing functionality
    public class VCFRepository : GenericRepository
    {
        public VCFRepository(FileMetaData fileMetaData) : base(fileMetaData)
        {
        }

        public override IEnumerable<IGenericContact> Parse(string fileData)
        {
            var delimiter = "END:VCARD";
            string[] vCards = fileData.Split(delimiter);

            List<IGenericContact> register = new List<IGenericContact>();

            foreach (string vCard in vCards)
            {
                string[] vCardComponents = vCard.Split(Environment.NewLine);

                string name = default;
                string phoneNumber = default;

                //TODO Implement a dictionary of vCard tags and iterate over it
                foreach (string component in vCardComponents)
                {
                    var tag = component.Split(":")[0];

                    if (tag == "FN") name = component.Split(":")[1];

                    if (tag == "TEL") phoneNumber = component.Split(":")[1];
                }

                if(name != default && phoneNumber != default)
                {
                    register.Add(new Contact(name, phoneNumber));
                }
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericContact> register)
        {

            StringBuilder vCards = new StringBuilder();

            //TODO Implement a dictionary of vCard tags and iterate over it
            //Serialize Body
            foreach (var contact in register)
            {
                if (contact is null) continue;

                vCards.AppendLine("BEGIN:VCARD");
                vCards.AppendLine("VERSION:3.0");
                vCards.AppendLine($"FN:{contact.Name}");
                vCards.AppendLine($"TEL:{contact.PhoneNumber}");
                vCards.AppendLine("END:VCARD");

            }

            return vCards.ToString();

        }
    }

}