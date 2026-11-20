using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuDieuChuyen;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PhieuDieuChuyenController(
    IPhieuDieuChuyenTransactionService service,
    KhoDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PhieuDieuChuyenTransactionResponse>> Create(
        [FromBody] PhieuDieuChuyenTransactionRequest request,
        CancellationToken ct)
    {
        var result = await service.CreateAsync(request, ct);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet("{maGiaoDich}")]
    public async Task<ActionResult<PhieuDieuChuyenInfoResponse>> GetById(
        string maGiaoDich,
        CancellationToken ct)
    {
        var entity = await db.PhieuDieuChuyens
            .AsNoTracking()
            .Include(item => item.MaKhachHangNavigation)
            .Include(item => item.MaKhoXuatNavigation)
            .Include(item => item.MaKhoNhapNavigation)
            .Include(item => item.ChiTietDieuChuyens)
                .ThenInclude(item => item.MaVatTuNavigation)
            .SingleOrDefaultAsync(item => item.MaGiaoDich == maGiaoDich, ct);

        if (entity is null)
            return NotFound();

        var response = new PhieuDieuChuyenInfoResponse(
            entity.MaGiaoDich,
            entity.NgayChungTu,
            entity.MaKhachHang,
            entity.NguoiThucHien,
            entity.MaKhoXuat,
            entity.MaKhoNhap,
            entity.DienGiai,
            entity.MaKhachHangNavigation is null ? null : new KhachHangInfoResponse(
                entity.MaKhachHangNavigation.MaKhachHang,
                entity.MaKhachHangNavigation.TenKhachHang,
                entity.MaKhachHangNavigation.DiaChi,
                entity.MaKhachHangNavigation.SoDienThoai,
                entity.MaKhachHangNavigation.Email,
                entity.MaKhachHangNavigation.MaSoThue,
                entity.MaKhachHangNavigation.NguoiLienHe,
                entity.MaKhachHangNavigation.GhiChu),
            MapKho(entity.MaKhoXuatNavigation),
            MapKho(entity.MaKhoNhapNavigation),
            entity.ChiTietDieuChuyens.Select(item => new ChiTietDieuChuyenInfoResponse(
                item.Id,
                item.MaGiaoDich,
                item.DonHang,
                item.MaVatTu,
                item.MaVatTuNavigation?.TenVatTu,
                item.Dvt,
                item.TonKho,
                item.SoLuong,
                item.Dvt2,
                item.SoLuong2,
                item.Gia,
                item.Tien,
                item.GiaDinhDanh,
                item.MaNxTkNo,
                item.TkVatTuTkCo,
                item.PhieuYeuCauNvl,
                item.GhiChu)).ToList());

        return Ok(response);
    }

    private static KhoInfoResponse MapKho(Kho kho)
    {
        return new KhoInfoResponse(
            kho.MaKho,
            kho.TenKho,
            kho.LoaiKho,
            kho.DiaChi,
            kho.MaDoiTacPhuTrach,
            kho.GhiChu);
    }
}
