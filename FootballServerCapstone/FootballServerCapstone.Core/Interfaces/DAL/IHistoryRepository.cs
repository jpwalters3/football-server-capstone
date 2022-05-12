using FootballServerCapstone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IHistoryRepository
    {
        public Response<History> Insert(History history);
        public Response Delete(int historyId);
        public Response Update(History history);

        public Response<History> GetById(int historyId);
    }
}
