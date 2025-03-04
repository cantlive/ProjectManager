namespace ProjectManager.Core.Models
{
    public class Project
    {
        public Guid Id { get; }
        public string Name { get; }
        public string ClientCompany { get; }
        public string ContractorCompany { get; }
        public Employee Manager { get; }       
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int Priority { get; }
        public List<Employee> Employees { get; } = new List<Employee>();

        public Project(Guid id, string name, string clientCompany, string contractorCompany, Employee manager, DateTime startDate, DateTime endDate, int priority, Employee employee)
        {
            Id = id;
            Name = name;
            ClientCompany = clientCompany;
            ContractorCompany = contractorCompany;
            Manager = manager;            
            StartDate = startDate;
            EndDate = endDate;
            Priority = priority;
            Employees.Add(employee);
        }
    }
}
