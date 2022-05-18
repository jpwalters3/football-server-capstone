using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;

namespace FootballServerCapstone.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public DbFactory DbFac { get; set; }
        public PlayerRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int playerId)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        foreach (Loan l in db.Loan.Where(l => l.PlayerId == playerId))
                        {
                            db.Loan.Remove(l);
                        }
                        foreach (Performance p in db.Performance.Where(p => p.PlayerId == playerId).ToList())
                        {
                            db.Performance.Remove(p);
                        }
                        foreach (History h in db.History.Where(h => h.PlayerId == playerId).ToList())
                        {
                            db.History.Remove(h);
                        }
                        db.Player.Remove(db.Player.Find(playerId));
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

        public Response<List<Player>> GetAll()
        {
            Response<List<Player>> result = new Response<List<Player>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player
                                    .Include(c => c.Club)
                                    .Include(po => po.Position).ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No Players found");
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

        public Response<List<Player>> GetByClub(int clubId)
        {
            Response<List<Player>> result = new Response<List<Player>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player
                                    .Include(c => c.Club)
                                    .Include(po => po.Position)
                                    .Where(p => p.ClubId == clubId)
                                    .ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No players found in the club");
                    }
                    else { result.Success = true; }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<Player> GetById(int playerId)
        {
            Response<Player> result = new Response<Player>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player.Include(c => c.Club)
                                    .Include(po => po.Position).Where(p => p.PlayerId == playerId).FirstOrDefault();

                    if (result.Data == null)
                    {
                        result.Message.Add($"player #{playerId} not found");
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

        public Response<List<History>> GetHistory(int playerId)
        {
            Response<List<History>> result = new Response<List<History>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.History
                                    .Where(h => h.PlayerId == playerId)
                                    .ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No history found for player");
                        result.Data.Add(new History { HistoryEntry = "No history found for player" });
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

        public Response<List<Loan>> GetLoans(int playerId)
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan
                                    .Where(l => l.PlayerId == playerId)
                                    .ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No loans found for player");
                    }
                    else { result.Success = true; }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message.Add(ex.Message);
            }
            return result;
        }

        public Response<Player> Insert(Player player)
        {
            Response<Player> result = new Response<Player>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Player.Add(player);
                        db.SaveChanges();

                        result.Data = player;
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

        public Response Update(Player player)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Player.Update(player);
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
