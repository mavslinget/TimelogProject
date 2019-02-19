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
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository departmentRepo;

        public DepartmentController(IDepartmentRepository departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }
        // GET: api/Department
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Departments>))]
        public ActionResult<IEnumerable<Departments>> Get()
        {

            return Ok(departmentRepo.Retrieve().ToList());
        }

        // GET: api/Department/5
        [HttpGet("{id}", Name = "GetDepartmentByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Departments))]
        public async Task<ActionResult<Departments>> Get(Guid id)
        {
            try
            {
                var result = await departmentRepo.RetrieveAsync(id);
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

        // GET: api/Department/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetDepartmentWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Departments>))]

        public async Task<ActionResult<PaginationResult<Departments>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Departments>();
                result = departmentRepo.RetrieveDepartmentWithPagination(page, itemsPerPage, filter);
                return result;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // POST: api/Department
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Departments))]
        public async Task<ActionResult<Departments>> Post([FromBody] Departments department)
        {
            try
            {
                department.DepartmentID = Guid.NewGuid();
                await departmentRepo.CreateAsync(department);
                return CreatedAtRoute("GetDepartmentByID",
                    new
                    {
                        id = department.DepartmentID
                    },
                    department);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Departments))]
        public async Task<ActionResult<Departments>> Put(Guid id, [FromBody] Departments department)
        {
            try
            {
                var result = departmentRepo.Retrieve().FirstOrDefault(x => x.DepartmentID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await departmentRepo.UpdateAsync(id, department);

                return Ok(department);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = departmentRepo.Retrieve().FirstOrDefault(x => x.DepartmentID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await departmentRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
