﻿// <auto-generated />
using System;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cw11.Migrations
{
    [DbContext(typeof(s18801Context))]
    [Migration("20200604105432_AddedPrescriptions_MedicamentsTable")]
    partial class AddedPrescriptions_MedicamentsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cw11.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Cw11.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdMedicament")
                        .HasConstraintName("Prescription_Medicament_Medicament")
                        .IsRequired();

                    b.HasOne("Cw11.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicament")
                        .HasForeignKey("IdPrescription")
                        .HasConstraintName("Prescription_Medicament_Prescription")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
