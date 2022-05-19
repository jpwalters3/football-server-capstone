using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using FootballServerCapstone.Core.Entities;
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
                    Performance newEmpty = new Performance()
                    {
                        MatchId = matchId,
                        PlayerId = playerId,
                        ShotsOnTarget = 0,
                        Shots = 0,
                        Fouls = 0,
                        Goals = 0,
                        Assists = 0,
                        Saves = 0,
                        Passes = 0,
                        PassesCompleted = 0,
                        Dribbles = 0,
                        DribblesSucceeded = 0,
                        Tackles = 0,
                        TacklesSucceeded = 0,
                        CleanSheet = false,
                        PositionId = 1
                    };
                    _performanceRepository.Insert(newEmpty);
                    return Ok(newEmpty);
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
        [HttpPost]
        public IActionResult AddPerformance(ViewPerformanceModel performance)
        {
            if (ModelState.IsValid)
            {
                Performance newPerformance = new Performance()
                {
                    MatchId = performance.MatchId,
                    PlayerId = performance.PlayerId,
                    Goals = performance.Goals,
                    Assists = performance.Assists,
                    Shots = performance.Shots,
                    ShotsOnTarget = performance.ShotsOnTarget,
                    Passes = performance.Passes,
                    PassesCompleted = performance.PassesCompleted,
                    Dribbles = performance.Dribbles,
                    DribblesSucceeded = performance.DribblesSucceeded,
                    Fouls = performance.Fouls,
                    Saves = performance.Saves,
                    Tackles = performance.Tackles,
                    TacklesSucceeded = performance.TacklesSucceeded,
                    CleanSheet = performance.CleanSheet,
                    PositionId = performance.PositionId,
                };

                var result = _performanceRepository.Insert(newPerformance);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetPerformance), new { matchId = result.Data.MatchId, playerId = result.Data.PlayerId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public IActionResult UpdatePerformance(ViewPerformanceModel performance)
        {
            if (ModelState.IsValid && performance.MatchId > 0 && performance.PlayerId > 0)
            {
                Performance updatedPerformance = new Performance()
                {
                    MatchId = performance.MatchId,
                    PlayerId = performance.PlayerId,
                    Goals = performance.Goals,
                    Assists = performance.Assists,
                    Shots = performance.Shots,
                    ShotsOnTarget = performance.ShotsOnTarget,
                    Passes = performance.Passes,
                    PassesCompleted = performance.PassesCompleted,
                    Dribbles = performance.Dribbles,
                    DribblesSucceeded = performance.DribblesSucceeded,
                    Fouls = performance.Fouls,
                    Saves = performance.Saves,
                    Tackles = performance.Tackles,
                    TacklesSucceeded = performance.TacklesSucceeded,
                    CleanSheet = performance.CleanSheet,
                    PositionId = performance.PositionId,
                };
                var findResult = _performanceRepository.GetById(performance.MatchId, performance.PlayerId);
                if (!findResult.Success)
                {
                    return BadRequest(findResult.Message);
                }
                else
                {
                    if (findResult.Data == null)
                    {
                        return NotFound(findResult.Message);
                    }
                }
                var result = _performanceRepository.Update(updatedPerformance);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updatedPerformance);
                }
            }
            else
            {
                if (performance.MatchId < 1)
                {
                    ModelState.AddModelError("MatchId", "Invalid Match Id");
                }
                else if (performance.PlayerId < 1)
                {
                    ModelState.AddModelError("PlayerId", "Invalid Player Id");
                }
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{matchId}/{playerId}")]
        public IActionResult DeletePerformance(int matchId, int playerId)
        {
            var findResult = _performanceRepository.GetById(matchId, playerId);
            if (!findResult.Success)
            {
                return BadRequest(findResult.Message);
            }
            else
            {
                if (findResult.Data == null)
                {
                    return NotFound(findResult.Message);
                }
            }
            var result = _performanceRepository.Delete(matchId, playerId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(findResult.Data);
            }
        }
    }
}
