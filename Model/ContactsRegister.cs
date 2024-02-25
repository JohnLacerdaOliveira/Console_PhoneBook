namespace Console_PhoneBook.Model
{
    internal class ContactsRegister<TCollection> : IContactsRegister where TCollection : ICollection<IGenericContact>
    {
        public TCollection Register { get; init; }

        public ContactsRegister(TCollection register)
        {
            Register = register;
        }

        public void Add(IGenericContact contact)
        {
            if (Register is TCollection collection)
                collection.Add(contact);
        }

        public void Delete(IGenericContact contact)
        {
            if (Register is List<IGenericContact> list)
                list.Remove(contact);
        }
    }
}
