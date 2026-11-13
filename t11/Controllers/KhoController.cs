using t11.Application.Dtos.Kho;
using t11.Application.Services;
using t11.Domain.Entities;
using t11.Infrastructure.Persistence;

namespace t11.Controllers;

public sealed class KhoController(
    ICrudService<Kho, string, KhoRequest, KhoResponse> service,
    KhoDbContext db) : CrudController<Kho, string, KhoRequest, KhoResponse>(service, db);
