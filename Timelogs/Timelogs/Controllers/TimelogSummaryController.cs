using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Timelogs.Controllers
{
    [EnableCors("TimelogAngular")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimelogSummaryController : ControllerBase
    {
        private ITimelogSummaryRepository timelogSummaryRepo;

        public TimelogSummaryController(ITimelogSummaryRepository timelogSummaryRepo)
        {
            this.timelogSummaryRepo = timelogSummaryRepo;
        }
        // GET: TimelogSummary
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TimelogSummary>))]
        public ActionResult<IEnumerable<TimelogSummary>> Get()
        {

            return Ok(timelogSummaryRepo.Retrieve().ToList());
        }

        // GET: TimelogSummary/Details/5
        [HttpGet("{id}", Name = "GetTimelogSummaryByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(TimelogSummary))]
        public async Task<ActionResult<TimelogSummary>> Get(Guid id)
        {
            try
            {
                var result = await timelogSummaryRepo.RetrieveAsync(id);
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



        // POST: TimelogSummary/Create
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(TimelogSummary))]
        public async Task<ActionResult<TimelogSummary>> Post([FromBody] TimelogSummary timelogSummary)
        {
            try
            {
                timelogSummary.TimelogSummaryID = Guid.NewGuid();
                await timelogSummaryRepo.CreateAsync(timelogSummary);
                return CreatedAtRoute("GetTimelogSummaryByID",
                    new
                    {
                        id = timelogSummary.TimelogSummaryID
                    },
                    timelogSummary);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/TimelogSummary/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(TimelogSummary))]
        public async Task<ActionResult<TimelogSummary>> Put(Guid id, [FromBody] TimelogSummary timelogSummary)
        {
            try
            {
                var result = timelogSummaryRepo.Retrieve().FirstOrDefault(a => a.TimelogSummaryID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await timelogSummaryRepo.UpdateAsync(id, timelogSummary);

                return Ok(timelogSummary);

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
                var result = timelogSummaryRepo.Retrieve().FirstOrDefault(a => a.TimelogSummaryID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await timelogSummaryRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}