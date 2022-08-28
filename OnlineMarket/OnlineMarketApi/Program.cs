using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMarketBBL.Mapper;
using OnlineMarketDAL.Repositories;
using OnlineMarketCore.RepsitoryInterfaces;
using OnlineMarket.ServiceInterfaces;
using OnlineMarketBLL.Services;
using OnlineMarketCore.RepositoryInterfaces;
using OnlineMarketDal.DataBase;
using OnlineMarketApi.ExceptionHandler;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarketApi.Chat;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"), x => x.MigrationsAssembly("OnlineMarketDal"));
});

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataBaseContext>()));
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IProductsService, ProductsService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) Commented for IIS deploy
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection(); Commented for IIS deploy

app.UseRouting();

app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});

app.Run();
