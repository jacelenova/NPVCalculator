using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPVCalculator.Models
{
    public class NPVQuery
    {
        public int Id { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal LowerBoundRate { get; set; }
        public decimal UpperBoundRate { get; set; }
        public decimal RateIncrement { get; set; }
        public virtual ICollection<CashFlow> CashFlows { get; set; }
        public virtual ICollection<QueryResult> QueryResults { get; set; }
    }
}
