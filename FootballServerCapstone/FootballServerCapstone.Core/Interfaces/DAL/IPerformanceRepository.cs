using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Entities;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IPerformanceRepository
    {
        public Response<Performance> Insert(Performance performance);
        public Response Delete(int matchId, int playerId);
        public Response Update(Loan performance);

        public Response<Performance> GetById(int matchId, int playerId);
        public Response<List<Performance>> GetAll();
        public Response<List<Performance>> GetByMatch(int matchId);
        public Response<List<Performance>> GetByPlayer(int playerId);
        public Response<List<Performance>> GetByPosition(int positionId);
    }
}
