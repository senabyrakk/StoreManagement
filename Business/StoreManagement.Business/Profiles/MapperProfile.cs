using AutoMapper;
using Foundation.Contract;
using StoreManagement.Domain.Model;

namespace StoreManagement.Business.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ProductRegister();
            CustomerRegister();
        }

        private void ProductRegister()
        {
            CreateMap<Product, ProductContract>();

            CreateMap<ProductContract, Product>();
        }
        private void CustomerRegister()
        {
            CreateMap<Customer, CustomerContract>();

            CreateMap<CustomerContract, Customer>();
        }

    }
}
