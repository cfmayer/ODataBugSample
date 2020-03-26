using Microsoft.EntityFrameworkCore;
using ODataBugSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataBugSample
{
    public class VehicleDbContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Wheel> Wheels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VehiclesDb");
            optionsBuilder.UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Wheel>().HasKey(x => x.Id);
            mb.Entity<Wheel>().HasOne(x=>x.Vehicle).WithMany(x=>x.Wheels).HasForeignKey(x=>x.VehicleId);
            mb.Entity<Vehicle>().HasKey(x => x.Id);

            var wheels = new List<Wheel>();
            wheels.Add(new Wheel() { Id = 1, Condition = "New", VehicleId = 1 });
            wheels.Add(new Wheel() { Id = 2, Condition = "Good", VehicleId = 1 });
            wheels.Add(new Wheel() { Id = 3, Condition = "Damaged", VehicleId = 1 });
            wheels.Add(new Wheel() { Id = 4, Condition = "Replace", VehicleId = 1 });

            mb.Entity<Vehicle>().HasData(new Vehicle() { Id = 1, Make = "Ford", Model = "Excursion" });

            mb.Entity<Wheel>().HasData(new Wheel() { Id = 1, Condition = "New", VehicleId = 1 });
            //mb.Entity<Wheel>().HasData(new Wheel() { Id = 2, Condition = "Good", VehicleId = 1 });
            //mb.Entity<Wheel>().HasData(new Wheel() { Id = 3, Condition = "Damaged", VehicleId = 1 });
            //mb.Entity<Wheel>().HasData(new Wheel() { Id = 4, Condition = "Replace", VehicleId = 1 });

        }
    }
}
