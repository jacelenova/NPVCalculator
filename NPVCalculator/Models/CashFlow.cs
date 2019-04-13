using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPVCalculator.Models
{
    public class CashFlow
    {
        public int Id { get; set; }
        public int NPVQueryId { get; set; }
        public decimal Amount { get; set; }

        public NPVQuery NPVQuery { get; set; }
    }
}
