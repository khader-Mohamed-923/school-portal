using Microsoft.AspNetCore.Diagnostics;

namespace SchoolPortal.Students.Handlers;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // 1. بنسجل الإيرور في الـ Log عشان نشوفه في الـ Console بتاع الدوكر
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        // 2. بنحول المستخدم أوتوماتيك لصفحة الإيرور المشتركة (Redirect)
        httpContext.Response.Redirect("/Home/Error");

        // 3. بنرجع true عشان نقول للـ .NET إحنا كدا مسكنا الإيرور وتصرفنا معاه بنجاح
        return true;
    }
}