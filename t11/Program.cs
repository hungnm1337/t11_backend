using Npgsql;
using Microsoft.EntityFrameworkCore;
using Mapster;
using t11.Application.Mapping;
using t11.Infrastructure.Persistence;
using t11.Infrastructure.Services;
using t11.ExceptionHandling;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? ["http://localhost:3000"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<KhoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Supabase")));
var mapsterConfig = TypeAdapterConfig.GlobalSettings;
CrudMapsterConfiguration.Register(mapsterConfig);
builder.Services.AddSingleton(mapsterConfig);
builder.Services.AddCrudServices();
builder.Services.AddExceptionHandler<DatabaseExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.MapGet("/ping", async (IConfiguration cfg) =>
{
    await using var conn = new NpgsqlConnection(cfg.GetConnectionString("Supabase"));
    await conn.OpenAsync();
    await using var cmd = new NpgsqlCommand(
        "select count(*) from information_schema.tables where table_schema = 'public'", conn);
    return $"Ket noi OK. So bang trong schema public: {await cmd.ExecuteScalarAsync()}";
});



app.UseHttpsRedirection();

app.UseCors("Frontend");
app.UseAuthorization();

app.MapControllers();

app.Run();
