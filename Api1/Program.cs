using Microsoft.EntityFrameworkCore;
using Api1.Context;
using Api1.Model;
using api1st.Repositories;
using Api1.Repositories;
using Api1.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BaseEj4>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddControllers();

#region AppRepo

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<UIProjects, ProjectRepository>();
builder.Services.AddScoped<UITimeDedicated, TimeDedicateRepository>();

#endregion

#region AppService
builder.Services.AddScoped<AssignmentService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<TimeDedicatedService>();
#endregion




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
