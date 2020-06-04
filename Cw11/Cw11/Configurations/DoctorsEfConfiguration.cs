using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Configurations
{
    public class DoctorsEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(e => e.IdDoctor); //[Key]

            builder
                .Property(e => e.FirstName).IsRequired(); //[Key]

            builder
                .Property(e => e.LastName).IsRequired(); //[Key]

            builder
                .Property(e => e.Email).IsRequired(); //[Key]
        }
    }
}
