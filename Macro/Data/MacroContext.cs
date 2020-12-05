using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Macro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Macro.Data
{
    public class MacroContext : IdentityDbContext 
    {
        public MacroContext (DbContextOptions<MacroContext> options)
            : base(options)
        {
        }

        public DbSet<Macro.Models.Circuit> Circuit { get; set; }
        public DbSet<Macro.Models.DiscoCircuit> DiscoCircuits { get; set; }
        public DbSet<Macro.Models.Software> Software { get; set; }
        public DbSet<Macro.Models.AdminSettings> AdminSettings { get; set; }
    }
}
