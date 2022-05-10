using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        [HttpGet]
        public IActionResult GetClubs()
        {
            var clubs = _clubRepository.GetAll();

            if (clubs.Success)
            {
                return Ok(clubs.Data);
            }
            else
            {
                return BadRequest(clubs.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetClub")]
        public IActionResult GetClub(int id)
        {
            var club = _clubRepository.GetById(id);
            if (!club.Success)
            {
                return BadRequest(club.Message);
            }
            return Ok(new ClubModel()
            {
                ClubId = club.Data.ClubId,
                Name = club.Data.Name,
                FoundingDate = club.Data.FoundingDate,
                City = club.Data.City,
            });
        }
        [HttpPost]
        public IActionResult AddClub(ViewClubModel club)
        {
            if (ModelState.IsValid)
            {
                Club newClub = new Club()
                {
                    Name = club.Name,
                    FoundingDate = club.FoundingDate,
                    City = club.City,
                };

                var result = _clubRepository.Insert(newClub);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetClub), new { id = result.Data.ClubId }, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public IActionResult UpdateClub(ViewClubModel club)
        {
            if (ModelState.IsValid && club.ClubId > 0)
            {
                Club updatedClub = new Club()
                {
                    ClubId = club.ClubId,
                    Name = club.Name,
                    FoundingDate = club.FoundingDate,
                    City = club.City,
                };

                var findResult = _clubRepository.GetById(club.ClubId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }
                var result = _clubRepository.Update(updatedClub);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updatedClub);
                }
            }
            else
            {
                if (club.ClubId < 1)
                    ModelState.AddModelError("ClubId", "Invalid Club Id");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{clubId}")]
        public IActionResult DeleteClub(int clubId)
        {
            var findResult = _clubRepository.GetById(clubId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }
            var result = _clubRepository.Delete(findResult.Data.ClubId);
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

