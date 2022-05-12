using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;

namespace FootballServerCapstone.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public DbFactory DbFac { get; set; }
        public PlayerRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public PlayerRepository(string context)
        {

        }
        public Response Delete(int playerId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Player>> GetAll()
        {
            Response<List<Player>> result = new Response<List<Player>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player.ToList();

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
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player
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

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Player.Find(playerId);

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

        public Response<List<Loan>> GetLoans(int playerId)
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
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
            throw new NotImplementedException();
        }

        public Response Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
