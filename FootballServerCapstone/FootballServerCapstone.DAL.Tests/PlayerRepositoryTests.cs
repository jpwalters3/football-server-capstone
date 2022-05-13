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
    public class PlayerRepositoryTests
    {
        PlayerRepository db;
        DbFactory dbf;
        Player starter = new Player
        {
            PlayerId = 1,
            ClubId = 2,
            PositionId = 4,
            FirstName = "Phil",
            LastName = "Gallihawk",
            DateOfBirth = DateTime.Parse("2034-08-31"),
            IsActive = false,
            IsOnLoan = true
        };
        Player newPlayer = new Player
        {
            ClubId = 2,
            PositionId = 1,
            FirstName = "Fernando",
            LastName = "Torres",
            DateOfBirth = DateTime.Parse("1984-03-20"),
            IsActive = false,
            IsOnLoan = false
        };

        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new PlayerRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }
        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(30, db.GetAll().Data.Count);
        }

        [Test]
        public void TestGetById()
        {
            Assert.AreEqual(starter.LastName, db.GetById(1).Data.LastName);
        }

        [Test]
        public void TestGetByClub()
        {
            Assert.AreEqual(6, db.GetByClub(2).Data.Count);
        }

        [Test]
        public void TestGetHistory()
        {
            Assert.AreEqual(6, db.GetHistory(3).Data.Count);
        }

        [Test]
        public void TestGetLoans()
        {
            Assert.AreEqual(2, db.GetLoans(4).Data.Count);
        }
        [Test]
        public void TestInsert()
        {
            db.Insert(newPlayer);
            Assert.AreEqual("Fernando", db.GetById(31).Data.FirstName);
        }
    }
}
