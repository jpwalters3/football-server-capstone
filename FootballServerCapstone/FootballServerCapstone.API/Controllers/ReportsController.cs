using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.Core.DTOs;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IReportRepository _repo;

        public ReportsController(IReportRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getStats(int id)
        {
            var result = _repo.getPlayerStatistics(id, 4);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
