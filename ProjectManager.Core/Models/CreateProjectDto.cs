﻿using ProjectManager.DataAccess.Models;

namespace ProjectManager.Core.Models
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string CustomerCompany { get; set; }
        public string ContractorCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public Employee ProjectManager { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
