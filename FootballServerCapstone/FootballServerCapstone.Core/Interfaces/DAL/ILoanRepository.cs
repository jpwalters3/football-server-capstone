using FootballServerCapstone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface ILoanRepository
    {
        public Response<Loan> Insert(Loan loan);
        public Response Delete(int loanId);
        public Response Update(Loan loan);

        public Response<Loan> GetById (int loanId);
        public Response<List<Loan>> GetAll();
        public Response<List<Loan>> GetByParentClub(int parentClubId);
        public Response<List<Loan>> GetByLoanClub(int loanClubId);
    }
}
