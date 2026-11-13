using t11.Application.Dtos.KhachHang;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class KhachHangController(
    ICrudService<KhachHang, string, KhachHangRequest, KhachHangResponse> service,
    KhoDbContext db) : CrudController<KhachHang, string, KhachHangRequest, KhachHangResponse>(service, db);
