using t11.Application.Dtos.DoiTac;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class DoiTacController(
    ICrudService<DoiTac, string, DoiTacRequest, DoiTacResponse> service,
    KhoDbContext db) : CrudController<DoiTac, string, DoiTacRequest, DoiTacResponse>(service, db);
