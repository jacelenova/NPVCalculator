using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPVCalculator.Models;

namespace NPVCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NPVController : ControllerBase
    {
        private NPVContext dbContext;

        public NPVController(NPVContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/NPV
        [HttpGet]
        public IEnumerable<NPVQuery> Get()
        {
            return dbContext.NPVQueries;
        }

        // GET: api/NPV/5
        [HttpGet("{id}", Name = "Get")]
        public NPVQuery Get(int id)
        {
            return dbContext.NPVQueries.Find(id);
        }

        // POST: api/NPV
        [HttpPost]
        public IActionResult Post([FromBody] NPVQuery value)
        {
            var result = CalculateNPV(value);

            dbContext.Add<NPVQuery>(result);
            dbContext.SaveChanges();
            
            return Ok(result);
        }

        // PUT: api/NPV/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private NPVQuery CalculateNPV(NPVQuery query)
        {
            var lower = query.LowerBoundRate;
            var upper = query.UpperBoundRate;
            var inc = query.RateIncrement;
            query.QueryResults = new List<QueryResult>();

            for (var i = lower; i <= upper; i+=inc) {
                var tempResult = query.InitialInvestment * -1;
                var index = 1;
                // formula cashflow / ((1 + rate)^index )
                foreach (CashFlow cash in query.CashFlows)
                {
                    var rate = 1 + (i / 100);
                    var x = Power(rate, index);
                    var res = cash.Amount / x;
                    tempResult += res;
                    index++;
                }

                var queryResult = new QueryResult() { DiscountRate = i, Result = tempResult };
                query.QueryResults.Add(queryResult);
            }
            
            return query;
        }

        private decimal Power(decimal value, int power)
        {
            return (decimal)Math.Pow((double)value, power);
        }
    }
}
