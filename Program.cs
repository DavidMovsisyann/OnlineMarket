using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataBase;
using OnlineMarket.Mapper;
using OnlineMarket.Repositories;
using OnlineMarket.RepsitoryInterfaces;
using OnlineMarket.ServiceInterfaces;
using OnlineMarket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<UsersService>();
builder.Services.AddTransient<OrdersService>();
builder.Services.AddTransient<CategoriesService>();
builder.Services.AddTransient<ProductsService>();

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
