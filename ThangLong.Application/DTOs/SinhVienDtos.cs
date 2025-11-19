namespace ThangLong.Application.Models;

// DTO  - Request/Response to create/update entity
// DTO để tạo sinh viên
public record CreateSinhVienRequest(
    string Msv,
    string Ten,
    string Khoa,
    string Nganh,
    string KhoaHoc,
    string Lop,
    DateTime NgaySinh,
    string Email,
    string? Sdt
);
// DTO để tạo sinh viên
public record UpdateSinhVienRequest(
    string? Ten,
    string? Khoa,
    string? Nganh,
    string? KhoaHoc,
    string? Lop,
    DateTime? NgaySinh,  // nullable
    string? Email,
    string? Sdt
);
