using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.DataAccess.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.BookingStatusId).IsRequired();
            builder.Property(x => x.EntiryDate).IsRequired();
            builder.Property(x => x.ExitDate).IsRequired();
            builder.Property(x => x.BookingDate).HasDefaultValueSql("getdate()");
        }
    }
}
