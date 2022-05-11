using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;

namespace FootballServerCapstone.DAL.Repositories
{
    public class ClubRepository : IClubRepository
    {
        public DbFactory DbFac { get; set; }
        public ClubRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }

        public Response<Club> Insert(Club club)
        {
            Response<Club> result = new Response<Club>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Club.Add(club);
                        db.SaveChanges();

                        result.Data = club;
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
        public Response Delete(int clubId)
        {
            Response result = new Response();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Club.Remove(db.Club.Find(clubId));
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
        public Response Update(Club club)
        {
            Response result = new Response();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Club.Update(club);
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

        public Response<Club> GetById(int clubId)
        {
            Response<Club> result = new Response<Club>();

            try
            {
                using(var db = DbFac.GetDbContext())
                {
                    result.Data = db.Club.Find(clubId);

                    if(result.Data == null)
                    {
                        result.Message.Add($"Club #{clubId} not found");
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
        public Response<List<Club>> GetAll()
        {
            Response<List<Club>> result = new Response<List<Club>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Club.ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No clubs found");
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
        public Response<List<Loan>> GetLoans(int clubId)
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan
                                    .Where(l => (l.ParentClubId == clubId) ||
                                                (l.LoanClubId == clubId))
                                    .ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No loans found");
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
    }
}
