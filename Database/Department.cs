using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        public string Name { get; set; }
    }
}
