using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;

namespace SacramentPlanner.Models
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext (DbContextOptions<SacramentPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Hymn> Hymn { get; set; }
    }
}
