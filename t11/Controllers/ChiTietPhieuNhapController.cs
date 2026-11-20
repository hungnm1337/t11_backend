using t11.Application.Dtos.PhieuNhap;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class ChiTietPhieuNhapController(
    ICrudService<ChiTietPhieuNhap, int, ChiTietPhieuNhapCrudRequest, ChiTietPhieuNhapCrudResponse> service,
    KhoDbContext db)
    : CrudController<ChiTietPhieuNhap, int, ChiTietPhieuNhapCrudRequest, ChiTietPhieuNhapCrudResponse>(service, db);
