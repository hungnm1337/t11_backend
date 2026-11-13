using t11.Application.Dtos.NguyenLieu;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class NguyenLieuController(
    ICrudService<NguyenLieu, string, NguyenLieuRequest, NguyenLieuResponse> service,
    KhoDbContext db) : CrudController<NguyenLieu, string, NguyenLieuRequest, NguyenLieuResponse>(service, db);
