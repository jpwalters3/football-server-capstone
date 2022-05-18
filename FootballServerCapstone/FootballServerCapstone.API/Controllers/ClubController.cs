using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;

        public ClubController(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public IActionResult GetClubs()
        {
            var clubs = _clubRepository.GetAll();

            if (clubs.Success)
            {
                if(clubs.Data.Count == 0)
                {
                    return NotFound(clubs.Message);
                }
                return Ok(
                    clubs.Data.Select(c => new ClubModel()
                    {
                        ClubId = c.ClubId,
                        Name = c.Name,
                        FoundingDate = c.FoundingDate,
                        City = c.City,
                    }));
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
            else
            {
                if(club.Data == null)
                {
                    return NotFound(club.Message);
                }
                return Ok(new ClubModel()
                {
                    ClubId = club.Data.ClubId,
                    Name = club.Data.Name,
                    FoundingDate = club.Data.FoundingDate,
                    City = club.Data.City,
                });
            }    
        }
        [HttpPost, Authorize]
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
        [HttpPut, Authorize]
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
                    return BadRequest(findResult.Message);

                }
                else
                {
                    if(findResult.Data == null) 
                    {
                        return NotFound(findResult.Message);
                    }
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
        [HttpGet]
        [Route("/api/[controller]/{id}/player")]
        public IActionResult GetPlayersInClub(int id)
        {
            var player = _playerRepository.GetByClub(id);
            if (!player.Success)
            {
                return BadRequest(player.Message);
            }
            else
            {
                if (!player.Data.Any())
                {
                    return NotFound(player.Message);
                }
                return Ok(
                    player.Data.Select(
                        player => new PlayerModel()
                        {
                            PlayerId = player.PlayerId,
                            FirstName = player.FirstName,
                            LastName = player.LastName,
                            DateOfBirth = player.DateOfBirth,
                            IsActive = player.IsActive,
                            IsOnLoan = player.IsOnLoan,
                            ClubId = player.ClubId,
                            PositionId = player.PositionId,
                            ClubName = player.Club.Name,
                            PositionName = player.Position.PositionName
                        }));
            }

        }
    }
}

