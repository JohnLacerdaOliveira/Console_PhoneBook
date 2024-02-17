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

        public override IEnumerable<IGenericEntry> Parse(string fileData)
        {
            var delimiter = "END:VCARD";
            string[] vCards = fileData.Split(delimiter);

            List<IGenericEntry> register = new List<IGenericEntry>();

            foreach (string vCard in vCards)
            {
                string[] vCardComponents = vCard.Split(Environment.NewLine);

                string name = default;
                int phoneNumber = 0;

                //TODO Implement a dictionary of vCard tags and iterate over it
                foreach (string component in vCardComponents)
                {
                    var tag = component.Split(":")[0];

                    if (tag == "FN") name = component.Split(":")[1];

                    if (tag == "TEL") int.TryParse(component.Split(":")[1], out phoneNumber);

                }

                if (phoneNumber == 0) continue;
                register.Add(new Entry(name, phoneNumber));
            }

            return register;
        }

        public override string Serialize(IEnumerable<IGenericEntry> register)
        {

            StringBuilder vCards = new StringBuilder();

            //TODO Implement a dictionary of vCard tags and iterate over it
            //Serialize Body
            foreach (var entry in register)
            {
                if (entry is null) continue;

                vCards.AppendLine("BEGIN:VCARD");
                vCards.AppendLine("VERSION:3.0");
                vCards.AppendLine($"FN:{entry.Name}");
                vCards.AppendLine($"TEL:{entry.PhoneNumber}");
                vCards.AppendLine("END:VCARD");

            }

            return vCards.ToString();

        }
    }

}