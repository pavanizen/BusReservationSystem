using System;
using System.Collections.Generic;
using System.Text;
using Bus.DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace Bus.DataLayer
{
    public class BusDbContext:DbContext
    {
        public BusDbContext(DbContextOptions<BusDbContext> options)
           : base(options)
        {
        }

        public DbSet<BusDetails> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BookedSeats> BookedSeats { get; set; }


    }
}
