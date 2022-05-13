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
    public class SeasonRepository : ISeasonRepository
    {
        public DbFactory DbFac { get; set; }
        public SeasonRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int seasonId)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Season.Remove(db.Season.Find(seasonId));
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

        public Response<List<Season>> GetAll()
        {
            Response<List<Season>> result = new Response<List<Season>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Season.ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No seasons found");
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

        public Response<Season> GetById(int seasonId)
        {
            Response<Season> result = new Response<Season>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Season.Find(seasonId);

                    if (result.Data == null)
                    {
                        result.Message.Add($"Season #{seasonId} not found");
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

        public Response<List<Match>> GetMatches(int seasonId)
        {
            Response<List<Match>> result = new Response<List<Match>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Match.Where(m => m.SeasonId == seasonId).ToList();

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

        public Response<Season> Insert(Season season)
        {
            Response<Season> result = new Response<Season>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Season.Add(season);
                        db.SaveChanges();

                        result.Data = season;
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

        public Response Update(Season season)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Season.Update(season);
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
