using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class PatientsEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .HasKey(e => e.IdPatient); //[Key]

            builder
                .Property(e => e.FirstName).IsRequired(); //[Key]

            builder
                .Property(e => e.LastName).IsRequired(); //[Key]

            builder
                .Property(e => e.Birthdate).IsRequired(); //[Key]
        }
    }
}
