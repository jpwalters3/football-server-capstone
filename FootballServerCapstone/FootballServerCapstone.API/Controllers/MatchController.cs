using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _matchRepository.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Data);
            }
        }
        [HttpGet]
        [Route("{id}", Name = "GetMatch")]
        public IActionResult GetMatch(int id)
        {
            var match = _matchRepository.GetById(id);
            if (!match.Success)
            {
                return BadRequest(match.Message);
            }
            else
            {
                if (match.Data == null)
                {
                    return NotFound(match.Message);
                }
                else
                {
                    return Ok(new MatchModel()
                    {
                        MatchId = match.Data.MatchId,
                        MatchDate = match.Data.MatchDate,
                        NumberOfAttendees = match.Data.NumberOfAttendees,
                        HomeScore = match.Data.HomeScore,
                        AwayScore = match.Data.AwayScore,
                        HomeClubId = match.Data.HomeClubId,
                        VisitingClubId = match.Data.VisitingClubId,
                        SeasonId = match.Data.SeasonId,
                    });
                }
            }
        }
        [HttpGet]

        [Route("club/{id}", Name = "GetMatchesByClub")]
        public IActionResult GetMatchesByClub(int id)

        {
            var matches = _matchRepository.GetByClub(id, 4);
            if (!matches.Success)
            {
                return BadRequest(matches.Message);
            }
            else
            {
                if (matches.Data == null)
                {
                    return NotFound(matches.Message);
                }
                else
                {
                    return Ok(matches.Data.Select(m => new MatchModel()
                    {
                        MatchId = m.MatchId,
                        MatchDate = m.MatchDate,
                        NumberOfAttendees = m.NumberOfAttendees,
                        HomeScore = m.HomeScore,
                        AwayScore = m.AwayScore,
                        HomeClubId = m.HomeClubId,
                        VisitingClubId = m.VisitingClubId,
                        SeasonId = m.SeasonId,
                    }));
                }
            }
        }
        [HttpPost]
        public IActionResult AddMatch(ViewMatchModel match)
        {
            if (ModelState.IsValid)
            {
                Match newMatch = new Match
                {
                    MatchDate = match.MatchDate,
                    NumberOfAttendees = match.NumberOfAttendees,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    HomeClubId = match.HomeClubId,
                    VisitingClubId = match.VisitingClubId,
                    SeasonId = match.SeasonId,
                };

                var result = _matchRepository.Insert(newMatch);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetMatch), new { id = result.Data.MatchId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public IActionResult UpdateMatch(ViewMatchModel match)
        {
            if (ModelState.IsValid && match.MatchId > 0)
            {
                Match updatedMatch = new Match
                {
                    MatchId = match.MatchId,
                    MatchDate = match.MatchDate,
                    NumberOfAttendees = match.NumberOfAttendees,
                    HomeScore = match.HomeScore,
                    AwayScore = match.AwayScore,
                    HomeClubId = match.HomeClubId,
                    VisitingClubId = match.VisitingClubId,
                    SeasonId = match.SeasonId,
                };

                var findResult = _matchRepository.GetById(match.MatchId);
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

                var result = _matchRepository.Update(updatedMatch);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updatedMatch);
                }
            }
            else
            {
                if (match.MatchId < 1)
                    ModelState.AddModelError("MatchId", "Invalid Match Id");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{matchId}")]
        public IActionResult DeleteMatch(int matchId)
        {
            var findResult = _matchRepository.GetById(matchId);
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
            var result = _matchRepository.Delete(matchId);
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
