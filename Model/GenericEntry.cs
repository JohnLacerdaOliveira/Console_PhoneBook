namespace Console_PhoneBook.Model
{
    public class GenericEntry : IGenericEntry
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public GenericEntry(string name, int primaryPhoneNumber)
        {
            Name = name;
            PhoneNumber = primaryPhoneNumber;
        }

        public override string ToString()
        {
            return $"name: {this.Name} - Phone Number: {this.PhoneNumber}";
        }

    }
}
