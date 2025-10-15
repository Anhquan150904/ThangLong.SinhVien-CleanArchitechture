namespace ThangLong.Domain.Entities;

public class SinhVien
{
    public string Msv { get; set; } = default!;   // khóa chính
    public string Ten { get; set; } = default!;
    public int Tuoi { get; set; }
}
