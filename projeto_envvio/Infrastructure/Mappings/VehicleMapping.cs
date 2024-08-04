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
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .IsRequired(true)
              .ValueGeneratedOnAdd();

            builder.HasOne(x => x.ParkingLot)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.ParkingLotId);
        }
    }
}
