using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.Core.DTOs;
using FootballServerCapstone.Core;

namespace FootballServerCapstone.DAL.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private DbFactory _db;
        public ReportRepository(DbFactory db)
        {
            _db = db;
        }
        public Response<List<ClubRecord>> getClubRecords()
        {
            throw new NotImplementedException();
        }

        public Response<PlayerStatistics> getPlayerStatistics(int PlayerId)
        {
            throw new NotImplementedException();
        }
    }
}
