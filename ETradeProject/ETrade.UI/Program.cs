using ETrade.Dal;
using ETrade.DTO;
using ETrade.Entities.Concrete;
using ETrade.Repository.Abstract;
using ETrade.Repository.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ETradeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoryRep, CategoryRep<Category>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductRep, ProductRep<Product>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IUserRep, UserRep<User>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Response>();
builder.Services.AddScoped<UserDTO>();

// Add services to the container.

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
