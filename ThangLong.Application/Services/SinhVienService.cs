// ThangLong.Application/Services/SinhVienService.cs
using ThangLong.Application.Models;
using ThangLong.Domain.Entities;
using ThangLong.Domain.Repositories;

namespace ThangLong.Application.Services;

public class SinhVienService
{
    private readonly ISinhVienRepository _repo;

    public SinhVienService(ISinhVienRepository repo) => _repo = repo;

    // create new sinh vien
    public async Task<SinhVien> CreateAsync(CreateSinhVienRequest req, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(req.Msv)) throw new ArgumentException("msv không được rỗng");
        if (await _repo.ExistsAsync(req.Msv, ct)) throw new InvalidOperationException($"msv đã tồn tại: {req.Msv}");

        var sv = new SinhVien { Msv = req.Msv, Ten = req.Ten, Tuoi = req.Tuoi };
        return await _repo.CreateAsync(sv, ct);
    }

    // get sinh vien by msv
    public Task<SinhVien?> GetAsync(string msv, CancellationToken ct = default)
        => _repo.GetAsync(msv, ct);

    // list all sinh vien
    public Task<IReadOnlyList<SinhVien>> ListAsync(CancellationToken ct = default)
        => _repo.ListAsync(ct);

    // update sinh vien
    public async Task<SinhVien> UpdateAsync(string msv, UpdateSinhVienRequest req, CancellationToken ct = default)
    {
        var existing = await _repo.GetAsync(msv, ct) ?? throw new KeyNotFoundException($"Không tìm thấy {msv}");
        if (req.Ten is not null) existing.Ten = req.Ten;
        if (req.Tuoi is not null) existing.Tuoi = req.Tuoi.Value;
        return await _repo.UpdateAsync(existing, ct);
    }

    // delete sinh vien
    public async Task DeleteAsync(string msv, CancellationToken ct = default)
    {
        if (!await _repo.ExistsAsync(msv, ct)) throw new KeyNotFoundException($"Không tồn tại {msv}");
        await _repo.DeleteAsync(msv, ct);
    }
}
