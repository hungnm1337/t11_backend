using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using t11.Application.Services;

namespace t11.ExceptionHandling;

public sealed class DatabaseExceptionHandler(
    ILogger<DatabaseExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Lỗi khi xử lý yêu cầu API.");

        var (status, title, detail) = exception switch
        {
            EntityConflictException => (
                StatusCodes.Status409Conflict,
                "Dữ liệu bị trùng.",
                exception.Message),
            EntityValidationException => (
                StatusCodes.Status400BadRequest,
                "Dữ liệu không hợp lệ.",
                exception.Message),
            DbUpdateException dbException => MapDatabaseException(dbException),
            _ => (
                StatusCodes.Status500InternalServerError,
                "Đã xảy ra lỗi máy chủ.",
                "Yêu cầu không thể được xử lý.")
        };

        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path
        };

        httpContext.Response.StatusCode = status;
        httpContext.Response.ContentType = "application/problem+json";
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
        return true;
    }

    private static (int Status, string Title, string Detail) MapDatabaseException(
        DbUpdateException exception)
    {
        var postgresException = exception.GetBaseException() as PostgresException;
        return postgresException?.SqlState switch
        {
            PostgresErrorCodes.ForeignKeyViolation => (
                StatusCodes.Status409Conflict,
                "Không thể cập nhật tham chiếu.",
                "Tham chiếu đến bản ghi không tồn tại hoặc bản ghi đang được sử dụng."),
            PostgresErrorCodes.UniqueViolation => (
                StatusCodes.Status409Conflict,
                "Dữ liệu bị trùng.",
                "Mã đã tồn tại."),
            PostgresErrorCodes.CheckViolation => (
                StatusCodes.Status400BadRequest,
                "Dữ liệu không hợp lệ.",
                "Dữ liệu không thỏa mãn điều kiện ràng buộc."),
            PostgresErrorCodes.NotNullViolation => (
                StatusCodes.Status400BadRequest,
                "Thiếu dữ liệu bắt buộc.",
                "Một hoặc nhiều trường bắt buộc chưa được cung cấp."),
            _ => (
                StatusCodes.Status500InternalServerError,
                "Lỗi cơ sở dữ liệu.",
                "Không thể hoàn tất thao tác dữ liệu.")
        };
    }
}
