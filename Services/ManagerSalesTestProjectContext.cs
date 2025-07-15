using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManagerSalesTestProject;

public partial class ManagerSalesTestProjectContext : DbContext
{
    public DbSet<EquipmentModel> EquipmentModel { get; set; } = null;


    public ManagerSalesTestProjectContext(DbContextOptions<ManagerSalesTestProjectContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentModel>().ToTable("Equipment");


        modelBuilder.Entity<EquipmentModel>()
            .Property(x => x.Type)
            .HasConversion<int>();

        modelBuilder.Entity<EquipmentModel>()
                .Property(x => x.Status)
                .HasConversion<int>();

        modelBuilder.Entity<EquipmentModel>().HasData(
          new EquipmentModel { Id = 1, Name = "HP LaserJet Pro M404n", Type = EquipmentType.Printer, Status = EquipmentStatus.InUsing },
            new EquipmentModel { Id = 2, Name = "Epson WorkForce DS-530", Type = EquipmentType.Scanner, Status = EquipmentStatus.InWareHouse },
            new EquipmentModel { Id = 3, Name = "Dell UltraSharp U2720Q", Type = EquipmentType.Monitor, Status = EquipmentStatus.InUsing },
            new EquipmentModel { Id = 4, Name = "Canon imageFORMULA DR-C240", Type = EquipmentType.Scanner, Status = EquipmentStatus.InRepair },
            new EquipmentModel { Id = 5, Name = "LG 27UN880-B", Type = EquipmentType.Monitor, Status = EquipmentStatus.InWareHouse }
        );
    }

  
}
