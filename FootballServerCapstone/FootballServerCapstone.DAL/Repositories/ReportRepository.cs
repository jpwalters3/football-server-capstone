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
            result.Message = new List<string>();

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

        public Response<PlayerStatistics> getPlayerStatistics(int PlayerId, int SeasonId)
        {
            Response<PlayerStatistics> result = new Response<PlayerStatistics>();
            result.Data = new PlayerStatistics();
            result.Message = new List<string>();

            using (var conn = new SqlConnection(_db.GetConnectionString()))
            {
                var cmd = new SqlCommand("PlayerStatsBySeason", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@seasonId", SeasonId);
                cmd.Parameters.AddWithValue("@playerId", PlayerId);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result.Data.Shots = (int)reader["TotalShots"];
                    result.Data.ShotsOnTarget = (int)reader["TotalShotsOnTarget"];
                    result.Data.Fouls = (int)reader["TotalFouls"];
                    result.Data.Goals = (int)reader["TotalGoals"];
                    result.Data.Assists = (int)reader["TotalAssists"];
                    result.Data.Saves = (int)reader["TotalSaves"];
                    result.Data.Passes = (int)reader["TotalPasses"];
                    result.Data.CompletedPasses = (int)reader["TotalPassesCompleted"];
                    result.Data.Dribbles = (int)reader["TotalDribbles"];
                    result.Data.SuccessfulDribbles = (int)reader["TotalDribblesSucceeded"];
                    result.Data.Tackles = (int)reader["TotalTackles"];
                    result.Data.SuccessfulTackles = (int)reader["TotalTackledSucceeded"];
                    result.Data.TotalCleanSheet = (int)reader["TotalCleanSheet"];
                    
                }
            }

            return result;
        }
    }
}
