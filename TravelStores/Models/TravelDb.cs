using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelStores.Models
{
    public class TravelDb : DbContext
    {
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Purches> Purcheses { get; set; }
    }
}