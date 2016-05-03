using Database;
using System;
using System.Linq;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(Repository<Department> depo) : base(depo)
        { }

        //this method returns all data from the Departments table in the database
        public IHttpActionResult Get()
        {
            try
            {
                var department = Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
                if (department == null) return NotFound();
                else
                    return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //this method returns data form the Departments table for a single entry by ID
        public IHttpActionResult Get(int id)
        {
            try
            {
                Department department = Repository.Get(id);
                if (department == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}



