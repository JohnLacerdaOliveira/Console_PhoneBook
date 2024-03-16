using Console_PhoneBook.DataStorage.FileAccess;
using Console_PhoneBook.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ConsolePhoneBook_Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Console_PhoneBook.DataStorage.DataAccess
{
    public interface IGenericRepository
    {
        public abstract IEnumerable<IGenericContact> LoadFromFile(FileMetadata fileMetaData);
        public abstract void SaveToFile(IEnumerable<IGenericContact> register, FileMetadata fileMetaData);
    }
}
