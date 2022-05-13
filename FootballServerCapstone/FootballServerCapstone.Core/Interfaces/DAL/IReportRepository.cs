using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.DTOs;

namespace FootballServerCapstone.Core.Interfaces.DAL
{
    public interface IReportRepository
    {
        public Response<List<ClubRecord>> getClubRecords();
        public Response<PlayerStatistics> getPlayerStatistics(int PlayerId, int SeasonId);
    }
}
