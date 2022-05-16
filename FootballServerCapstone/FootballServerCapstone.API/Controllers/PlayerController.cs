using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        /*private readonly IHistoryRepository _historyRepository;
        private readonly ILoanRepository _loanRepository;*/

        public PlayerController(IPlayerRepository playerRepository)//, IHistoryRepository historyRepository, ILoanRepository loanRepository)
        {
            _playerRepository = playerRepository;
            /*_historyRepository = historyRepository;
            _loanRepository = loanRepository;*/
        }
        [HttpPost]
        public IActionResult AddPlayer(PlayerModel player)
        {
            Player toAdd = new Player();
            toAdd.FirstName = player.FirstName;
            toAdd.LastName = player.LastName;
            toAdd.DateOfBirth = player.DateOfBirth;
            toAdd.PositionId = player.PositionId;
            toAdd.ClubId = player.ClubId;
            toAdd.IsActive = player.IsActive;
            toAdd.IsOnLoan = player.IsOnLoan;

            var result = _playerRepository.Insert(toAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return CreatedAtRoute(nameof(GetPlayer), new { id = result.Data.PlayerId }, result.Data);
            }
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
        [HttpGet]
        [Route("/api/[controller]/{id}/loan")]
        public IActionResult GetPlayerLoans(int id)
        {
            var loan = _playerRepository.GetLoans(id);
            if (!loan.Success)
            {
                return BadRequest(loan.Message);
            }
            else
            {
                if (loan.Data == null)
                {
                    return NotFound(loan.Message);
                }
                return Ok(
                    loan.Data.Select(
                        loan => new LoanModel()
                        {
                            LoanId = loan.LoanId,
                            LoanDuration = loan.LoanDuration,
                            LoanStart = loan.LoanStart,
                            ParentClubId = loan.ParentClubId,
                            LoanClubId = loan.LoanClubId,
                            PlayerId = loan.PlayerId
                        }));
            }

        }
        [HttpGet]
        [Route("/api/[controller]/{id}/history")]
        public IActionResult GetPlayerHistory(int id)
        {
            var history = _playerRepository.GetHistory(id);
            if (!history.Success)
            {
                return BadRequest(history.Message);
            }
            else
            {
                if (history.Data == null)
                {
                    return NotFound(history.Message);
                }
                return Ok(
                    history.Data.Select(
                        history => new HistoryModel()
                        {
                            HistoryId = history.HistoryId,
                            HistoryEntry = history.HistoryEntry,
                            PlayerId = history.PlayerId
                        }));
            }

        }
    }
}