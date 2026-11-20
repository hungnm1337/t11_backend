using t11.Application.Dtos.PhieuNhap;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class PhieuNhapCrudController(
    ICrudService<PhieuNhap, string, PhieuNhapHeaderRequest, PhieuNhapResponse> service,
    KhoDbContext db)
    : CrudController<PhieuNhap, string, PhieuNhapHeaderRequest, PhieuNhapResponse>(service, db);
