using NUnit.Framework;
using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace FootballServerCapstone.DAL.Tests
{
    public class ClubRepositoryTests
    {
        ClubRepository db;
        DbFactory dbf;

        Club newClub = new Club
        {
            Name = "Test Club",
            FoundingDate = DateTime.Parse("2000-08-31"),
            City = "Test City",
        };
        Club updatedClub = new Club
        {
            ClubId = 2,
            Name = "Test Club",
            FoundingDate = DateTime.Parse("2000-08-31"),
            City = "Test City",
        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new ClubRepository(dbf);

            //Proceedures.SetGoodState();

            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Insert_GivenClub_InsertClub()
        {
            db.Insert(newClub);
            Assert.AreEqual("Test City", db.GetById(6).Data.City);
        }
        [Test]
        public void Update_GivenClub_UpdateClub()
        {
            db.Update(updatedClub);
            Assert.AreEqual("Test City", db.GetById(2).Data.City);
        }

        [Test]
        public void GetById_GivenClubId_ReturnClub()
        {
            Assert.AreEqual("Sakassou", db.GetById(1).Data.City);
        }
        [Test]
        public void GetAll_ReturnClubs()
        {
            Assert.AreEqual(5, db.GetAll().Data.Count);
        }
        [Test]
        public void GetLoans_GivenClubId_ReturnLoans()
        {
            Assert.AreEqual(5, db.GetLoans(4).Data.Count);
        }
    }
}