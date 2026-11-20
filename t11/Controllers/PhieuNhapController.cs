using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuNhap;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PhieuNhapController(
    IPhieuNhapTransactionService service,
    KhoDbContext db) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PhieuNhapTransactionResponse>> Create(
        [FromBody] PhieuNhapTransactionRequest request,
        CancellationToken ct)
    {
        var result = await service.CreateAsync(request, ct);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet("{soPhieuNhap}")]
    public async Task<ActionResult<PhieuNhapInfoResponse>> GetById(
        string soPhieuNhap,
        CancellationToken ct)
    {
        var entity = await db.PhieuNhaps
            .AsNoTracking()
            .Include(item => item.MaNccNavigation)
            .Include(item => item.MaKhoHangNavigation)
            .Include(item => item.MaKhoXuatNavigation)
            .Include(item => item.ChiTietPhieuNhaps)
                .ThenInclude(item => item.MaHangNavigation)
            .SingleOrDefaultAsync(item => item.SoPhieuNhap == soPhieuNhap, ct);

        if (entity is null)
            return NotFound();

        var response = new PhieuNhapInfoResponse(
            entity.SoPhieuNhap,
            entity.NgayNhap,
            entity.MaChungTu,
            entity.SoDonHang,
            entity.SoHoaDon,
            entity.PhieuYeuCau,
            entity.MaNcc,
            entity.MaHopDong,
            entity.MaGiaoDich,
            entity.MaKhoHang,
            entity.MaKhoXuat,
            entity.TenPhanXuong,
            entity.MaBoPhan,
            entity.TenBoPhan,
            entity.UserTaoPo,
            entity.NguoiLapPhieu,
            entity.MaCdgtPhieu,
            entity.TrangThaiPhieu,
            entity.MaNccNavigation is null ? null : new DoiTacInfoResponse(
                entity.MaNccNavigation.MaDoiTac,
                entity.MaNccNavigation.TenDoiTac,
                entity.MaNccNavigation.LoaiDoiTac,
                entity.MaNccNavigation.DiaChi,
                entity.MaNccNavigation.SoDienThoai,
                entity.MaNccNavigation.MaSoThue,
                entity.MaNccNavigation.NguoiLienHe),
            MapKho(entity.MaKhoHangNavigation),
            MapKho(entity.MaKhoXuatNavigation),
            entity.ChiTietPhieuNhaps.Select(item => new ChiTietPhieuNhapInfoResponse(
                item.Id,
                item.SoPhieuNhap,
                item.MaHang,
                item.MaHangNavigation?.TenVatTu,
                item.Dvt,
                item.SoLuong,
                item.TkNo,
                item.TkCo,
                item.MaPhi,
                item.DonTrongThietKe,
                item.TyLeDonTrongThucTeThietKe,
                item.CaSanXuat,
                item.MaySanXuat,
                item.MaCdgtVt,
                item.MaLoi,
                item.TenLoi,
                item.SoLenhSx,
                item.DonHangGc,
                item.GiaGc,
                item.TienGc)).ToList());

        return Ok(response);
    }

    private static KhoInfoResponse? MapKho(Kho? kho)
    {
        return kho is null ? null : new KhoInfoResponse(
            kho.MaKho,
            kho.TenKho,
            kho.LoaiKho,
            kho.DiaChi,
            kho.MaDoiTacPhuTrach,
            kho.GhiChu);
    }
}
