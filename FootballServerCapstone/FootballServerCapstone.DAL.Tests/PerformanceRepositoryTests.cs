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
    public class PerformanceRepositoryTests
    {
        PerformanceRepository db;
        DbFactory dbf;

        Performance newPerformance = new Performance
        {
            MatchId = 1,
            PlayerId = 1,
            ShotsOnTarget = 8,
            Fouls = 1,
            Goals = 3,
            Assists = 0,
            Saves = 0,
            Shots = 12,
            Passes = 30,
            PassesCompleted = 19,
            Dribbles = 9,
            DribblesSucceeded = 5,
            Tackles = 2,
            TacklesSucceeded = 1,
            CleanSheet = true,
            PositionId = 4
        };

        Performance updatePerformance = new Performance
        {
            MatchId = 5,
            PlayerId = 1,
            ShotsOnTarget = 6,
            Fouls = 1,
            Goals = 3,
            Assists = 0,
            Saves = 0,
            Shots = 12,
            Passes = 30,
            PassesCompleted = 19,
            Dribbles = 9,
            DribblesSucceeded = 5,
            Tackles = 2,
            TacklesSucceeded = 1,
            CleanSheet = true,
            PositionId = 4
        };

        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new PerformanceRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }
        [Test]
        public void TestGetByMatch()
        {
            var result = db.GetByMatch(1);
            Assert.AreEqual(2, result.Data.Count());
        }
        [Test]
        public void TestGetByPlayer()
        {
            var result = db.GetByPlayer(1);
            Assert.AreEqual(3, result.Data.Count());
        }
        [Test]
        public void TestGetById()
        {
            var result = db.GetById(5, 1);
            Assert.AreEqual(8, result.Data.ShotsOnTarget);
        }
        [Test]
        public void TestInsert()
        {
            db.Insert(newPerformance);
            var result = db.GetById(1, 1);
            Assert.AreEqual(12, result.Data.Shots);
        }
        [Test]
        public void TestUpdate()
        {
            db.Update(updatePerformance);
            var result = db.GetById(5, 1);
            Assert.AreEqual(12, result.Data.Shots);
        }
        [Test]
        public void TestDelete()
        {
            db.Delete(1, 4);
            var result = db.GetById(1, 4);
            Assert.IsNull(result.Data);
        }
    }
}
