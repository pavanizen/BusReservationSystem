﻿// <auto-generated />
using Bus.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bus.DataLayer.Migrations
{
    [DbContext(typeof(BusDbContext))]
    [Migration("20210316073925_Added Booked Seats")]
    partial class AddedBookedSeats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bus.DomainModels.Models.BookedSeats", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("A1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A10")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A5")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A6")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A7")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A8")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("A9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B10")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B5")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B6")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B7")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B8")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("B9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C10")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C5")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C6")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C7")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C8")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("C9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TripsID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeatId");

                    b.HasIndex("TripsID");

                    b.ToTable("BookedSeats");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.BusDetails", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JourneyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("TripID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvailableSeats")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BusID")
                        .HasColumnType("int");

                    b.Property<string>("JourneyDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.HasIndex("BusID");

                    b.HasIndex("RouteID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Bus.DomainModels.Models.BookedSeats", b =>
                {
                    b.HasOne("Bus.DomainModels.Models.Trip", "Trips")
                        .WithMany()
                        .HasForeignKey("TripsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Location", b =>
                {
                    b.HasOne("Bus.DomainModels.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Ticket", b =>
                {
                    b.HasOne("Bus.DomainModels.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bus.DomainModels.Models.Trip", b =>
                {
                    b.HasOne("Bus.DomainModels.Models.BusDetails", "BusDetails")
                        .WithMany("Trips")
                        .HasForeignKey("BusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bus.DomainModels.Models.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
