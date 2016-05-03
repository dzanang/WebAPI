using System.Collections.Generic;

namespace WebAPI.Models
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {
            Employees = new List<EmployeeModel>();
        }

        public int DepId { get; set; }
        public string Name { get; set; }
        public IList<EmployeeModel> Employees { get; set; }
    }
}