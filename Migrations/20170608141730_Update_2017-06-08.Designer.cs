using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuantIREnergy2.Data;
using QuantIREnergy2.Models;

namespace QuantIREnergy2.Migrations
{
    [DbContext(typeof(QuantContext))]
    [Migration("20170608141730_Update_2017-06-08")]
    partial class Update_20170608
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuantIREnergy2.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<int?>("InstitutionId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Institution");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<decimal>("SharePercentage");

                    b.HasKey("Id");

                    b.ToTable("Investor");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InstitutionId");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<string>("InvoiceNumber");

                    b.Property<bool>("IsReceived");

                    b.Property<string>("Participant");

                    b.Property<DateTime>("PaymentDueDate");

                    b.Property<decimal>("TotalNetCharge");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Account", b =>
                {
                    b.HasOne("QuantIREnergy2.Models.Institution")
                        .WithMany("Accounts")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Invoice", b =>
                {
                    b.HasOne("QuantIREnergy2.Models.Institution")
                        .WithMany("Invoices")
                        .HasForeignKey("InstitutionId");
                });

            modelBuilder.Entity("QuantIREnergy2.Models.Transaction", b =>
                {
                    b.HasOne("QuantIREnergy2.Models.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");
                });
        }
    }
}
