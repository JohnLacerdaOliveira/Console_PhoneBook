namespace Console_PhoneBook.Model
{
    public interface IContactsRegister
    {
        public abstract void Add(IGenericContact contact);
        public abstract void Delete(IGenericContact contact);

    }
}
