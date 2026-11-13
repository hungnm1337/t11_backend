using Mapster;
using Microsoft.EntityFrameworkCore;
using t11.Application.Services;
using t11.Infrastructure.Persistence;

namespace t11.Infrastructure.Services;

public class CrudService<TEntity, TKey, TReq, TRes>(
    KhoDbContext db,
    TypeAdapterConfig mapsterConfig) : ICrudService<TEntity, TKey, TReq, TRes>
    where TEntity : class
{
    private readonly string _keyName = GetKeyPropertyName(db, typeof(TEntity));
    private readonly TypeAdapterConfig _updateConfig = CreateUpdateConfig(db, typeof(TEntity));

    public virtual async Task<PagedResult<TRes>> GetPagedAsync(int page, int size, CancellationToken ct)
    {
        if (page < 1)
            throw new ArgumentOutOfRangeException(nameof(page), "Số trang phải lớn hơn hoặc bằng 1.");
        if (size < 1 || size > 200)
            throw new ArgumentOutOfRangeException(nameof(size), "Kích thước trang phải từ 1 đến 200.");

        var skip = (long)(page - 1) * size;
        if (skip > int.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(page), "Số trang vượt quá giới hạn hỗ trợ.");

        var query = db.Set<TEntity>().AsNoTracking();
        var total = await query.CountAsync(ct);
        var items = await query
            .OrderBy(entity => EF.Property<TKey>(entity, _keyName))
            .Skip((int)skip)
            .Take(size)
            .ProjectToType<TRes>(mapsterConfig)
            .ToListAsync(ct);

        return new PagedResult<TRes>(items, total, page, size);
    }

    public virtual async Task<TRes?> GetByIdAsync(TKey id, CancellationToken ct)
    {
        return await db.Set<TEntity>()
            .AsNoTracking()
            .Where(entity => EF.Property<TKey>(entity, _keyName)!.Equals(id))
            .ProjectToType<TRes>(mapsterConfig)
            .SingleOrDefaultAsync(ct);
    }

    public virtual async Task<TRes> CreateAsync(TReq req, CancellationToken ct)
    {
        var entity = req.Adapt<TEntity>();
        var key = EF.Property<TKey>(entity, _keyName);
        var exists = await db.Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(item => EF.Property<TKey>(item, _keyName)!.Equals(key), ct);

        if (exists)
            throw new EntityConflictException("Mã đã tồn tại.");

        db.Set<TEntity>().Add(entity);
        await db.SaveChangesAsync(ct);

        key = EF.Property<TKey>(entity, _keyName);
        return await db.Set<TEntity>()
            .AsNoTracking()
            .Where(item => EF.Property<TKey>(item, _keyName)!.Equals(key))
            .ProjectToType<TRes>(mapsterConfig)
            .SingleAsync(ct);
    }

    public virtual async Task<TRes?> UpdateAsync(TKey id, TReq req, CancellationToken ct)
    {
        var entity = await db.Set<TEntity>()
            .SingleOrDefaultAsync(item => EF.Property<TKey>(item, _keyName)!.Equals(id), ct);
        if (entity is null)
            return default;

        req.Adapt(entity, _updateConfig);
        await db.SaveChangesAsync(ct);

        return await db.Set<TEntity>()
            .AsNoTracking()
            .Where(item => EF.Property<TKey>(item, _keyName)!.Equals(id))
            .ProjectToType<TRes>(mapsterConfig)
            .SingleAsync(ct);
    }

    public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken ct)
    {
        var entity = await db.Set<TEntity>()
            .SingleOrDefaultAsync(item => EF.Property<TKey>(item, _keyName)!.Equals(id), ct);
        if (entity is null)
            return false;

        db.Set<TEntity>().Remove(entity);
        await db.SaveChangesAsync(ct);
        return true;
    }

    private static string GetKeyPropertyName(KhoDbContext context, Type entityType)
    {
        // Dùng metadata EF để hỗ trợ khóa chính đơn có kiểu string hoặc int.
        var primaryKey = context.Model.FindEntityType(entityType)?.FindPrimaryKey()
            ?? throw new InvalidOperationException($"Entity {entityType.Name} chưa khai báo khóa chính.");

        if (primaryKey.Properties.Count != 1)
            throw new InvalidOperationException(
                $"CRUD dùng chung chỉ hỗ trợ khóa chính đơn; {entityType.Name} có khóa ghép.");

        return primaryKey.Properties[0].Name;
    }

    private static TypeAdapterConfig CreateUpdateConfig(KhoDbContext context, Type entityType)
    {
        var keyName = GetKeyPropertyName(context, entityType);
        var config = new TypeAdapterConfig();
        config.ForType<TReq, TEntity>().Ignore(keyName);
        return config;
    }
}
