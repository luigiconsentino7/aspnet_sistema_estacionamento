using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class ParkingLotMapping : IEntityTypeConfiguration<ParkingLot>
    {
        public void Configure(EntityTypeBuilder<ParkingLot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .IsRequired(true)
               .ValueGeneratedOnAdd();

            builder.HasMany(x => x.Vehicles)
                .WithOne(x => x.ParkingLot)
                .HasForeignKey(x => x.ParkingLotId);
        }
    }
}
