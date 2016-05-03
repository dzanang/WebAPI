using Database;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;

namespace DataSeed
{
    static class Delta
    {
        static string sourceData = @"C:\MistralProjects\test\TestData.xls";
        static TestContext context = new TestContext();

        static void Main(string[] args)
        {
            Seed();
            Console.ReadKey();
        }

        public static void Seed()
        {
            Console.Clear();

            getDep();
            getEmp();                        
            Console.ReadKey();
        }

        static void getDep()
        {
            Console.Write("Seeding Departments: ");
            DataTable rawData = OpenExcel(sourceData, "Department");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Department department = new Department();
                department.DepId = getInteger(row, 0);
                department.Name = getString(row, 1);

                N++;
                context.Departments.Add(department);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        static void getEmp()
        {
            Console.Write("Seeding Employees: ");
            DataTable rawData = OpenExcel(sourceData, "Employee");

            int N = 0;
            foreach (DataRow row in rawData.Rows)
            {
                Employee employee = new Employee();
                employee.FirstName = getString(row, 0);
                employee.LastName = getString(row, 1);
                employee.Age = getInteger(row, 2);
                employee.Activity = getBool(row, 3);
                string dpt = getString(row, 4);
                employee.Department = context.Departments.Where(x => x.Name == dpt).FirstOrDefault();

                N++;
                context.Employees.Add(employee);
            }
            context.SaveChanges();
            Console.WriteLine(N);
        }

        //returning corresponding values from the excel file
        static string getString(DataRow row, int index)
        {
            return row.ItemArray.GetValue(index).ToString();
        }

        static int getInteger(DataRow row, int index)
        {
            return Convert.ToInt32(row.ItemArray.GetValue(index).ToString());
        }

        static bool getBool(DataRow row, int index)
        {
            return (row.ItemArray.GetValue(index).ToString().ToLower() == "yes");
        }

        //creating connection with the excel sheet
        static DataTable OpenExcel(string path, string sheet)
        {
            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}