using FootballServerCapstone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IClubRepository
    {
        public Response<Club> Insert(Club club);
        public Response Update(Club club);

        public Response<Club> GetById(int clubId);
        public Response<List<Club>> GetAll();
        public Response<List<Loan>> GetLoans(int clubId);
    }
}
