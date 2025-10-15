using ThangLong.Domain.Entities;

namespace ThangLong.Domain.Repositories;

public interface ISinhVienRepository
{
    // CRUD operations
    Task<SinhVien> CreateAsync(SinhVien sv, CancellationToken ct = default);
    Task<SinhVien?> GetAsync(string msv, CancellationToken ct = default);
    Task<IReadOnlyList<SinhVien>> ListAsync(CancellationToken ct = default);
    Task<SinhVien> UpdateAsync(SinhVien sv, CancellationToken ct = default);
    Task DeleteAsync(string msv, CancellationToken ct = default);

    // check existence by msv
    Task<bool> ExistsAsync(string msv, CancellationToken ct = default);
}
