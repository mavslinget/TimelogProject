using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Timelogs.Controllers
{
    [EnableCors("TimelogAngular")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Employees>))]
        public ActionResult<IEnumerable<Employees>> Get()
        {

            return Ok(employeeRepo.Retrieve().ToList());
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployeeByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employees))]
        public async Task<ActionResult<Employees>> Get(string id)
        {
            try
            {
                var result = await employeeRepo.RetrieveAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Employee/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetEmployeeWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Employees>))]

        public async Task<ActionResult<PaginationResult<Employees>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Employees>();
                result = employeeRepo.RetrieveEmployeeWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Employees))]
        public async Task<ActionResult<Employees>> Post([FromBody] Employees employee)
        {
            try
            {
                await employeeRepo.CreateAsync(employee);
                return CreatedAtRoute("GetEmployeeByID",
                    new
                    {
                        id = employee.EmployeeID
                    },
                    employee);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Employees))]
        public async Task<ActionResult<Employees>> Put(string id, [FromBody] Employees employee)
        {
            try
            {
                var result = employeeRepo.Retrieve().FirstOrDefault(x => x.EmployeeID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await employeeRepo.UpdateAsync(id, employee);

                return Ok(employee);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var result = employeeRepo.Retrieve().FirstOrDefault(x => x.EmployeeID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await employeeRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
