using DataAcess.Demo.DBContext;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Services;
using DataAcess.Demo.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using WebApiCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<MyShopUnitOfWorkDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("MyConnStr")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IMyShopUnitOfWork, MyShopUnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});
//app.UseMiddleware<SimpleMiddleware>();


app.UseAuthorization();

app.MapControllers();

app.Run();
