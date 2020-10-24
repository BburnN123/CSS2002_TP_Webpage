using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wms_react.Models
{
    public class AppDbContext : DbContext
    {

        // To pass configuration information to the DbContext use DbContextOptions instance
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Passing this option to the DbContext
            
        }

        public DbSet<Tracking> TrackDbSet { get; set; }
    }
}
