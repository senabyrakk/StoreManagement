using AutoMapper;
using Foundation.Abstraction.Repository;
using Foundation.Abstraction.Service;
using Foundation.Contract;
using StoreManagement.Domain.Model;
using System.Collections.Generic;

namespace StoreManagement.Business.Service
{
    public class CustomerService : ICustomerService
    {
     
            readonly ICustomerRepository _CustomerRepository;
            private readonly IMapper _mapper;
            public CustomerService(IMapper mapper, ICustomerRepository CustomerRepository)
            {
                _CustomerRepository = CustomerRepository;
                _mapper = mapper;
            }

            public CustomerContract Add(CustomerContract Category)
            {
                var result = _mapper.Map<CustomerContract, Customer>(Category);
                var enttyi =  _CustomerRepository.Add(result);
               var contract = _mapper.Map<Customer, CustomerContract>(enttyi);
            return contract;
            }

            public void Delete(int Id)
            {

                var result = _CustomerRepository.Get(x => x.Id == Id);
            _CustomerRepository.Delete(result);
            }

            public CustomerContract Get(int Id)
            {
                var result = _CustomerRepository.Get(x => x.Id == Id);
                return _mapper.Map<Customer, CustomerContract>(result);
            }

            public List<CustomerContract> GetAll()
            {
                var result = _CustomerRepository.GetList();
                return _mapper.Map<List<Customer>, List<CustomerContract>>(result);
            }

            public void Update(CustomerContract Category)
            {
                var result = _mapper.Map<CustomerContract, Customer>(Category);
               _CustomerRepository.Update(result);

            }
        }
    }
