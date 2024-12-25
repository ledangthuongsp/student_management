using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Đọc biến môi trường từ file .env
Env.Load();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5025"; // Sử dụng cổng 5025

// Thêm dịch vụ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .WithOrigins("https://student-management-se100.onrender.com");
        });
});

builder.Services.AddScoped<ExceptionMiddleware>();

#region Đây là phần kết nối CSDL

// Lấy chuỗi kết nối từ file .env
var neonConnectionString = Env.GetString("POSTGRES_DATABASE_URL");
var supabaseConnectionString = Env.GetString("SUPABASE_DATABASE_URL");
#region Phần kết nối Swagger
// Cấu hình các dịch vụ
builder.Services.AddSingleton<OtpService>(); // Thêm OtpService
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Spotify Backend Remake", // Đặt tên mới cho Swagger
        Version = "v1",
        Description = "This API is used for managing music data.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Le Dang Thuong",
            Email = "ledangthuongsp@gmail.com",
            Url = new Uri("https://ledangthuongsp.github.io/ThuongProfile")
        }
    })
);
#endregion
// Đăng ký các DbContext
builder.Services.AddDbContext<NeonDbContext>(options =>
    options.UseNpgsql(neonConnectionString));

builder.Services.AddDbContext<SupabaseDbContext>(options =>
    options.UseNpgsql(supabaseConnectionString));
#endregion

#region Phần kết nối Swagger
// Cấu hình các dịch vụ
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

// Sử dụng CORS
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // Hiển thị Swagger cả trong môi trường production
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Để hiển thị Swagger tại root URL
    });
}

// Lắng nghe cổng 5025
app.Urls.Add($"http://*:{port}");

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();
