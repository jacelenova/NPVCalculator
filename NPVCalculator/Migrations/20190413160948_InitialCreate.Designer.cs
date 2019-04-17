﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NPVCalculator.Models;

namespace NPVCalculator.Migrations
{
    [DbContext(typeof(NPVContext))]
    [Migration("20190413160948_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NPVCalculator.Models.CashFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("NPVQueryId");

                    b.HasKey("Id");

                    b.HasIndex("NPVQueryId");

                    b.ToTable("CashFlow");
                });

            modelBuilder.Entity("NPVCalculator.Models.NPVQuery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("InitialInvestment");

                    b.Property<decimal>("LowerBoundRate");

                    b.Property<decimal>("RateIncrement");

                    b.Property<decimal>("UpperBoundRate");

                    b.HasKey("Id");

                    b.ToTable("NPVQueries");
                });

            modelBuilder.Entity("NPVCalculator.Models.QueryResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DiscountRate");

                    b.Property<int>("NPVQueryId");

                    b.Property<decimal>("Result");

                    b.HasKey("Id");

                    b.HasIndex("NPVQueryId");

                    b.ToTable("QueryResults");
                });

            modelBuilder.Entity("NPVCalculator.Models.CashFlow", b =>
                {
                    b.HasOne("NPVCalculator.Models.NPVQuery", "NPVQuery")
                        .WithMany("CashFlows")
                        .HasForeignKey("NPVQueryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NPVCalculator.Models.QueryResult", b =>
                {
                    b.HasOne("NPVCalculator.Models.NPVQuery", "NPVQuery")
                        .WithMany("QueryResults")
                        .HasForeignKey("NPVQueryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
