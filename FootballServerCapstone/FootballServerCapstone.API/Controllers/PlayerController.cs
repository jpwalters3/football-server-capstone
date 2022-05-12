using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly ILoanRepository _loanRepository;

        public PlayerController(IPlayerRepository playerRepository, IHistoryRepository historyRepository, ILoanRepository loanRepository)
        {
            _playerRepository = playerRepository;
            _historyRepository = historyRepository;
            _loanRepository = loanRepository;
        }
        [HttpGet]
        public IActionResult GetPlayers()
        {
            var players = _playerRepository.GetAll();

            if (players.Success)
            {
                if (players.Data.Count == 0)
                {
                    return NotFound(players.Message);
                }
                return Ok(players.Data);
            }
            else
            {
                return BadRequest(players.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetPlayer")]
        public IActionResult GetPlayer(int id)
        {
            var player = _playerRepository.GetById(id);
            if (!player.Success)
            {
                return BadRequest(player.Message);
            }
            else
            {
                if (player.Data == null)
                {
                    return NotFound(player.Message);
                }
                return Ok(new PlayerModel()
                {
                    PlayerId = player.Data.PlayerId,
                    FirstName = player.Data.FirstName,
                    LastName = player.Data.LastName,
                    DateOfBirth = player.Data.DateOfBirth,
                    IsActive = player.Data.IsActive,
                    IsOnLoan = player.Data.IsOnLoan,
                    ClubId = player.Data.ClubId,
                    PositionId = player.Data.PositionId
                });
            }

        }
        /*[HttpGet]
        [Route("/api/[controller]/{id}/loan")]
        public IActionResult GetPlayerLoans(int id)
        {
            var player = _playerRepository.GetLoans(id);
            if (!player.Success)
            {
                return BadRequest(player.Message);
            }
            else
            {
                if (player.Data == null)
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
                            PositionId = player.PositionId
                        }));
            }

        }*/
    }
}