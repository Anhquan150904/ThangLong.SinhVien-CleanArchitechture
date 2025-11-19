using ThangLong.Application.Services;
using ThangLong.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lấy connection string từ Environment Variable
var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION") ?? "Server=tcp:thanglongserver.database.windows.net,1433;Initial Catalog=ThangLong;Persist Security Info=False;User ID=adminuser;Password=Vuquan15@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Environment variable SQLSERVER_CONNECTION is not set!");
}

// Add Infrastructure / DbContext với connection string
builder.Services.AddInfrastructure(builder.Configuration);

// Add service
builder.Services.AddScoped<SinhVienService>();

// Add Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: cho phép mọi frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
