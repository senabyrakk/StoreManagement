using AutoMapper;
using Foundation.Abstraction.Repository;
using Foundation.Abstraction.Service;
using Foundation.Contract;
using StoreManagement.Domain.Model;
using System.Collections.Generic;

namespace StoreManagement.Business.Service
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productContractRepository)
        {
            _productRepository = productContractRepository;
            _mapper = mapper;
        }

        public ProductContract Add(ProductContract Category)
        {
            var result = _mapper.Map<ProductContract, Product>(Category);
            _productRepository.Add(result);
            return Category;
        }

        public void Delete(int Id)
        {

            var result = _productRepository.Get(x => x.Id == Id);
            _productRepository.Delete(result);
        }

        public ProductContract Get(int Id)
        {
            var result = _productRepository.Get(x => x.Id == Id);
            return _mapper.Map<Product, ProductContract>(result);
        }

        public List<ProductContract> GetAll()
        {
            var result = _productRepository.GetList();
            return _mapper.Map<List<Product>, List<ProductContract>>(result);
        }

        public string StockControl()
        {
           return _productRepository.StockControl();
        }

        public void Update(ProductContract Category)
        {
            var result = _mapper.Map<ProductContract, Product>(Category);
            _productRepository.Update(result);

        }
    }
}
