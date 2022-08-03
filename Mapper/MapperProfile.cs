using AutoMapper;
using OnlineMarket.Entities;
using OnlineMarket.RequestModels;

namespace OnlineMarket.Mapper
{
    public class MapperProfile:Profile
    {

        public MapperProfile()
        {
            CreateMap<CategoryEntity, CategoryModel>();
            CreateMap<CategoryModel, CategoryEntity>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<OrderEntity, OrderModel>();
            CreateMap<OrderModel, OrderEntity>();
        }
    }
}
