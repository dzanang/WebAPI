using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [NotMapped]                             //will not be shown in the Database, but can be called regardless
        public string FullName { get { return FirstName + " " + LastName; } }
        public bool Activity { get; set; }

        public virtual Department Department { get; set; }
    }
}