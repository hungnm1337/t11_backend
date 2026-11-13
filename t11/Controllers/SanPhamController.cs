using t11.Application.Dtos.SanPham;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class SanPhamController(
    ICrudService<SanPham, string, SanPhamRequest, SanPhamResponse> service,
    KhoDbContext db) : CrudController<SanPham, string, SanPhamRequest, SanPhamResponse>(service, db);
