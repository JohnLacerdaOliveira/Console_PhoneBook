namespace Console_PhoneBook.Model
{
    public interface IGenericContact
    {
        public abstract string Name { get; set; }
        public abstract string? PhoneNumber { get; set; }

        public static IEnumerable<string> GetAllPropertiesNames()
        {
            Type type = typeof(Contact);
            var properties = Array.ConvertAll(type.GetProperties(), p => p.Name);

            return properties;
        }
    }
}
