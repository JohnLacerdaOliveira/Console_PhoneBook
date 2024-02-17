using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;

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

            throw new NotImplementedException();
        }

        public override string Serialize(string fileData)
        {
            throw new NotImplementedException();
        }
    }

}