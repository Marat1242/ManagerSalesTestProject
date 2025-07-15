using System;
using System.Collections.Generic;
using System.IO;
using ManagerSalesTestProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManagerSalesTestProject;

public partial class ManagerSalesTestProjectContext : DbContext
{
    public DbSet<EquipmentModel> Equipment { get; set; }
    public ManagerSalesTestProjectContext()
    {
    }
    //конструкторы
    public ManagerSalesTestProjectContext(DbContextOptions<ManagerSalesTestProjectContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    //конфигурация
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory);
            string parent = parentDirectory.ToString();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(parent)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            //забил- напрямую подключил в appsettings.json лежит строка 
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ManagerSalesTestProject;Username=postgres; Password=admin;");
        }
    }

    // определение свойств модели
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentModel>().ToTable("Equipment");


        modelBuilder.Entity<EquipmentModel>()
            .Property(x => x.Type)
            .HasConversion<int>();

        modelBuilder.Entity<EquipmentModel>()
                .Property(x => x.Status)
                .HasConversion<int>();

        // начальные данные для EquipmentModel
        modelBuilder.Entity<EquipmentModel>().HasData(

            new EquipmentModel { Id = 1, Name = "HP", Type = EquipmentType.Printer, Status = EquipmentStatus.InUsing },
            new EquipmentModel { Id = 2, Name = "Samsung ", Type = EquipmentType.Scanner, Status = EquipmentStatus.InWareHouse },
            new EquipmentModel { Id = 3, Name = "Asus", Type = EquipmentType.Monitor, Status = EquipmentStatus.InUsing },
            new EquipmentModel { Id = 4, Name = "Canon", Type = EquipmentType.Scanner, Status = EquipmentStatus.InRepair },
            new EquipmentModel { Id = 5, Name = "LG ", Type = EquipmentType.Monitor, Status = EquipmentStatus.InWareHouse }
        );
    }

  
}
