using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core.Interfaces.DAL;
using FootballServerCapstone.Core.DTOs;
using FootballServerCapstone.Core;
using Microsoft.Data.SqlClient;
using System.Data;

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
            Response<List<ClubRecord>> result = new Response<List<ClubRecord>>();

            using (var conn = new SqlConnection(_db.GetConnectionString()))
            {
                //TODO rename ClubRecords
                var cmd = new SqlCommand("ClubRecords", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    result.Data = new List<ClubRecord>();


                    //TODO match SQL response
                    while (reader.Read())
                    {
                        ClubRecord temp = new ClubRecord();
                        temp.ClubId = (int)reader["ClubId"];
                        temp.Name = reader["ClubName"].ToString();
                        temp.Wins = (int)reader["Wins"];
                        temp.Losses = (int)reader["Losses"];
                        temp.Draws = (int)reader["Draws"];
                        temp.Points = (int)reader["Points"];

                        result.Data.Add(temp);
                    }
                }
            }

            return result;
        }

        public Response<PlayerStatistics> getPlayerStatistics(int PlayerId)
        {
            throw new NotImplementedException();
        }
    }
}
