namespace ThangLong.Domain.Entities;

public class SinhVien
{
    public string Msv { get; set; } = default!;      // Khóa chính
    public string Ten { get; set; } = default!;
    public string Khoa { get; set; } = default!;     // Khoa
    public string Nganh { get; set; } = default!;    // Ngành
    public string KhoaHoc { get; set; } = default!;  // Khóa học
    public string Lop { get; set; } = default!;      // Lớp
    public DateTime NgaySinh { get; set; } = default!;          // Ngày tháng năm sinh
    public string Email { get; set; } = default!;    // Email
    public string? Sdt { get; set; }                 // Số điện thoại, có thể null
}
