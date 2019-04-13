using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPVCalculator.Models
{
    public class QueryResult
    {
        public int Id { get; set; }
        public int NPVQueryId { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Result { get; set; }

        public NPVQuery NPVQuery { get; set; }
    }
}
