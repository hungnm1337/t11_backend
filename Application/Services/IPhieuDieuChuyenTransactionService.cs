using t11.Application.Dtos.PhieuDieuChuyen;

namespace t11.Application.Services;

public interface IPhieuDieuChuyenTransactionService
{
    Task<PhieuDieuChuyenTransactionResponse> CreateAsync(
        PhieuDieuChuyenTransactionRequest request,
        CancellationToken ct);
}
