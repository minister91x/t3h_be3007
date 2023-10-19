using DataAcess.Demo.DBContext;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Services;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<MyShopUnitOfWorkDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("MyConnStr"), b => b.MigrationsAssembly("WebApiCore")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyShopUnitOfWorkDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IMyShopUnitOfWork, MyShopUnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();


builder.Services.AddTransient<IFuncitonServices, FuncitonServices>();
builder.Services.AddTransient<IUserFuncitonServices, UserFuncitonServices>();
//builder.Services.AddTransient<IAccountRepositoryGeneric, AccountRepositoryGeneric>();
//builder.Services.AddTransient<IProductRepositoryGeneric, ProductRepositoryGeneric>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
