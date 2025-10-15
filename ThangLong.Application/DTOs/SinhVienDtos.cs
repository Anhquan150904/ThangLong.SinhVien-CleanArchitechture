namespace ThangLong.Application.Models;

// DTO  - Reuest/Response to create/update entity
public record CreateSinhVienRequest(string Msv, string Ten, int Tuoi);
public record UpdateSinhVienRequest(string? Ten, int? Tuoi);