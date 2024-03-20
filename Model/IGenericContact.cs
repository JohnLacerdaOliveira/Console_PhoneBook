using System.ComponentModel.DataAnnotations;

namespace Console_PhoneBook.Model
{
    public interface IGenericContact
    {
        public abstract string Name { get; set; }
        public abstract string? Nickname { get; set; }
        public abstract string? PhoneNumber { get; set; }
        public abstract string? Email { get; set; }
        public abstract string? BirthDay { get; set; }
        public abstract string? Address { get; set; }
        public abstract string? Organization { get; set; }
        public abstract string? Title { get; set; }
        public abstract string? Role { get; set; }
        public abstract string? Note { get; set; }

    }
}
