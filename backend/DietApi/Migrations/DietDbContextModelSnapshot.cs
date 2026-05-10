using System;
using DietApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DietApi.Migrations
{
    [DbContext(typeof(DietDbContext))]
    partial class DietDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("DietApi.Models.FeedbackMessage", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                b.Property<DateTime>("CreatedAt").HasColumnType("TEXT");
                b.Property<string>("Email").IsRequired().HasMaxLength(160).HasColumnType("TEXT");
                b.Property<string>("Message").IsRequired().HasMaxLength(1000).HasColumnType("TEXT");
                b.Property<string>("Name").IsRequired().HasMaxLength(100).HasColumnType("TEXT");
                b.Property<string>("Phone").HasMaxLength(30).HasColumnType("TEXT");
                b.HasKey("Id");
                b.HasIndex("CreatedAt");
                b.ToTable("FeedbackMessages");
            });

            modelBuilder.Entity("DietApi.Models.User", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                b.Property<int>("Age").HasColumnType("INTEGER");
                b.Property<string>("Gender").IsRequired().HasMaxLength(20).HasColumnType("TEXT");
                b.Property<double>("Height").HasColumnType("REAL");
                b.Property<string>("Name").IsRequired().HasMaxLength(100).HasColumnType("TEXT");
                b.Property<double>("Weight").HasColumnType("REAL");
                b.HasKey("Id");
                b.HasIndex("Name");
                b.ToTable("Users");
            });

            modelBuilder.Entity("DietApi.Models.DietCalculation", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("INTEGER");
                b.Property<string>("ActivityLevel").IsRequired().HasMaxLength(80).HasColumnType("TEXT");
                b.Property<double>("ActivityCoefficient").HasColumnType("REAL");
                b.Property<int>("Calories").HasColumnType("INTEGER");
                b.Property<int>("Carbohydrates").HasColumnType("INTEGER");
                b.Property<DateTime>("CreatedAt").HasColumnType("TEXT");
                b.Property<int>("Fats").HasColumnType("INTEGER");
                b.Property<string>("Goal").IsRequired().HasMaxLength(40).HasColumnType("TEXT");
                b.Property<string>("MenuPlan").IsRequired().HasColumnType("TEXT");
                b.Property<int>("Proteins").HasColumnType("INTEGER");
                b.Property<int>("UserId").HasColumnType("INTEGER");
                b.HasKey("Id");
                b.HasIndex("CreatedAt");
                b.HasIndex("UserId");
                b.ToTable("DietCalculations");
            });

            modelBuilder.Entity("DietApi.Models.DietCalculation", b =>
            {
                b.HasOne("DietApi.Models.User", "User")
                    .WithMany("Calculations")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
                b.Navigation("User");
            });

            modelBuilder.Entity("DietApi.Models.User", b =>
            {
                b.Navigation("Calculations");
            });
#pragma warning restore 612, 618
        }
    }
}
