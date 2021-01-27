using Microsoft.EntityFrameworkCore;
using PcMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcMarket.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<PcPartProp> GetPcParts { get;set; }
        public DbSet<PcPartOrder> GetOrders { get; set; }
    }
}
