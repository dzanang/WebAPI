using System;
using System.Linq;
using Database;

namespace WebAPI.Models
{
    public class ModelFactory
    {
        public EmployeeModel Create(Employee empl)
        {
            return new EmployeeModel()
            {
                EmpId = empl.EmpId,
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                Age = empl.Age,
                Activity = empl.Activity,
                Department = empl.Department.DepId,
                DepartmentName = empl.Department.Name
            };
        }

        public DepartmentModel Create(Department dep)
        {
            return new DepartmentModel()
            {
                DepId = dep.DepId,
                Name = dep.Name
            };
        }
    }
}