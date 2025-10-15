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
            e.Property(x => x.Msv).HasMaxLength(50).IsRequired();
            e.Property(x => x.Ten).HasMaxLength(255).IsRequired();
            e.Property(x => x.Tuoi).IsRequired();
        });
    }
}
