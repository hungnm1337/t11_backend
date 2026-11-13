using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using t11.Application.Services;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class CrudController<TEntity, TKey, TReq, TRes>(
    ICrudService<TEntity, TKey, TReq, TRes> service,
    KhoDbContext db) : ControllerBase
    where TEntity : class
{
    [HttpGet]
    public virtual async Task<ActionResult<PagedResult<TRes>>> GetPaged(
        [FromQuery, Range(1, int.MaxValue, ErrorMessage = "Số trang phải lớn hơn hoặc bằng 1.")] int page = 1,
        [FromQuery, Range(1, 200, ErrorMessage = "Kích thước trang phải từ 1 đến 200.")] int size = 20,
        CancellationToken ct = default)
    {
        return Ok(await service.GetPagedAsync(page, size, ct));
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TRes>> GetById([FromRoute] TKey id, CancellationToken ct)
    {
        var result = await service.GetByIdAsync(id, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public virtual async Task<ActionResult<TRes>> Create([FromBody] TReq request, CancellationToken ct)
    {
        var result = await service.CreateAsync(request, ct);
        var entityType = db.Model.FindEntityType(typeof(TEntity))
            ?? throw new InvalidOperationException($"Entity {typeof(TEntity).Name} chưa được cấu hình trong EF.");
        var key = entityType.FindPrimaryKey()?.Properties.Single().Name
            ?? throw new InvalidOperationException($"Entity {typeof(TEntity).Name} chưa khai báo khóa chính.");
        var value = typeof(TRes).GetProperty(key)?.GetValue(result)
            ?? throw new InvalidOperationException($"Response {typeof(TRes).Name} không có thuộc tính khóa {key}.");

        return CreatedAtAction(nameof(GetById), new { id = value }, result);
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TRes>> Update(
        [FromRoute] TKey id,
        [FromBody] TReq request,
        CancellationToken ct)
    {
        var result = await service.UpdateAsync(id, request, ct);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete([FromRoute] TKey id, CancellationToken ct)
    {
        return await service.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}
