using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NPVCalculator.Controllers;
using NPVCalculator.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class NPVController_Test
    {
        private Mock<NPVContext> npvContextMock;
        private Mock<DbSet<NPVQuery>> npvQueryMock;
        private NPVController npvController;

        [SetUp]
        public void Setup()
        {
            npvQueryMock = new Mock<DbSet<NPVQuery>>();
            npvContextMock = new Mock<NPVContext>();

            npvContextMock.Setup(m => m.NPVQueries).Returns(npvQueryMock.Object);
            npvQueryMock.Setup(m => m.Add(It.IsAny<NPVQuery>()));
            npvContextMock.Setup(m => m.SaveChanges());

            npvController = new NPVController(npvContextMock.Object);
        }

        [Test]
        public void CalculateNPV_Test()
        {
            var cashFlows = new List<CashFlow>();
            cashFlows.Add(new CashFlow() { Amount = 2000 });
            cashFlows.Add(new CashFlow() { Amount = 4000 });
            cashFlows.Add(new CashFlow() { Amount = 5500 });
            var query = new NPVQuery() { InitialInvestment = 10000, LowerBoundRate = 1, UpperBoundRate = 3, RateIncrement = 0.5m, CashFlows = cashFlows };
            var result = npvController.CalculateNPV(query);

            // Should have 5 query results
            Assert.AreEqual(result.QueryResults.Count, 5);
            // Check query result values
            decimal[] resultToCompare = { 1239.63m, 1112.83m, 988.23m, 865.77m, 745.41m };
            var index = 0;
            foreach (var res in result.QueryResults)
            {
                Assert.AreEqual(Math.Round(res.Result, 2), resultToCompare[index]);
                index++;
            }
        }

        [Test]
        public void Get_Test()
        {
            var result = npvController.Get();
            Assert.IsNotNull(result);
        }

        [Test]
        public void Post_Test()
        {
            var cashFlows = new List<CashFlow>();
            cashFlows.Add(new CashFlow() { Amount = 2000 });
            cashFlows.Add(new CashFlow() { Amount = 4000 });
            cashFlows.Add(new CashFlow() { Amount = 5500 });
            var query = new NPVQuery() { InitialInvestment = 10000, LowerBoundRate = 1, UpperBoundRate = 3, RateIncrement = 0.5m, CashFlows = cashFlows };

            var result = npvController.Post(query);
            Assert.IsInstanceOf<OkObjectResult>(result);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content.Value);
        }

        [Test]
        public void Power_Test()
        {
            var result = npvController.Power(5, 2);
            Assert.AreEqual(result, 25);

            result = npvController.Power(10, 3);
            Assert.AreEqual(result, 1000);
        }
    }
}