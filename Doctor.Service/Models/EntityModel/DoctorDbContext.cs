using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Service.Models.EntityModel;

public partial class DoctorDbContext : DbContext
{
    public DoctorDbContext()
    {
    }

    public DoctorDbContext(DbContextOptions<DoctorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoctorInformation> DoctorInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BDWTLKHAIRULKA2\\SQLEXPRESS;Initial Catalog=DoctorDB;Integrated Security=True;Pooling=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorInformation>(entity =>
        {
            entity.ToTable("DoctorInformation");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gander).HasMaxLength(20);
            entity.Property(e => e.LastAction).HasMaxLength(3);
            entity.Property(e => e.LastName).HasMaxLength(225);
            entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
