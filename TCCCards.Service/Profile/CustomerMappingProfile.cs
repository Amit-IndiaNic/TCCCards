using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models.Card;
using TCCCards.Models.CustomerInfo;
using TCCCards.Models.Payment;
using TCCCards.ViewModels.Card;
using TCCCards.ViewModels.CustomerInfo;
using TCCCards.ViewModels.Payment;

namespace TCCCards.Service.Profile
{
    public class CustomerMappingProfile : AutoMapper.Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerListViewModel>().ReverseMap();
            CreateMap<AddEditCustomerViewModel, Customer>().ReverseMap();

            CreateMap<Address, AddressListViewModel>().ReverseMap();
            CreateMap<AddEditAddressViewModel, Address>().ReverseMap();

            CreateMap<CardDetail, CardDetailListViewModel>().ReverseMap();
            CreateMap<AddEditCardDetailViewModel, CardDetail>().ReverseMap();

            CreateMap<CardTemplate, CardTemplateListViewModel>().ReverseMap();
            CreateMap<AddEditCardTemplateViewModel, CardTemplate>().ReverseMap();

            CreateMap<Order, OrderListViewModel>().ReverseMap();
            CreateMap<AddEditOrderViewModel, Order>().ReverseMap();

            CreateMap<PaymentType, PaymentTypeListViewModel>().ReverseMap();
            CreateMap<AddEditPaymentTypeViewModel, PaymentType>().ReverseMap();

        }
    }
}
