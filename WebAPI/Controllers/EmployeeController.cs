using Database;
using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(Repository<Employee> depo) : base(depo)
        { }

        //this method returns all employee data from the database
        public IHttpActionResult Get()
        {
            try
            {
                var employees = Repository.Get().ToList().Select(x => Factory.Create(x));
                if (employees == null) return NotFound();
                else
                    return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //this method returns data for one employee filtered through his ID
        public IHttpActionResult Get(int id)
        {
            try
            {
                Employee employee = Repository.Get(id);
                if (employee == null) return NotFound();
                else
                    return Ok(Factory.Create(Repository.Get(id)));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //getting data through a specific route, grouped by departments and further more separated by activity
        [Route("api/department/{DepId}/employee")]
        public IHttpActionResult Get(int DepId, bool active = true)
        {
            try
            {
                var employees = Repository.Get().Where(x => x.Department.DepId == DepId && x.Activity == active)
                    .ToList().Select(x => Factory.Create(x));
                if (employees == null) return NotFound();
                else
                    return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //method for adding new data
        public IHttpActionResult Post(EmployeeModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                if (model == null) return NotFound();
                else
                {
                    Repository.Insert(Parser.Create(model, sch));
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //method for updating exising data
        public IHttpActionResult Put(int id, EmployeeModel model)
        {
            var sch = Repository.BaseContext();
            try
            {
                Employee employee = Repository.Get(id);
                if (employee == null || model == null) return NotFound();
                else
                {
                    Repository.Update(Parser.Create(model, sch), id);
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //method used to delete a single input from the database distinct by the ID 
        public IHttpActionResult Delete(int id)
        {

            try
            {
                Employee employee = Repository.Get(id);
                if (employee == null) return NotFound();
                else
                {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}