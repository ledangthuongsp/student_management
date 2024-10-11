using DotNetEnv;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// Đọc file .env ở đây
Env.Load();

// Lấy chuỗi kết nối từ file .env
var neonConnectionString = Env.GetString("POSTGRES_DATABASE_URL");
var supabaseConnectionString = Env.GetString("SUPABASE_DATABASE_URL");

builder.Services.AddDbContext<NeonDbContext>(options =>
    options.UseNpgsql(neonConnectionString));

builder.Services.AddDbContext<SupabaseDbContext>(options =>
    options.UseNpgsql(supabaseConnectionString));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

