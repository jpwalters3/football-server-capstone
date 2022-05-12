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

        public Response<History> Insert(History history)
        {
            Response<History> result = new Response<History>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.History.Add(history);
                        db.SaveChanges();

                        result.Data = history;
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
        public Response Delete(int historyId)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        History findHistory = db.History.Find(historyId);
                        if(findHistory == null)
                        {
                            result.Success = false;
                            result.Message.Add($"History #{historyId} not found");
                            return result;
                        }

                        db.History.Remove(findHistory);
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
        public Response Update(History history)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        History foundHistory = db.History.Find(history.HistoryId);
                        if (foundHistory == null)
                        {
                            result.Success = false;
                            result.Message.Add($"History #{history.HistoryId} not found");
                            return result;
                        }

                        foundHistory.HistoryEntry = history.HistoryEntry;
                        foundHistory.PlayerId = history.PlayerId;
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

        public Response<History> GetById(int historyId)
        {
            Response<History> result = new Response<History>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.History.Find(historyId);
                    if (result.Data == null)
                    {
                        result.Message.Add($"History #{historyId} not found");
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
    }
}
