using Microsoft.EntityFrameworkCore;
using RezervationTestCase.DataAccess.Configuration;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.Context
{
    public class TestCaseDbContext :DbContext
    {
        public TestCaseDbContext(DbContextOptions<TestCaseDbContext> options): base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<BookingStatus> BookingStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration ());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration ());
        }
    }
}
