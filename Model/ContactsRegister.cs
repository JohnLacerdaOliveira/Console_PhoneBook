namespace Console_PhoneBook.Model
{
    public class ContactsRegister<TCollection> : IRegister where TCollection : ICollection<IGenericContact>, new()
    {
        public IEnumerable<IGenericContact> Register { get; init; }

        public ContactsRegister()
        {
            Register = new TCollection();
        }

        public void Add(IGenericContact Contact)
        {
            if (Register is TCollection list)
                list.Add(Contact);
        }

        public void Delete(IGenericContact contact)
        {
            if (Register is TCollection list)
                list.Remove(contact);
        }

        public void Clear()
        {
            if (Register is ICollection<IGenericContact> collection)
            {
                collection.Clear();
            }
        }
    }
}
