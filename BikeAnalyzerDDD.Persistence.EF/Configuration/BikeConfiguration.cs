using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeAnalyzerDDD.Domain.Entities;
using System.Reflection.Emit;

namespace BikeAnalyzerDDD.Persistence.EF.Configuration
{
    public class BikeConfiguration : IEntityTypeConfiguration<Bike>
    {
        public void Configure(EntityTypeBuilder<Bike> builder)
        {
            builder
                    .Property(r => r.Brand)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.Model)
                    .IsRequired()
                    .HasMaxLength(30);

            builder
                    .Property(r => r.YearOfProduction)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.HeadTubeAngle)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.SeatTubeEffectiveAngle)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.TravelFrontWheel)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.TravelBackWheel)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.InnerRimWidth)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                    .Property(r => r.TireWidth)
                    .IsRequired()
                    .HasMaxLength(20);

            builder
                   .Property(r => r.Weigth)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}