using t11.Application.Dtos.PhieuDieuChuyen;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class ChiTietDieuChuyenController(
    ICrudService<ChiTietDieuChuyen, int, ChiTietDieuChuyenCrudRequest, ChiTietDieuChuyenCrudResponse> service,
    KhoDbContext db)
    : CrudController<ChiTietDieuChuyen, int, ChiTietDieuChuyenCrudRequest, ChiTietDieuChuyenCrudResponse>(service, db);
