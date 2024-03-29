﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPVCalculator.Models
{
    public class NPVContext : DbContext
    {
        public virtual DbSet<QueryResult> QueryResults { get; set; }
        public virtual DbSet<NPVQuery> NPVQueries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NPVDatabase;Trusted_Connection=True;");
        }
    }
}
