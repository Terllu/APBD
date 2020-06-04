using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class MedicamentsEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder
                .HasKey(e => e.IdMedicament); //[Key]

            builder
                .Property(e => e.Name).IsRequired(); //[Key]

            builder
                .Property(e => e.Description).IsRequired(); //[Key]

            builder
                .Property(e => e.Type).IsRequired(); //[Key]
        }
    }
}
