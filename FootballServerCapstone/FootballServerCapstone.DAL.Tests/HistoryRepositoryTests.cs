using FootballServerCapstone.Core;
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
    public class HistoryRepositoryTests
    {
        HistoryRepository db;
        DbFactory dbf;


        History existingHistory = new History
        {
            HistoryId = 1,
            HistoryEntry = "Multi-tiered optimal throughput",
            PlayerId = 25

        };
        History newHistory = new History
        {
            HistoryEntry = "TestEntry1",
            PlayerId = 25
        };
        History updatedHistory = new History
        {
            HistoryId = 1,
            HistoryEntry = "UpdatedEntry",
            PlayerId = 20

        };

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new HistoryRepository(dbf);

            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");

        }

        [Test]
        public void Insert_GivenHistoryEntry_InsertEntry()
        {
            History expectedHist = new History
            {
                HistoryId = 101,
                HistoryEntry = "TestEntry1",
                PlayerId = 25
            };

            Response<History> actual = db.Insert(newHistory);
            Assert.AreEqual(expectedHist, actual.Data);
            Assert.True(actual.Success);
        }

        [Test]
        public void Delete_GivenHistoryId_DeleteHistoryEntry()
        {
            Response deleteResult = new Response();

            deleteResult = db.Delete(1);

            Assert.True(deleteResult.Success);

            Response<History> findResult = new Response<History>();
            findResult = db.GetById(1);

            Assert.True(findResult.Success);
            Assert.IsNull(findResult.Data);
        }
        [Test]
        public void Delete_GivenNonexistantHistoryId_DoesNotDelete()
        {
            Response deleteResult = new Response();

            deleteResult = db.Delete(1000);

            Assert.False(deleteResult.Success);
        }

        [Test]
        public void Update_GivenHistoryEntry_UpdateHistoryEntry()
        {
            Response updateResult = new Response();

            updateResult = db.Update(updatedHistory);
            Assert.True(updateResult.Success);

            Response<History> findResult = db.GetById(1);
            Assert.True(findResult.Success);
            Assert.AreEqual(findResult.Data, updatedHistory);
        }
        [Test]
        public void Update_GivenEntryWithNonexistantHistoryId_DoesNotUpdate()
        {
            Response updateResult = new Response();
            updatedHistory.HistoryId = 1000;

            updateResult = db.Update(updatedHistory);
            Assert.False(updateResult.Success);

            Response<History> findResult = db.GetById(1);
            Assert.AreEqual(findResult.Data, existingHistory);
            updatedHistory.HistoryId = 1;
        }

        [Test]
        public void GetById_GivenHistoryId_ReturnHistoryEntry()
        {
            Assert.AreEqual(existingHistory, db.GetById(1).Data);
        }
        [Test]
        public void GetById_GivenNonexistantHistoryId_ReturnNull()
        {
            Response<History> result = db.GetById(1000);

            Assert.IsTrue(result.Success);
            Assert.IsNull(result.Data);
        }
    }
}
