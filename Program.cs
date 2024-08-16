using BE_Shopdunk.Data;
using BE_Shopdunk.Interface;
using BE_Shopdunk.Model;
using BE_Shopdunk.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDBContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipelinse.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
