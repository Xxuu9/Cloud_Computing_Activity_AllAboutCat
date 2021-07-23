using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudComputingAllAboutCat.Data
{
    public class FactDbContext : IdentityDbContext
    {
        public FactDbContext(DbContextOptions<FactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Fact> Fact { get; set; }
    }
}