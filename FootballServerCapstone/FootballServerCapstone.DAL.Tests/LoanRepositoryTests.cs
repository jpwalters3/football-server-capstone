using FootballServerCapstone.Core;
using FootballServerCapstone.Core.Entities;
using FootballServerCapstone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballServerCapstone.DAL.Tests
{
    public class LoanRepositoryTests
    {
        LoanRepository db;
        DbFactory dbf;

        [SetUp]
        public void SetUp()
        {
            ConfigProvider cp = new ConfigProvider();
            dbf = new DbFactory(cp.Config, FactoryMode.TEST);
            db = new LoanRepository(dbf);
            dbf.GetDbContext().Database.ExecuteSqlRaw("SetKnownGoodState");
        }

        [Test]
        public void Insert_GivenLoan_InsertLoan()
        {
            Loan expectedLoan = new Loan
            {
                LoanId = 6,
                LoanDuration = 3,
                LoanStart = new DateTime(2021, 10, 18),
                ParentClubId = 4,
                LoanClubId = 2,
                PlayerId = 4
            };
            Loan newLoan = new Loan
            {
                LoanDuration = 3,
                LoanStart = new DateTime(2021, 10, 18),
                ParentClubId = 4,
                LoanClubId = 2,
                PlayerId = 4
            };

            Response<Loan> actual = db.Insert(newLoan);
            Assert.AreEqual(expectedLoan, actual.Data);
            Assert.True(actual.Success);
        }
        [Test]
        public void Delete_GivenLoanId_DeleteLoan()
        {
            Response deleteResult = db.Delete(1);
            Assert.True(deleteResult.Success);

            Response<Loan> findResult = db.GetById(1);
            Assert.True(findResult.Success);
            Assert.IsNull(findResult.Data);
        }
        [Test]
        public void Delete_GivenNonexistantLoanId_DoesNotDelete()
        {
            Response deleteResult = db.Delete(6);
            Assert.False(deleteResult.Success);
        }
        [Test]
        public void Update_GivenLoan_UpdateLoan()
        {
            Loan updatedLoan = new Loan
            {
                LoanId = 1,
                LoanDuration = 10,
                LoanStart = new DateTime(2020, 1, 18),
                ParentClubId = 1,
                LoanClubId = 1,
                PlayerId = 1
            };

            Response updateResult = db.Update(updatedLoan);
            Assert.True(updateResult.Success);

            Response<Loan> findResult = db.GetById(1);
            Assert.True(findResult.Success);
            Assert.AreEqual(findResult.Data, updatedLoan);
        }
        [Test]
        public void Update_GivenNonexistentLoan_DoesNotUpdate()
        {
            Loan updatedLoan = new Loan
            {
                LoanId = 6,
                LoanDuration = 10,
                LoanStart = new DateTime(2020, 1, 18),
                ParentClubId = 1,
                LoanClubId = 1,
                PlayerId = 1
            };

            Response updateResult = db.Update(updatedLoan);
            Assert.False(updateResult.Success);
        }

        [Test]
        public void GettAll_ReturnAll()
        {
            Response<List<Loan>> actual = db.GetAll();
            Assert.True(actual.Success);
            Assert.AreEqual(actual.Data.Count, 5);
        }
        [Test]
        public void GetById_GivenLoanId_ReturnLoan()
        {
            Loan expectedLoan = new Loan
            {
                LoanId = 1,
                LoanDuration = 3,
                LoanStart = new DateTime(2021, 10, 18),
                ParentClubId = 4,
                LoanClubId = 2,
                PlayerId = 4
            };

            Response<Loan> actual = db.GetById(1);

            Assert.True(actual.Success);
            Assert.AreEqual(expectedLoan, actual.Data);
        }
        [Test]
        public void GetById_GivenNonexistantLoanId_ReturnLoan()
        {
            Response<Loan> actual = db.GetById(1000);

            Assert.True(actual.Success);
            Assert.IsNull(actual.Data);
        }
        [Test]
        public void GetByParentClub_GivenParentClubId_ReturnLoans()
        {
            Response<List<Loan>> result = db.GetByParentClub(2);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data.Count, 1);
        }
        [Test]
        public void GetByParentClub_GivenNonexistentParentClubId_ReturnNone()
        {
            Response<List<Loan>> result = db.GetByParentClub(1000);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data.Count, 0);
        }
        [Test]
        public void GetByLoanClub_GivenLoanClubId_ReturnLoans()
        {
            Response<List<Loan>> result = db.GetByLoanClub(2);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data.Count, 2);
        }
        [Test]
        public void GetByLoanClub_GivenNonexistentLoanClubId_ReturnNone()
        {
            Response<List<Loan>> result = db.GetByLoanClub(1000);
            Assert.True(result.Success);
            Assert.AreEqual(result.Data.Count, 0);
        }
    }
}
