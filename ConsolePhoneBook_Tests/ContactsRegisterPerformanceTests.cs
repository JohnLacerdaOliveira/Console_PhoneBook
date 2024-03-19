using Console_PhoneBook.Model;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ConsolePhoneBook_Tests
{
    internal class ContactsRegisterPerformanceTests
    {
        private Contact _contactMock = CommonTestData.ContactMock;

        [Test]
        public void TestCollectionPerformance()
        {
            // Change these values according to your requirements
            const int numberOfContacts = 1000;
            const int numberOfIterations = 100;

            var collections = new Dictionary<string, Func<IRegister>>
            {
                {"List", () => new ContactsRegister<List<IGenericContact>>()},
                {"HashSet", () => new ContactsRegister<HashSet<IGenericContact>>()},
                {"LinkedList" , () => new ContactsRegister<LinkedList<IGenericContact>>()},
                {"ObservableCollection" , () => new ContactsRegister<ObservableCollection<IGenericContact>>()},
                {"SortedSet", () => new ContactsRegister<SortedSet<IGenericContact>>()}
            };

            foreach (var collectionType in collections)
            {
                var register = collectionType.Value.Invoke();

                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < numberOfIterations; i++)
                {
                    // Perform operations
                    AddContacts(register, numberOfContacts);
                    EditContacts(register, numberOfContacts);
                    DeleteContacts(register, numberOfContacts);
                    ClearContacts(register);
                }

                stopwatch.Stop();
                Console.WriteLine($"{collectionType.Key} performance: {stopwatch.ElapsedMilliseconds} ms");
            }
        }

        private void AddContacts(IRegister register, int numberOfContacts)
        {
            for (int i = 0; i < numberOfContacts; i++)
            {
                register.Add(_contactMock);
            }
        }

        private void EditContacts(IRegister register, int numberOfContacts)
        {
            for (int i = 0; i < numberOfContacts; i++)
            {
                register.Edit(register.Register.GetEnumerator().Current);
            }
        }

        private void DeleteContacts(IRegister register, int numberOfContacts)
        {
            for (int i = 0; i < numberOfContacts; i++)
            {
                register.Delete(register.Register.GetEnumerator().Current);
            }
        }

        private void ClearContacts(IRegister register)
        {
            register.Clear();
        }
    }
}

