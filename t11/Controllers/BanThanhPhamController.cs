using t11.Application.Dtos.BanThanhPham;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class BanThanhPhamController(
    ICrudService<BanThanhPham, string, BanThanhPhamRequest, BanThanhPhamResponse> service,
    KhoDbContext db) : CrudController<BanThanhPham, string, BanThanhPhamRequest, BanThanhPhamResponse>(service, db);
