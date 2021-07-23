using CloudComputingAllAboutCat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputingAllAboutCat.Data
{
    public class FactDbContext : DbContext
    {
        public FactDbContext(DbContextOptions<FactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fact> Facts { get; set; }

    }
}
