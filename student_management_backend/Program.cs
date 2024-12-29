using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Thêm các dịch vụ cần thiết cho Authorization
builder.Services.AddAuthorization();

// Thêm các dịch vụ khác như AddAuthentication, AddControllers, AddDbContext, v.v.
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new EUserRoleConverter()); });
// Đọc biến môi trường từ file .env
Env.Load();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5025"; // Sử dụng cổng 5025

// Đăng ký dịch vụ
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<OtpService>(); // Thêm OtpService

// Cấu hình CORS
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

// Kết nối CSDL
var neonConnectionString = Env.GetString("POSTGRES_DATABASE_URL");
var supabaseConnectionString = Env.GetString("SUPABASE_DATABASE_URL");

builder.Services.AddDbContext<NeonDbContext>(options =>
    options.UseNpgsql(neonConnectionString));

builder.Services.AddDbContext<SupabaseDbContext>(options =>
    options.UseNpgsql(supabaseConnectionString));

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Student Management API",
        Version = "v1",
        Description = "This API is used for managing student data.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Le Dang Thuong",
            Email = "ledangthuongsp@gmail.com",
            Url = new Uri("https://ledangthuongsp.github.io/ThuongProfile")
        }
    })
);

var app = builder.Build();

// Sử dụng CORS
app.UseCors("AllowAllOrigins");

// Hiển thị Swagger ở cả môi trường production và development
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Để hiển thị Swagger tại root URL
    });
}

app.Urls.Add($"http://*:{port}");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();
