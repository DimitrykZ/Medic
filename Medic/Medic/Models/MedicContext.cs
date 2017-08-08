using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Medic.Models
{
    public class MedicContext: DbContext
    {
       public DbSet<Territory> Territories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }

    }
}