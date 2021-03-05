using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanFort.Models.DALModels;

namespace PlanFort.Data
{
    public class PlanFortDBContext : IdentityDbContext
    {

        public PlanFortDBContext(DbContextOptions options) : base(options)   // < Constructor to build DB Context Class upon initialization
        {

        }

        // DBSets represents your table in your DB
        public DbSet<TripParentDAL> TripParent { get; set; }

        public DbSet<YelpChildDAL> YelpChild { get; set; }

        public DbSet<SeatGeekChildDAL> SeatGeekChild { get; set; }
    }
}
