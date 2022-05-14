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
            Assert.AreEqual(_repo.getPlayerStatistics(6, 2).Data.Shots, 6);
        }

        [Test]
        public void CheckTeamRecords()
        {
            Assert.AreEqual(11, _repo.getClubRecords().Data[0].Losses);
        }
    }
}
