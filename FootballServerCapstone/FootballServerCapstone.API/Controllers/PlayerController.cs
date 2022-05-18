using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost, Authorize]
        public IActionResult AddPlayer(ViewPlayerModel player)

        {
            if (ModelState.IsValid)
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
            else
            {
                return BadRequest(ModelState);
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
                return Ok(
                    players.Data.Select(
                        players => new PlayerModel()
                        {
                            PlayerId = players.PlayerId,
                            FirstName = players.FirstName,
                            LastName = players.LastName,
                            DateOfBirth = players.DateOfBirth,
                            IsActive = players.IsActive,
                            IsOnLoan = players.IsOnLoan,
                            ClubId = players.ClubId,
                            PositionId = players.PositionId,
                            ClubName = players.Club.Name,
                            PositionName = players.Position.PositionName
                        }));
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
                    PositionId = player.Data.PositionId,
                    ClubName = player.Data.Club.Name,
                    PositionName = player.Data.Position.PositionName
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
                if (history.Data.Count == 0)
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
        [HttpPut, Authorize]
        public IActionResult UpdatePlayer(ViewPlayerModel player)
        {
            if(ModelState.IsValid && player.PlayerId > 0)
            {
                Player updatedPlayer = new Player
                {
                    PlayerId = player.PlayerId,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    DateOfBirth = player.DateOfBirth,
                    IsActive = player.IsActive,
                    IsOnLoan = player.IsOnLoan,
                    ClubId = player.ClubId,
                    PositionId = player.PositionId
                };
                var findResult = _playerRepository.GetById(player.PlayerId);
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
                var updateResult = _playerRepository.Update(updatedPlayer);
                if (!updateResult.Success)
                {
                    return BadRequest(updateResult.Message);
                }
                else
                {
                    return Ok(updateResult.Message);
                }
            }
            else
            {
                if (player.PlayerId < 1)
                    ModelState.AddModelError("PlayerId", "Invalid Player Id");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{playerId}"), Authorize]
        public IActionResult DeletePlayer(int playerId)
        {
            var findResult = _playerRepository.GetById(playerId);
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
            var deleteResult = _playerRepository.Delete(playerId);
            if (!deleteResult.Success)
            {
                return BadRequest(deleteResult.Message);
            }
            else
            {
                return Ok(deleteResult.Message);
            }
        }
    }
}