// ThangLong.Infrastructure/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using ThangLong.Domain.Entities;

namespace ThangLong.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<SinhVien> SinhViens => Set<SinhVien>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<SinhVien>(e =>
        {
            e.ToTable("SinhVien");

            e.HasKey(x => x.Msv);

            e.Property(x => x.Msv)
                .HasMaxLength(50)
                .IsRequired();

            e.Property(x => x.Ten)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(x => x.Khoa)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(x => x.Nganh)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(x => x.KhoaHoc)
                .HasMaxLength(50)
                .IsRequired();

            e.Property(x => x.Lop)
                .HasMaxLength(50)
                .IsRequired();

            e.Property(x => x.NgaySinh)
                .HasColumnType("date")
                .IsRequired();

            e.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(x => x.Sdt)
                .HasMaxLength(20)
                .IsRequired(false); // nullable
        });

    }
}
