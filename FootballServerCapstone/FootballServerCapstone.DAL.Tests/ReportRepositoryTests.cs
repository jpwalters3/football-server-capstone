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

    public class ReportRepositoryTests
    {
        private ReportRepository _repo;

        [SetUp]
        public void SetUp()
        {
            var dbf = new DbFactory(new ConfigProvider().Config);
            _repo = new ReportRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");

        }

        [Test]
        public void CheckPlayerData()
        {
            Assert.AreEqual(1,_repo.getPlayerStatistics(6, 2).Data.Shots);
        }

        [Test]
        public void CheckTeamRecords()
        {
            Assert.AreEqual(11, _repo.getClubRecords().Data[0].Losses);
        }

        [Test]
        public void TestMostCleanSheets()
        {
            Assert.AreEqual(11, _repo.getMostCleanSheets(1).Data.Count);
            Assert.AreEqual(2, _repo.getMostCleanSheets(1).Data[0].TotalCleanSheets);
        }

        [Test]
        public void TestTopAssists()
        {
            Assert.AreEqual(11, _repo.getTopAssists(1).Data.Count);
            Assert.AreEqual(10, _repo.getTopAssists(1).Data[0].TotalAssists);
        }

        [Test]
        public void TestTopScorer()
        {
            Assert.AreEqual(10, _repo.getTopScorer(1).Data.Count);
            Assert.AreEqual(13, _repo.getTopScorer(1).Data[0].TotalGoals);
        }
    }
}
