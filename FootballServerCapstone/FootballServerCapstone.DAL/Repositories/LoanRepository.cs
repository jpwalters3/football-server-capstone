using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.Core.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.DAL
{
    public class LoanRepository : ILoanRepository
    {
        public DbFactory DbFac { get; set; }
        public LoanRepository(DbFactory dbfac)
        {
            DbFac = dbfac;
        }
        public Response Delete(int loanId)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Loan.Remove(db.Loan.Find(loanId));
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

        public Response<List<Loan>> GetAll()
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan.ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No loans found");
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

        public Response<Loan> GetById(int loanId)
        {
            Response<Loan> result = new Response<Loan>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan.Find(loanId);

                    if (result.Data == null)
                    {
                        result.Message.Add($"Loan #{loanId} not found");
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

        public Response<List<Loan>> GetByLoanClub(int loanClubId)
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan
                        .Where(l => l.LoanClubId == loanClubId).ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No loans for clun #{loanClubId} found");
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

        public Response<List<Loan>> GetByParentClub(int parentClubId)
        {
            Response<List<Loan>> result = new Response<List<Loan>>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    result.Data = db.Loan
                        .Where(l => l.ParentClubId == parentClubId).ToList();

                    if (result.Data.Count == 0)
                    {
                        result.Message.Add($"No loans for clun #{parentClubId} found");
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

        public Response<Loan> Insert(Loan loan)
        {
            Response<Loan> result = new Response<Loan>();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Loan.Add(loan);
                        db.SaveChanges();
                        
                        result.Data = loan;
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

        public Response Update(Loan loan)
        {
            Response result = new Response();
            result.Message = new List<string>();

            try
            {
                using (var db = DbFac.GetDbContext())
                {
                    try
                    {
                        db.Loan.Update(loan);
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
