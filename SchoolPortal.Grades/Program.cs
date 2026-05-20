using Microsoft.EntityFrameworkCore;
using SchoolPortal.Grades.Data;
using SchoolPortal.Grades.Handlers;
using SchoolPortal.Grades.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddExceptionHandler<CustomExceptionHandler>(); 
builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<StudentsClient>(client =>
{
    var studentsUrl = builder.Configuration["Services:StudentsUrl"] ?? "http://students-service:8080";
    client.BaseAddress = new Uri(studentsUrl);
});

builder.Services.AddDbContext<GradeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseExceptionHandler(); 

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseRouting();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Auto-create and migrate the database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GradeDbContext>();
    db.Database.Migrate();
}

app.Run();