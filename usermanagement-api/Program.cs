using Microsoft.EntityFrameworkCore;
using usermanagement_api.Context;
using usermanagement_api.Interfaces;
using usermanagement_api.Middleware;
using usermanagement_api.Repositories;
using usermanagement_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

//builder.Services.AddAutoMapper(typeof(UserMappingProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<ApiLoggingMiddleware>();
app.UseMiddleware<TokenValidationMiddleware>();

app.UseHttpsRedirection();

//app.UseRouting();
app.MapControllers();
app.Run();
