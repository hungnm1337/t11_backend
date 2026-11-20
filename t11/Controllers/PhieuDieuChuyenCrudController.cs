using t11.Application.Dtos.PhieuDieuChuyen;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class PhieuDieuChuyenCrudController(
    ICrudService<PhieuDieuChuyen, string, PhieuDieuChuyenHeaderRequest, PhieuDieuChuyenResponse> service,
    KhoDbContext db)
    : CrudController<PhieuDieuChuyen, string, PhieuDieuChuyenHeaderRequest, PhieuDieuChuyenResponse>(service, db);
