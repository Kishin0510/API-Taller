using Api_Taller.src.Data;
using DotNetEnv;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Api_Taller.src.Helpers;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cloudinarySettings = builder.Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
    var cloudinaryAccount = new Account(
        cloudinarySettings!.CloudName,
        cloudinarySettings.ApiKey,
        cloudinarySettings.ApiSecret
    );
    var cloudinary = new Cloudinary(cloudinaryAccount);
    builder.Services.AddSingleton(cloudinary);

string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source=app.db"; 
builder.Services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();

using ( var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();
    DataSeeder.Initialize(services);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.Run();