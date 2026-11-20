using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuDieuChuyen;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Infrastructure.Services;

public sealed class PhieuDieuChuyenTransactionService(KhoDbContext db) : IPhieuDieuChuyenTransactionService
{
    public async Task<PhieuDieuChuyenTransactionResponse> CreateAsync(
        PhieuDieuChuyenTransactionRequest request,
        CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(request.PhieuDieuChuyen);
        ArgumentNullException.ThrowIfNull(request.ChiTietDieuChuyens);

        if (request.PhieuDieuChuyen.MaKhoXuat == request.PhieuDieuChuyen.MaKhoNhap)
            throw new EntityValidationException("Kho xuất phải khác kho nhập.");

        if (await db.PhieuDieuChuyens.AnyAsync(
                item => item.MaGiaoDich == request.PhieuDieuChuyen.MaGiaoDich, ct))
        {
            throw new EntityConflictException("Mã giao dịch đã tồn tại.");
        }

        await using var transaction = await db.Database.BeginTransactionAsync(ct);

        var header = new PhieuDieuChuyen
        {
            MaGiaoDich = request.PhieuDieuChuyen.MaGiaoDich,
            NgayChungTu = request.PhieuDieuChuyen.NgayChungTu,
            MaKhachHang = request.PhieuDieuChuyen.MaKhachHang,
            NguoiThucHien = request.PhieuDieuChuyen.NguoiThucHien,
            MaKhoXuat = request.PhieuDieuChuyen.MaKhoXuat,
            MaKhoNhap = request.PhieuDieuChuyen.MaKhoNhap,
            DienGiai = request.PhieuDieuChuyen.DienGiai
        };

        var details = request.ChiTietDieuChuyens.Select(item => new ChiTietDieuChuyen
        {
            MaGiaoDich = header.MaGiaoDich,
            DonHang = item.DonHang,
            MaVatTu = item.MaVatTu,
            Dvt = item.Dvt,
            TonKho = item.TonKho,
            SoLuong = item.SoLuong,
            Dvt2 = item.Dvt2,
            SoLuong2 = item.SoLuong2,
            Gia = item.Gia,
            Tien = item.Tien,
            GiaDinhDanh = item.GiaDinhDanh,
            MaNxTkNo = item.MaNxTkNo,
            TkVatTuTkCo = item.TkVatTuTkCo,
            PhieuYeuCauNvl = item.PhieuYeuCauNvl,
            GhiChu = item.GhiChu
        }).ToList();

        db.PhieuDieuChuyens.Add(header);
        db.ChiTietDieuChuyens.AddRange(details);
        await db.SaveChangesAsync(ct);
        await transaction.CommitAsync(ct);

        return new PhieuDieuChuyenTransactionResponse(
            header.MaGiaoDich,
            details.Select(item => item.Id).ToList());
    }
}
