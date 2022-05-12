using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.DAL.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        public DbFactory DbFac { get; set; }
        public HistoryRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public HistoryRepository(string context)
        {

        }
        public Response Delete(int historyId)
        {
            throw new NotImplementedException();
        }

        public Response<List<History>> GetById(int historyId)
        {
            throw new NotImplementedException();
        }

        public Response<History> Insert(History history)
        {
            throw new NotImplementedException();
        }

        public Response Update(History history)
        {
            throw new NotImplementedException();
        }
    }
}
