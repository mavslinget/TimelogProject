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
    public class TimelogController : ControllerBase
    {
        private ITimelogRepository timelogRepo;

        public TimelogController(ITimelogRepository timelogRepo)
        {
            this.timelogRepo = timelogRepo;
        }
        // GET: api/Timelog
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Timelog>))]
        public ActionResult<IEnumerable<Timelog>> Get()
        {

            return Ok(timelogRepo.Retrieve().ToList());
        }

        // GET: api/Timelog/5
        [HttpGet("{id}", Name = "GetTimelogByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Timelog))]
        public async Task<ActionResult<Timelog>> Get(Guid id)
        {
            try
            {
                var result = await timelogRepo.RetrieveAsync(id);
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

        //// GET: api/Timelog/5
        //[HttpGet("{page}/{itemsPerPage}", Name = "GetDepartmentWithPagination")]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(200, Type = typeof(PaginationResult<Timelog>))]

        //public async Task<ActionResult<PaginationResult<Timelog>>> Get(int page, int itemsPerPage, string filter)
        //{
        //    try
        //    {
        //        var result = new PaginationResult<Timelog>();
        //        result = timelogRepo.RetrieveTimelogWithPagination(page, itemsPerPage, filter);
        //        return result;

        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        // POST: api/Department
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Timelog))]
        public async Task<ActionResult<Timelog>> Post([FromBody] Timelog timelog)
        {
            try
            {
                timelog.LogID = Guid.NewGuid();
                await timelogRepo.CreateAsync(timelog);
                return CreatedAtRoute("GetDepartmentByID",
                    new
                    {
                        id = timelog.LogID
                    },
                    timelog);

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
        [ProducesResponseType(200, Type = typeof(Timelog))]
        public async Task<ActionResult<Timelog>> Put(Guid id, [FromBody] Timelog timelog)
        {
            try
            {
                var result = timelogRepo.Retrieve().FirstOrDefault(x => x.LogID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await timelogRepo.UpdateAsync(id, timelog);

                return Ok(timelog);

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
                var result = timelogRepo.Retrieve().FirstOrDefault(x => x.LogID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await timelogRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
