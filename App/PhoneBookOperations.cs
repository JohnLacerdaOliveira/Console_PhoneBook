using Console_PhoneBook.Model;

namespace Console_PhoneBook.App
{
    public class PhoneBookOperations : IPhoneBookOperations
    {
        public void AddContact(List<IGenericEntry> repository)
        {

            Console.WriteLine("Insert Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Insert Number");
            int.TryParse(Console.ReadLine(), out int number);

            var entry = new GenericEntry(name, number);

            if (name is not null) repository.Add(entry);
        }

        public void ViewAllContacts(List<IGenericEntry> repository)
        {
            

            foreach (var entry in repository)
            {
                Console.WriteLine(entry);
            }
        }
        public IGenericEntry SearchContact(List<IGenericEntry> repository)
        {
            

            Console.WriteLine("Name to search: ");
            string searchName = Console.ReadLine();

            foreach (var entry in repository)
            {
                if (searchName == entry.Name)
                {
                    Console.WriteLine(entry);
                    return entry;
                }
            }

            Console.WriteLine("No entry found with that name...");
            return null;
        }
        public void EditContact(List<IGenericEntry> repository)
        {
            var contactToEdit = SearchContact(repository);

            if (contactToEdit is not null)
            {
                Console.WriteLine("1. Change Name");
                Console.WriteLine("2. Change Number");

                var userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    Console.WriteLine("Insert new name:");
                    string newName = Console.ReadLine();

                    Console.WriteLine($"{contactToEdit.Name} updated to {newName}");
                    contactToEdit.Name = newName;
                    return;
                }

                if (userChoice == "2")
                {
                    Console.WriteLine("Insert new number:");
                    int.TryParse(Console.ReadLine(), out int newNumber);

                    Console.WriteLine($"{contactToEdit.Name} number {contactToEdit.PhoneNumber} updated to {newNumber}");

                    contactToEdit.PhoneNumber = newNumber;
                    return;
                }

            }
            Console.WriteLine("No entry found with that name...");

        }

        public void DeleteContact(List<IGenericEntry> repository)
        {
            

            var contactToDelete = SearchContact(repository);
            if (contactToDelete is not null)
            {
                repository.Remove(contactToDelete);
                Console.WriteLine($"{contactToDelete.Name} was removed");
                return;
            }

            Console.WriteLine("Contact was not found");
        }

    }
}