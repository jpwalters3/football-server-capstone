using FootballServerCapstone.API.Models;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballServerCapstone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        [HttpGet]
        public IActionResult GetLoans()
        {
            var loans = _loanRepository.GetAll();
            if (loans.Success)
            {
                if (loans.Data.Count == 0)
                {
                    return NotFound(loans.Message);
                }
                return Ok(loans.Data);
            }
            else
            {
                return BadRequest(loans.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{id}", Name = "GetLoan")]
        public IActionResult GetLoan(int id)
        {
            var loan = _loanRepository.GetById(id);
            if (loan.Success)
            {
                if (loan.Data == null)
                {
                    return NotFound(loan.Message);
                }
                return Ok(new LoanModel()
                {
                    LoanId = loan.Data.LoanId,
                    LoanDuration = loan.Data.LoanDuration,
                    LoanStart = loan.Data.LoanStart,
                    ParentClubId = loan.Data.ParentClubId,
                    LoanClubId = loan.Data.LoanClubId,
                    PlayerId = loan.Data.PlayerId,
                });
            }
            else
            {
                return BadRequest(loan.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{parentClubId}", Name = "GetLoansByParentClubId")]
        public IActionResult GetLoansByParentClubId(int parentClubId)
        {
            var loans = _loanRepository.GetByParentClub(parentClubId);
            if (loans.Success)
            {
                if (loans.Data.Count == 0)
                {
                    return NotFound(loans.Message);
                }
                return Ok(loans.Data);
            }
            else
            {
                return BadRequest(loans.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/{loanClubId}", Name = "GetLoansByLoanClubId")]
        public IActionResult GetLoansByLoanClubId(int loanClubId)
        {
            var loans = _loanRepository.GetByLoanClub(loanClubId);
            if (loans.Success)
            {
                if (loans.Data.Count == 0)
                {
                    return NotFound(loans.Message);
                }
                return Ok(loans.Data);
            }
            else
            {
                return BadRequest(loans.Message);
            }
        }
        [HttpPost]
        public IActionResult AddLoan(ViewLoanModel loan)
        {
            if (ModelState.IsValid)
            {
                Loan newLoan = new Loan()
                {
                    LoanDuration = loan.LoanDuration,
                    LoanStart = loan.LoanStart,
                    ParentClubId = loan.ParentClubId,
                    LoanClubId = loan.LoanClubId,
                    PlayerId = loan.PlayerId,
                };
                var result = _loanRepository.Insert(newLoan);
                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetLoan), new { id = result.Data.LoanId }, result.Data);
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
        public IActionResult UpdateLoan(ViewLoanModel loan)
        {
            if (ModelState.IsValid && loan.LoanId > 0)
            {
                Loan updatedLoan = new Loan()
                {
                    LoanId = loan.LoanId,
                    LoanDuration = loan.LoanDuration,
                    LoanStart = loan.LoanStart,
                    ParentClubId = loan.ParentClubId,
                    LoanClubId = loan.LoanClubId,
                    PlayerId = loan.PlayerId,
                };
                var findResult = _loanRepository.GetById(loan.LoanId);
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
                var result = _loanRepository.Update(updatedLoan);
                if (result.Success)
                {
                    return Ok(updatedLoan);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (loan.LoanId < 1)
                    ModelState.AddModelError("LoanId", "Invalid Loan Id");
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{loanId}")]
        public IActionResult DeleteLoan(int loanId)
        {
            var findResult = _loanRepository.GetById(loanId);
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
            var result = _loanRepository.Delete(loanId);
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
