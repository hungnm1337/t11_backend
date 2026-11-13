using t11.Application.Dtos.DanhMucVatTu;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class DanhMucVatTuController(
    ICrudService<DanhMucVatTu, string, DanhMucVatTuRequest, DanhMucVatTuResponse> service,
    KhoDbContext db) : CrudController<DanhMucVatTu, string, DanhMucVatTuRequest, DanhMucVatTuResponse>(service, db);
