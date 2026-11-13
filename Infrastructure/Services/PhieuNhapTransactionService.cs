using Microsoft.EntityFrameworkCore;
using t11.Application.Dtos.PhieuNhap;
using t11.Application.Services;
using t11.Infrastructure.Persistence;

namespace t11.Infrastructure.Services;

public sealed class PhieuNhapTransactionService(KhoDbContext db) : IPhieuNhapTransactionService
{
    public async Task<PhieuNhapTransactionResponse> CreateAsync(
        PhieuNhapTransactionRequest request,
        CancellationToken ct)
    {
        await using var transaction = await db.Database.BeginTransactionAsync(ct);

        // TODO: Lưu đầu phiếu và toàn bộ chi tiết trong transaction này.
        throw new NotImplementedException("Cần hoàn thiện quy tắc nghiệp vụ phiếu nhập.");
    }
}
