namespace WebAPI.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Activity { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
    }
}