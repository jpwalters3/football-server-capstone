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
            var result = _repo.getPlayerStatistics(id, 1);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("clubs")]
        public IActionResult getClubs()
        {
            var result = _repo.getClubRecords();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("MostCleanSheets/{seasonId}")]
        public IActionResult getMostCleanSheets(int seasonId)
        {
            var result = _repo.getMostCleanSheets(seasonId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("TopAssists/{seasonId}")]
        public IActionResult getTopAssists(int seasonId)
        {
            var result = _repo.getTopAssists(seasonId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("TopScorer/{seasonId}")]
        public IActionResult getTopScorer(int seasonId)
        {
            var result = _repo.getTopScorer(seasonId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}
