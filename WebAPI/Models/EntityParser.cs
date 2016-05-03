using Database;

namespace WebAPI.Models
{
    public class EntityParser
    {
        public Employee Create(EmployeeModel model, TestContext context)
        {
            return new Employee()
            {
                EmpId = model.EmpId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Activity = model.Activity,
                Department = context.Departments.Find(model.Department)
            };
        }
    }
}