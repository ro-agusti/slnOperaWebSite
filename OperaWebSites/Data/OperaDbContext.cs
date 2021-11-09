using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using OperaWebSites.Models;

namespace OperaWebSites.Data
{
    public class OperaDbContext:DbContext
    {
        public OperaDbContext() : base("KeyDB") { }
        public DbSet<Opera> Operas { get; set; }
    }
}