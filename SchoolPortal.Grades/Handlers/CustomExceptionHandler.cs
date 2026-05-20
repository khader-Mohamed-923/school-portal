using Microsoft.AspNetCore.Diagnostics;

namespace SchoolPortal.Grades.Handlers;

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
        // 1. تسجيل الخطأ في الـ Console الخاص بكونتينر الدرجات
        _logger.LogError(exception, "Grades Service Error: {Message}", exception.Message);

        // 2. تحويل المستخدم لصفحة الإيرور العامة في الـ HomeController
        httpContext.Response.Redirect("/Home/Error");

        // 3. تأكيد التعامل مع الخطأ بنجاح
        return true;
    }
}