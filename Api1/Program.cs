using Microsoft.EntityFrameworkCore;
using Api1.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BaseEj4>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
