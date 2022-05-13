using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonController(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }
        [HttpGet]
        public IActionResult GetSeasons()
        {
            var seasons = _seasonRepository.GetAll();
            if (seasons.Success)
            {
                if (seasons.Data.Count == 0)
                {
                    return NotFound();
                }
                return Ok(seasons.Data);
            }
            else
            {
                return BadRequest(seasons.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetSeason")]
        public IActionResult GetSeason(int id)
        {
            var season = _seasonRepository.GetById(id);
            if (season.Success)
            {
                if (season.Data == null)
                {
                    return NotFound();
                }
                return Ok(new SeasonModel()
                {
                    SeasonId = season.Data.SeasonId,
                    Year = season.Data.Year,
                });
            }
            else
            {
                return BadRequest(season.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/match/{id}", Name = "GetMatchesBySeason")]
        public IActionResult GetMatchesBySeason(int id)
        {
            var matches = _seasonRepository.GetMatches(id);
            if (matches.Success)
            {
                if (matches.Data.Count == 0)
                {
                    return NotFound();
                }
                return Ok(matches.Data);
            }
            else
            {
                return BadRequest(matches.Message);
            }
        }
        [HttpPost]
        public IActionResult AddSeason(ViewSeasonModel season)
        {
            if (ModelState.IsValid)
            {
                Season newSeason = new Season()
                {
                    Year = season.Year
                };
                var result = _seasonRepository.Insert(newSeason);
                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetSeason), new { id = result.Data.SeasonId }, result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public IActionResult UpdateSeason(ViewSeasonModel season)
        {
            if (ModelState.IsValid && season.SeasonId > 0)
            {
                Season updatedSeason = new Season()
                {
                    SeasonId = season.SeasonId,
                    Year = season.Year
                };
                var findResult = _seasonRepository.GetById(season.SeasonId);
                if (!findResult.Success)
                {
                    return BadRequest(findResult.Message);
                }
                else
                {
                    if (findResult.Data == null)
                    {
                        return NotFound();
                    }
                }
                var result = _seasonRepository.Update(updatedSeason);
                if (result.Success)
                {
                    return Ok(updatedSeason);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (season.SeasonId < 1)
                    ModelState.AddModelError("SeasonId", "SeasonId must be greater than 0");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{seasonId}")]
        public IActionResult DeleteSeason(int seasonId)
        {
            var findResult = _seasonRepository.GetById(seasonId);
            if (!findResult.Success)
            {
                return BadRequest(findResult.Message);
            }
            else
            {
                if (findResult.Data == null)
                {
                    return NotFound();
                }
            }
            var result = _seasonRepository.Delete(seasonId);
            if (result.Success)
            {
                return Ok(findResult.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
