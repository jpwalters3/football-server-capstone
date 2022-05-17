using FootballServerCapstone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IMatchRepository
    {
        public Response<Match> Insert(Match match);
        public Response Delete(int matchId);
        public Response Update(Match match);
        public Response<List<Match>> GetAll();
        public Response<Match> GetById(int matchId);
        public Response<List<Match>> GetByClub(int clubId, int seasonId);
    }
}
