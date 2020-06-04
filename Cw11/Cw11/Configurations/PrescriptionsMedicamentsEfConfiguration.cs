using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class PrescriptionsMedicamentsEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder
                .HasKey(e => new { e.IdMedicament, e.IdPrescription }); //[Key]

            builder
                .HasOne<Medicament>()
                .WithMany()
                .HasForeignKey(e => e.IdMedicament)
                .IsRequired();

            builder
                .HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(e => e.IdPrescription)
                .IsRequired();

            builder
                .Property(e => e.Dose).IsRequired(); //[Key]

            builder
                .Property(e => e.Details).IsRequired(); //[Key]
        }
    }
}
