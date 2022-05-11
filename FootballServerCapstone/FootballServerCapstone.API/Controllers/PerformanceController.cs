using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FootballServerCapstone.API.Models;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceRepository _performanceRepository;
        public PerformanceController(IPerformanceRepository performanceRepository)
        {
            _performanceRepository = performanceRepository;
        }
        [HttpGet]
        [Route("/api/[controller]/{matchId}/{playerId}", Name = "GetPerformance")]
        public IActionResult GetPerformance(int matchId, int playerId)
        {
            var performance = _performanceRepository.GetById(matchId, playerId);
            if (!performance.Success)
            {
                return BadRequest(performance.Message);
            }
            else
            {
                if (performance.Data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new PerformanceModel()
                    {
                        MatchId = performance.Data.MatchId,
                        PlayerId = performance.Data.PlayerId,
                        Goals = performance.Data.Goals,
                        Assists = performance.Data.Assists,
                        Shots = performance.Data.Shots,
                        ShotsOnTarget = performance.Data.ShotsOnTarget,
                        Passes = performance.Data.Passes,
                        PassesCompleted = performance.Data.PassesCompleted,
                        Dribbles = performance.Data.Dribbles,
                        DribblesSucceeded = performance.Data.DribblesSucceeded,
                        Fouls = performance.Data.Fouls,
                        Saves = performance.Data.Saves,
                        Tackles = performance.Data.Tackles,
                        TacklesSucceeded = performance.Data.TacklesSucceeded,
                        CleanSheet = performance.Data.CleanSheet,
                        PositionId = performance.Data.PositionId,
                    });
                }
            }

        }
        [HttpGet]
        [Route("/api/[controller]/{matchId}", Name = "GetPerformanceByMatch")]
        public IActionResult GetPerformanceByMatch(int matchId)
        {
            var performances = _performanceRepository.GetByMatch(matchId);
            if (!performances.Success)
            {
                return BadRequest(performances.Message);
            }
            else
            {
                if (performances.Data.Count == 0)
                {
                    return NotFound(performances.Message);
                }
                else
                {
                    return Ok(performances.Data);
                }
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{playerId}", Name = "GetPerformanceByPlayer")]
        public IActionResult GetPerformanceByPlayer(int playerId)
        {
            var performances = _performanceRepository.GetByPlayer(playerId);
            if (!performances.Success)
            {
                return BadRequest(performances.Message);
            }
            else
            {
                if (performances.Data.Count == 0)
                {
                    return NotFound(performances.Message);
                }
                else
                {
                    return Ok(performances.Data);
                }
            }
        }
        
    }
}
