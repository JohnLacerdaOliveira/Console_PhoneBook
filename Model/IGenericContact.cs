namespace Console_PhoneBook.Model
{
    public interface IGenericContact
    {
        public abstract string Name { get; set; }
        public abstract string? PhoneNumber { get; set; }
    }
}
