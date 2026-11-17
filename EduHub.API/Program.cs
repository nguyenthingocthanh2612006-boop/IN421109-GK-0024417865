
using EduHub.Application.Interfaces;
using EduHub.Application.Services;
using EduHub.Infrastructure.Repositories;
using EduHub.Infrastructure.Notifications;
using EduHub.Infrastructure.Factories;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký Repository
builder.Services.AddSingleton<
    IEventRepository,
    InMemoryEventRepository>();

// Đăng ký dịch vụ thông báo
builder.Services.AddScoped<EmailNotificationService>();
builder.Services.AddScoped<SmsNotificationService>();

// Mặc định sử dụng Email
builder.Services.AddScoped<
    INotificationService,
    EmailNotificationService>();

// Đăng ký Factory và EventService
builder.Services.AddScoped<NotificationFactory>();
builder.Services.AddScoped<EventService>();

// Đăng ký Controllers
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
