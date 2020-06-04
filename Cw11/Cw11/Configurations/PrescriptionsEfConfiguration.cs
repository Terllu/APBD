using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class PrescriptionsEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder
                .HasKey(e => e.IdPrescription); //[Key]

            builder
                .Property(e => e.Date).IsRequired(); //[Key]

            builder
                .Property(e => e.DueDate).IsRequired(); //[Key]

            builder
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(e => e.IdPatient)
                .IsRequired();

            builder
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(e => e.IdDoctor)
                .IsRequired();
        }
    }
}
