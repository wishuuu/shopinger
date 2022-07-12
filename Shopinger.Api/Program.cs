using Bogus;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Infrastructure;
using Shopinger.Infrastructure.Fakers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Faker<Product>, ProductFaker>();
builder.Services.AddSingleton<Faker<Employee>, EmployeeFaker>();
builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();

builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();
builder.Services.AddSingleton<IEmployeeRepository, FakeEmployeeRepository>();
builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();

builder.Services.Configure<FakeRepositoryOptions>(builder.Configuration.GetSection("FakeRepositoryOptions"));

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