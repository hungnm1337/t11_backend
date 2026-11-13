namespace t11.Application.Services;

public interface ICrudService<TEntity, TKey, in TReq, TRes>
    where TEntity : class
{
    Task<PagedResult<TRes>> GetPagedAsync(int page, int size, CancellationToken ct);
    Task<TRes?> GetByIdAsync(TKey id, CancellationToken ct);
    Task<TRes> CreateAsync(TReq req, CancellationToken ct);
    Task<TRes?> UpdateAsync(TKey id, TReq req, CancellationToken ct);
    Task<bool> DeleteAsync(TKey id, CancellationToken ct);
}

public sealed record PagedResult<T>(IReadOnlyList<T> Items, int Total, int Page, int Size);

public sealed class EntityConflictException(string message) : Exception(message);

public sealed class EntityValidationException(string message) : Exception(message);
