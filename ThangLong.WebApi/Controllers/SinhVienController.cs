// ThangLong.WebApi/Controllers/SinhVienController.cs

using Microsoft.AspNetCore.Mvc;

using ThangLong.Application.Models;

using ThangLong.Application.Services;

using ThangLong.Domain.Entities;
 
namespace ThangLong.WebApi.Controllers;
 
[ApiController]

[Route("api/[controller]")]

public class SinhVienController : ControllerBase

{

    private readonly SinhVienService _svc;

    public SinhVienController(SinhVienService svc) => _svc = svc;
 
    // POST: api/sinhvien

    [HttpPost]

    public async Task<ActionResult<SinhVien>> Create([FromBody] CreateSinhVienRequest req, CancellationToken ct)

    {

        var sv = await _svc.CreateAsync(req, ct);

        // trả 201 + location header

        return CreatedAtAction(nameof(GetById), new { msv = sv.Msv }, sv);

    }
 
    // GET: api/sinhvien

    [HttpGet]

    public async Task<ActionResult<IReadOnlyList<SinhVien>>> List(CancellationToken ct)

        => Ok(await _svc.ListAsync(ct));
 
    // GET: api/sinhvien/{msv}

    [HttpGet("{msv}")]

    public async Task<ActionResult<SinhVien>> GetById(string msv, CancellationToken ct)

    {

        var sv = await _svc.GetAsync(msv, ct);

        return sv is null ? NotFound() : Ok(sv);

    }
 
    // PUT: api/sinhvien/{msv}

    [HttpPut("{msv}")]

    public async Task<ActionResult<SinhVien>> Update(string msv, [FromBody] UpdateSinhVienRequest req, CancellationToken ct)

        => Ok(await _svc.UpdateAsync(msv, req, ct));
 
    // DELETE: api/sinhvien/{msv}

    [HttpDelete("{msv}")]

    public async Task<IActionResult> Delete(string msv, CancellationToken ct)

    {

        await _svc.DeleteAsync(msv, ct);

        return NoContent();

    }

}

 