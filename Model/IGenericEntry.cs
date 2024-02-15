using System.Reflection;

namespace Console_PhoneBook.Model
{
    public interface IGenericEntry
    {
        public abstract string Name { get; set; }

        public abstract int PhoneNumber { get; set; }

        public abstract IEnumerable<string> GetAllPropertiesNames();
    
    }
}
