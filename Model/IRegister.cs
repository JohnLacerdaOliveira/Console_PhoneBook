namespace Console_PhoneBook.Model
{
    public interface IRegister
    {
        public abstract void Add(IGenericContact contact);
        public abstract void Update(IGenericContact contact);
        public abstract void Delete(IGenericContact contact);
    }
}
