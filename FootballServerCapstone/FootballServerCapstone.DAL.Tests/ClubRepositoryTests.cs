using NUnit.Framework;
using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FootballServerCapstone.DAL.Tests
{
    public class ClubRepositoryTests
    {
        ClubRepository db;
        DbFactory dbf;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new ClubRepository(dbf);

            //dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Insert_GivenClub_InsertClub()
        {
            Assert.Fail();
        }
        [Test]
        public void Delete_GivenClubId_DeleteClub()
        {
            Assert.Fail();
        }
        [Test]
        public void Update_GivenClub_UpdateClub()
        {
            Assert.Fail();
        }

        [Test]
        public void GetById_GivenClubId_ReturnClub()
        {
            Assert.Fail();
        }
        [Test]
        public void GetAll_ReturnClubs()
        {
            Assert.Fail();
        }
        [Test]
        public void GetLoans_GivenClubId_ReturnLoans()
        {
            Assert.Fail();
        }
    }
}