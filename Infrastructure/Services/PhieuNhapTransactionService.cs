using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuNhap;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Infrastructure.Services;

public sealed class PhieuNhapTransactionService(KhoDbContext db) : IPhieuNhapTransactionService
{
    public async Task<PhieuNhapTransactionResponse> CreateAsync(
        PhieuNhapTransactionRequest request,
        CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.PhieuNhap);
        ArgumentNullException.ThrowIfNull(request.ChiTietPhieuNhaps);

        if (await db.PhieuNhaps.AnyAsync(
                item => item.SoPhieuNhap == request.PhieuNhap.SoPhieuNhap, ct))
        {
            throw new EntityConflictException("Số phiếu nhập đã tồn tại.");
        }

        await using var transaction = await db.Database.BeginTransactionAsync(ct);

        var header = new PhieuNhap
        {
            SoPhieuNhap = request.PhieuNhap.SoPhieuNhap,
            NgayNhap = request.PhieuNhap.NgayNhap,
            MaChungTu = request.PhieuNhap.MaChungTu,
            SoDonHang = request.PhieuNhap.SoDonHang,
            SoHoaDon = request.PhieuNhap.SoHoaDon,
            PhieuYeuCau = request.PhieuNhap.PhieuYeuCau,
            MaNcc = request.PhieuNhap.MaNcc,
            MaHopDong = request.PhieuNhap.MaHopDong,
            MaGiaoDich = request.PhieuNhap.MaGiaoDich,
            MaKhoHang = request.PhieuNhap.MaKhoHang,
            MaKhoXuat = request.PhieuNhap.MaKhoXuat,
            TenPhanXuong = request.PhieuNhap.TenPhanXuong,
            MaBoPhan = request.PhieuNhap.MaBoPhan,
            TenBoPhan = request.PhieuNhap.TenBoPhan,
            UserTaoPo = request.PhieuNhap.UserTaoPo,
            NguoiLapPhieu = request.PhieuNhap.NguoiLapPhieu,
            MaCdgtPhieu = request.PhieuNhap.MaCdgtPhieu,
            TrangThaiPhieu = request.PhieuNhap.TrangThaiPhieu
        };

        var details = request.ChiTietPhieuNhaps.Select(item => new ChiTietPhieuNhap
        {
            SoPhieuNhap = header.SoPhieuNhap,
            MaHang = item.MaHang,
            Dvt = item.Dvt,
            SoLuong = item.SoLuong,
            TkNo = item.TkNo,
            TkCo = item.TkCo,
            MaPhi = item.MaPhi,
            DonTrongThietKe = item.DonTrongThietKe,
            TyLeDonTrongThucTeThietKe = item.TyLeDonTrongThucTeThietKe,
            CaSanXuat = item.CaSanXuat,
            MaySanXuat = item.MaySanXuat,
            MaCdgtVt = item.MaCdgtVt,
            MaLoi = item.MaLoi,
            TenLoi = item.TenLoi,
            SoLenhSx = item.SoLenhSx,
            DonHangGc = item.DonHangGc,
            GiaGc = item.GiaGc,
            TienGc = item.TienGc
        }).ToList();

        db.PhieuNhaps.Add(header);
        db.ChiTietPhieuNhaps.AddRange(details);
        await db.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);

        return new PhieuNhapTransactionResponse(
            header.SoPhieuNhap,
            details.Select(item => item.Id).ToList());
    }
}
