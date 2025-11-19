using ThangLong.Application.Models;
using ThangLong.Domain.Entities;
using ThangLong.Domain.Repositories;

namespace ThangLong.Application.Services;

public class SinhVienService
{
    private readonly ISinhVienRepository _repo;

    public SinhVienService(ISinhVienRepository repo) => _repo = repo;

    // ----- CREATE -----
    public async Task<SinhVien> CreateAsync(CreateSinhVienRequest req, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(req.Msv))
            throw new ArgumentException("Msv không được rỗng");

        if (await _repo.ExistsAsync(req.Msv, ct))
            throw new InvalidOperationException($"Msv đã tồn tại: {req.Msv}");

        var sv = new SinhVien
        {
            Msv = req.Msv,
            Ten = req.Ten,
            Khoa = req.Khoa,
            Nganh = req.Nganh,
            KhoaHoc = req.KhoaHoc,
            Lop = req.Lop,
            NgaySinh = req.NgaySinh,
            Email = req.Email,
            Sdt = req.Sdt
        };

        return await _repo.CreateAsync(sv, ct);
    }

    // ----- GET BY MSV -----
    public Task<SinhVien?> GetAsync(string msv, CancellationToken ct = default)
        => _repo.GetAsync(msv, ct);

    // ----- LIST ALL -----
    public Task<IReadOnlyList<SinhVien>> ListAsync(CancellationToken ct = default)
        => _repo.ListAsync(ct);

    // ----- UPDATE -----
    public async Task<SinhVien> UpdateAsync(string msv, UpdateSinhVienRequest req, CancellationToken ct = default)
    {
        var existing = await _repo.GetAsync(msv, ct)
            ?? throw new KeyNotFoundException($"Không tìm thấy {msv}");

        if (req.Ten is not null) existing.Ten = req.Ten;
        if (req.Khoa is not null) existing.Khoa = req.Khoa;
        if (req.Nganh is not null) existing.Nganh = req.Nganh;
        if (req.KhoaHoc is not null) existing.KhoaHoc = req.KhoaHoc;
        if (req.Lop is not null) existing.Lop = req.Lop;
        if (req.NgaySinh.HasValue)
            existing.NgaySinh = req.NgaySinh.Value;
        if (req.Email is not null) existing.Email = req.Email;
        if (req.Sdt is not null) existing.Sdt = req.Sdt;

        return await _repo.UpdateAsync(existing, ct);
    }

    // ----- DELETE -----
    public async Task DeleteAsync(string msv, CancellationToken ct = default)
    {
        if (!await _repo.ExistsAsync(msv, ct))
            throw new KeyNotFoundException($"Không tồn tại {msv}");

        await _repo.DeleteAsync(msv, ct);
    }
}
