using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet]
        [Route("{id}", Name = "GetHistory")]
        public IActionResult GetHistory(int id)
        {
            var history = _historyRepository.GetById(id);
            if (!history.Success)
            {
                return BadRequest(history.Message);
            }
            else
            {
                if(history.Data == null)
                {
                    return NotFound(history.Message);
                }
                return Ok(new HistoryModel()
                {
                    HistoryId = history.Data.HistoryId,
                    HistoryEntry = history.Data.HistoryEntry,
                    PlayerId = history.Data.PlayerId
                });
            }
        }

        [HttpPost]
        public IActionResult AddHistory(HistoryModel history)
        {
            if (ModelState.IsValid)
            {
                History newHistory = new History()
                {
                    HistoryEntry = history.HistoryEntry,
                    PlayerId = history.PlayerId
                };

                var result = _historyRepository.Insert(newHistory);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return CreatedAtRoute(nameof(GetHistory), new {id = result.Data.HistoryId}, result.Data);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHistory(int id)
        {
            var findResult = _historyRepository.GetById(id);
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

            var result = _historyRepository.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(findResult.Data);
            }
        }

        [HttpPut]
        public IActionResult UpdateHistory(HistoryModel history)
        {
            if (ModelState.IsValid && history.HistoryId > 0)
            {
                History updatedHistory = new History()
                {
                    HistoryId = history.HistoryId,
                    HistoryEntry = history.HistoryEntry,
                    PlayerId = history.PlayerId
                };

                var findResult = _historyRepository.GetById(history.HistoryId);
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

                var result = _historyRepository.Update(updatedHistory);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(updatedHistory);
                }
            }
            else
            {
                if (history.HistoryId < 1)
                {
                    ModelState.AddModelError("HistoryId", "Invalid History Id");
                }
                return BadRequest(ModelState);
            }
        }
    }
}
