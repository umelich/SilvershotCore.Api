using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SilvershotCore.DataModels;

public partial class SilvershotDbContext : DbContext
{
    public SilvershotDbContext()
    {
    }

    public SilvershotDbContext(DbContextOptions<SilvershotDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SilvershotDB;Integrated Security=True;TrustServerCertificate=True;User ID=melich;Password=11;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("Item");

            entity.Property(e => e.ItemCode).HasColumnType("text");
            entity.Property(e => e.ItemDetails).HasColumnType("text");
            entity.Property(e => e.ItemId)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasColumnType("text");
            entity.Property(e => e.ItemPrice).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
