using AutoMapper;
using OrderManagement.DBEntities.Models;
using OrderManagement.Models;
using OrderManagement.Models.Result;

namespace OrderManagement.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Result, WriteResult>();
            CreateMap<WriteResult, Result>();
        }
    }
}
