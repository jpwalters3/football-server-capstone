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

        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new PerformanceRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }
    }
}
