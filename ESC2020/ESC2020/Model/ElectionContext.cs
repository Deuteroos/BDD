using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESC2020.Model
{
    public class ElectionContext : DbContext
    {
        public ElectionContext(DbContextOptions<ElectionContext> options)
            : base(options)
        {
        }

        public DbSet<Session> session { get; set; }
    }
}
