// ThangLong.Infrastructure/Repositories/SinhVienRepository.cs
using Microsoft.EntityFrameworkCore;
using ThangLong.Domain.Entities;
using ThangLong.Domain.Repositories;
using ThangLong.Infrastructure.Data;

namespace ThangLong.Infrastructure.Repositories;

public class SinhVienRepository : ISinhVienRepository
{
    // Dependency injection of AppDbContext
    // Ha tang - lam viec voi CSDL

    private readonly AppDbContext _db;
    public SinhVienRepository(AppDbContext db) => _db = db;

    public async Task<SinhVien> CreateAsync(SinhVien sv, CancellationToken ct = default)
    {
        _db.SinhViens.Add(sv);
        await _db.SaveChangesAsync(ct);
        return sv;
    }

    public Task<SinhVien?> GetAsync(string msv, CancellationToken ct = default)
        => _db.SinhViens.AsNoTracking().FirstOrDefaultAsync(x => x.Msv == msv, ct);

    public async Task<IReadOnlyList<SinhVien>> ListAsync(CancellationToken ct = default)
        => await _db.SinhViens.AsNoTracking().OrderBy(x => x.Msv).ToListAsync(ct);

    public async Task<SinhVien> UpdateAsync(SinhVien sv, CancellationToken ct = default)
    {
        _db.SinhViens.Update(sv);
        await _db.SaveChangesAsync(ct);
        return sv;
    }

    public async Task DeleteAsync(string msv, CancellationToken ct = default)
    {
        var entity = await _db.SinhViens.FindAsync([msv], ct);
        if (entity is not null)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }

    public Task<bool> ExistsAsync(string msv, CancellationToken ct = default)
        => _db.SinhViens.AnyAsync(x => x.Msv == msv, ct);
}
