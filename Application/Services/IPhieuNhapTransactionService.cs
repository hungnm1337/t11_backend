using t11.Application.Dtos.PhieuNhap;

namespace t11.Application.Services;

public interface IPhieuNhapTransactionService
{
    Task<PhieuNhapTransactionResponse> CreateAsync(PhieuNhapTransactionRequest request, CancellationToken ct);
}
