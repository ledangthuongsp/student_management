using DotNetEnv;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Thêm dịch vụ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

#region Đây là phần kết nối CSDL

// Đọc file .env ở đây
Env.Load();
// Lấy chuỗi kết nối từ file .env
var neonConnectionString = Env.GetString("POSTGRES_DATABASE_URL");
var supabaseConnectionString = Env.GetString("SUPABASE_DATABASE_URL");
builder.Services.AddDbContext<NeonDbContext>(options =>
    options.UseNpgsql(neonConnectionString));
builder.Services.AddDbContext<SupabaseDbContext>(options =>
    options.UseNpgsql(supabaseConnectionString));

#endregion

#region Phần kết nối Swagger
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Cấu hình các dịch vụ
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion


var app = builder.Build();
// Sử dụng CORS
app.UseCors("AllowAllOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Để hiển thị Swagger tại root URL (http://localhost:<port>/)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

