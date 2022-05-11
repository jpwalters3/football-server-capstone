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
    public class PerformanceRepository : IPerformanceRepository
    {
        public DbFactory DbFac { get; set; }
        public PerformanceRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int matchId, int playerId)
        {
            Response result = new Response();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Performance.Remove(db.Performance
                            .Where(p => p.MatchId == matchId && p.PlayerId == playerId)
                        .FirstOrDefault());
                        db.SaveChanges();

                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message.Add(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<List<Performance>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Performance> GetById(int matchId, int playerId)
        {
            Response<Performance> result = new Response<Performance>();
            try
            {
                using(var db = DbFac.GetDbContext())
                {
                    result.Data = db.Performance
                        .Where(p => p.MatchId == matchId && p.PlayerId == playerId)
                        .FirstOrDefault();
                    if(result.Data == null)
                    {
                        result.Message.Add($"Performance in match #{matchId} for player #{playerId} not found");
                    }
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<List<Performance>> GetByMatch(int matchId)
        {
            Response<List<Performance>> result = new Response<List<Performance>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Performance
                        .Where(p => p.MatchId == matchId).ToList();
                    if (result.Data == null)
                    {
                        result.Message.Add($"No performances in match #{matchId}");
                    }
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<List<Performance>> GetByPlayer(int playerId)
        {
            Response<List<Performance>> result = new Response<List<Performance>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Performance
                        .Where(p => p.PlayerId == playerId).ToList();
                    if (result.Data == null)
                    {
                        result.Message.Add($"No performances for player #{playerId}");
                    }
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<List<Performance>> GetByPosition(int positionId)
        {
            throw new NotImplementedException();
        }

        public Response<Performance> Insert(Performance performance)
        {
            Response<Performance> result = new Response<Performance>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Performance.Add(performance);
                        db.SaveChanges();

                        result.Data = performance;
                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message.Add(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response Update(Performance performance)
        {
            Response result = new Response();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Performance.Update(performance);
                        db.SaveChanges();

                        result.Success = true;
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message.Add(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }
    }
}
