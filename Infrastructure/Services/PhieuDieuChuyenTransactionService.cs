using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuDieuChuyen;
using t11.Application.Services;
using t11.Infrastructure.Persistence;

namespace t11.Infrastructure.Services;

public sealed class PhieuDieuChuyenTransactionService(KhoDbContext db) : IPhieuDieuChuyenTransactionService
{
    public async Task<PhieuDieuChuyenTransactionResponse> CreateAsync(
        PhieuDieuChuyenTransactionRequest request,
        CancellationToken ct)
    {
        if (request.PhieuDieuChuyen.MaKhoXuat == request.PhieuDieuChuyen.MaKhoNhap)
            throw new EntityValidationException("Kho xuất phải khác kho nhập.");

        await using var transaction = await db.Database.BeginTransactionAsync(ct);

        // TODO: Lưu đầu phiếu và toàn bộ chi tiết trong transaction này.
        throw new NotImplementedException("Cần hoàn thiện quy tắc nghiệp vụ điều chuyển.");
    }
}
