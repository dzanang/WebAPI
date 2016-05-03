using System.Data.Entity;
using System.Reflection.Emit;

namespace Database
{
    public class TestContext : DbContext
    {

        public TestContext() : base() 

        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}