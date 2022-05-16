using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;

namespace FootballServerCapstone.DAL.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public DbFactory DbFac { get; set; }
        public MatchRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int matchId)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        foreach (Performance p in db.Performance.Where(p => p.MatchId == matchId).ToList())
                        {
                            db.Performance.Remove(p);
                        }
                        db.Match.Remove(db.Match.Find(matchId));
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
        public Response<List<Match>> GetAll()
        {
            Response<List<Match>> result = new Response<List<Match>>();
            result.Message = new List<string>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Match.ToList();
                }
            }


            catch(Exception ex)
            {
                result.Message.Add(ex.Message);
                result.Success=false;
                return result;
            }

            result.Success = true;
            return result;
        }

        public Response<List<Match>> GetByClub(int clubId, int seasonId)
        {
            Response<List<Match>> result = new Response<List<Match>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Match.Where(m => ((m.HomeClubId == clubId) || (m.VisitingClubId == clubId)) && m.SeasonId == seasonId).ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No matches found");
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

        public Response<Match> GetById(int matchId)
        {
            Response<Match> result = new Response<Match>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Match.Find(matchId);

                    if (result.Data == null)
                    {
                        result.Message.Add($"Match #{matchId} not found");
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

        public Response<Match> Insert(Match match)
        {
            Response<Match> result = new Response<Match>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Match.Add(match);
                        db.SaveChanges();

                        result.Data = match;
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

        public Response Update(Match match)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Match.Update(match);
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
