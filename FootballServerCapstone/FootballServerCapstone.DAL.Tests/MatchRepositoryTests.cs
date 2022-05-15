using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballServerCapstone.DAL.Tests
{
    public class MatchRepositoryTests
    {
        MatchRepository db;
        DbFactory dbf;
        Match NewMatch = new Match
        {
            MatchDate = DateTime.Parse("2022-04-14"),
            NumberOfAttendees = 45000,
            HomeScore = 2,
            AwayScore = 1,
            HomeClubId = 1,
            VisitingClubId = 2,
            SeasonId = 1
        };
        Match StateMatch = new Match
        {
            MatchId = 1,
            MatchDate = DateTime.Parse("2018-01-01"),
            NumberOfAttendees = 34572,
            HomeScore = 3,
            AwayScore = 7,
            HomeClubId = 1,
            VisitingClubId = 2,
            SeasonId = 5
        };
        Match UpdateMatch = new Match
        {
            MatchId = 1,
            MatchDate = DateTime.Parse("2018-01-01"),
            NumberOfAttendees = 34572,
            HomeScore = 5,
            AwayScore = 5,
            HomeClubId = 1,
            VisitingClubId = 2,
            SeasonId = 1
        };
        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new MatchRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }
        [Test]
        public void TestGetById()
        {
            Assert.AreEqual(StateMatch.NumberOfAttendees, db.GetById(1).Data.NumberOfAttendees);
        }
        [Test]
        public void TestGetByClub()
        {
            Assert.AreEqual(22, db.GetByClub(1).Data.Count);
        }
        [Test]
        public void TestInsert()
        {
            db.Insert(NewMatch);
            Assert.AreEqual(23, db.GetByClub(1).Data.Count);
            Assert.AreEqual(NewMatch.AwayScore, db.GetById(51).Data.AwayScore);
        }
        [Test]
        public void TestUpdate()
        {
            db.Update(UpdateMatch);
            Assert.AreEqual(UpdateMatch.HomeScore, db.GetById(1).Data.HomeScore);
        }
        [Test]
        public void TestDelete()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(db.GetAll().Data.Count, 50);
        }
    }
}
