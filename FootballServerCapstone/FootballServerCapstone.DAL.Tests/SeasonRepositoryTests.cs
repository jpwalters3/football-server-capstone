using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;

namespace FootballServerCapstone.DAL.Tests
{
    public class SeasonRepositoryTests
    {
        SeasonRepository db;
        DbFactory dbf;

        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new SeasonRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Insert_GivenSeason_InsertSeason()
        {
            Season newSeason = new Season
            {
                Year = "2012-2013"
            };
            Season expected = new Season
            {
                SeasonId = 6,
                Year = "2012-2013"
            };

            Response<Season> actual = db.Insert(newSeason);

            Assert.True(actual.Success);
            Assert.AreEqual(expected, actual.Data);
        }
        [Test]
        public void Delete_GivenSeasonId_DeleteSeason()
        {
            Response deleteResult = db.Delete(1);
            Assert.True(deleteResult.Success);

            Response<Season> findResult = db.GetById(1);
            Assert.True(findResult.Success);
            Assert.IsNull(findResult.Data);
        }
        [Test]
        public void Delete_GivenNonexistentSeasonId_DoesNotDelete()
        {
            Response deleteResult = db.Delete(1000);

            Assert.False(deleteResult.Success);
        }
        [Test]
        public void Update_GivenSeason_UpdateSeaon()
        {
            Season updatedSeason = new Season { SeasonId = 1, Year = "2019-2020" };

            Response updateResult = db.Update(updatedSeason);
            Assert.True(updateResult.Success);

            Response<Season> findResult = db.GetById(1);
            Assert.True(findResult.Success);
            Assert.AreEqual(findResult.Data, updatedSeason);
        }
        [Test]
        public void Update_GivenSeasonWithNonexistentId_DoesNotUpdate()
        {
            Season updatedSeason = new Season { SeasonId = 6, Year = "2019-2020" };

            Response updateResult = db.Update(updatedSeason);

            Assert.False(updateResult.Success);
        }

        [Test]
        public void GetById_GivenSeasonId_ReturnSeason()
        {
            Season expected = new Season { SeasonId = 1, Year = "2017-2018" };
            Response<Season> actual = db.GetById(1);

            Assert.True(actual.Success);
            Assert.AreEqual(expected, actual.Data);
        }
        [Test]
        public void GetById_GivenNonexistentSeasonId_ReturnSeason()
        {
            Response<Season> actual = db.GetById(1000);

            Assert.True(actual.Success);
            Assert.IsNull(actual.Data);
        }

        [Test]
        public void GetMatches_GivenSeasonId_ReturnMatches()
        {
            int expectedMatches = 12;

            Response<List<Match>> actual = db.GetMatches(1);

            Assert.True(actual.Success);
            Assert.AreEqual(actual.Data.Count, expectedMatches);
            Assert.AreEqual(actual.Data[0].HomeClub.Name, "Bush dog");
        }
        [Test]
        public void GetMatches_GivenNonexistentSeasonId_ReturnMatches()
        {
            int expectedMatches = 0;

            Response<List<Match>> actual = db.GetMatches(1000);

            Assert.True(actual.Success);
            Assert.AreEqual(actual.Data.Count, expectedMatches);
        }
    }
}
