using Console_PhoneBook.App;

namespace Console_PhoneBook.Model
{
    public interface IContactsRegister
    {
        public abstract IEnumerable<IGenericContact> Register { get; set; }

    }
}
