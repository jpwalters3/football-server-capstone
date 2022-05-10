using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Entities;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface ISeasonRepository
    {
        public Response<Season> Insert(Season season);
        public Response Delete(int seasonId);
        public Response Update(Season season);

        public Response<Season> GetById(int seasonId);
        public Response<List<Season>> GetAll();
        public Response<List<Match>> GetMatches(int seasonId);
    }
}
