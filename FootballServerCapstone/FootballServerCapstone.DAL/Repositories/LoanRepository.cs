using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.DAL
{
    public class LoanRepository : ILoanRepository
    {
        public DbFactory DbFac { get; set; }
        public LoanRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public LoanRepository(string context)
        {

        }
        public Response Delete(int loanId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Loan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Loan> GetById(int loanId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Loan>> GetByLoanClub(int loanClubId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Loan>> GetByParentClub(int parentClubId)
        {
            throw new NotImplementedException();
        }

        public Response<Loan> Insert(Loan loan)
        {
            throw new NotImplementedException();
        }

        public Response Update(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
