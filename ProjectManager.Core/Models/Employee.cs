namespace ProjectManager.Core.Models
{
    public class Employee
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public string Email { get; }

        public Employee(Guid id, string firstName, string lastName, string middleName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Email = email;
        }
    }
}
