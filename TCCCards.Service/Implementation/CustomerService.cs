using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models.CustomerInfo;
using TCCCards.Repository.Contract;
using TCCCards.Service.Contact;
using TCCCards.Service.Core;
using TCCCards.ViewModels.CustomerInfo;

namespace TCCCards.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDataMapper _dataMapper;

        public CustomerService(ICustomerRepository customerRepository
            , IDataMapper dataMapper)
        {
            _customerRepository = customerRepository;
            _dataMapper = dataMapper;
        }
        public List<CustomerListViewModel> GetAll()
        {
            return _dataMapper.Project<Customer, CustomerListViewModel>
                (_customerRepository.GetAll(s => s.IsActive).OrderBy(s => s.FirstName)).ToList();
        }

        public List<CustomerListViewModel> GetByUserId (int Id)
        {
            return _dataMapper.Project<Customer, CustomerListViewModel>
                (_customerRepository.GetAll(s => s.IsActive && s.User.Id == Id).OrderBy(s => s.FirstName)).ToList();

        }

        public CustomerListViewModel GetById (int Id)
        {
            return _dataMapper.Project<Customer, CustomerListViewModel>
                (_customerRepository.GetAll(s => s.IsActive && s.Id == Id)).ToList().FirstOrDefault();

        }

        //public Customer GetById(int Id)
        //{
        //    var customerData = _customerRepository.GetAll(s => s.IsActive && s.Id == Id).FirstOrDefault();
        //    return customerData;
        //}

    }
}
