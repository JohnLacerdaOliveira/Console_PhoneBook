namespace Console_PhoneBook.Model
{
    public interface IRegister
    {
        public IEnumerable<IGenericContact> Register { get; init; }
        public abstract void Add(IGenericContact contact);
        public abstract void Edit(IGenericContact contact);
        public abstract void Delete(IGenericContact contact);
        public abstract void Clear();
    }
}
