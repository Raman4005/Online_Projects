using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Projects.Models;

namespace Online_Projects.Data
{
    public class Online_ProjectsContext : DbContext
    {
        public Online_ProjectsContext (DbContextOptions<Online_ProjectsContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Projects.Models.Bids> Bids { get; set; }

        public DbSet<Online_Projects.Models.Client> Client { get; set; }

        public DbSet<Online_Projects.Models.Developers> Developers { get; set; }

        public DbSet<Online_Projects.Models.Project> Project { get; set; }
    }
}
