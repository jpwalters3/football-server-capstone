using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Entities;


namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IPlayerRepository
    {
        public Response<Player> Insert(Player player);
        public Response Delete(int playerId);
        public Response Update(Player player);

        public Response<Player> GetById(int playerId);
        public Response<List<Player>> GetAll();
        public Response<List<Player>> GetByClub(int clubId);
        public Response<List<History>> GetHistory(int playerId);
        public Response<List<Loan>> GetLoans(int playerId);
    }
}
