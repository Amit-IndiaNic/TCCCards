
using Autofac.Features.Indexed;
using System.Collections.Generic;
using System.Linq;
using TCCCards.Models.Card;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;
using TCCCards.Service.Contact;
using TCCCards.Service.Core;
using TCCCards.ViewModels.Card;

namespace TCCCards.Service.Implementation
{
    public class CardDetailService: ICardDetailService
    {
        private readonly ICardDetailRepository _cardDetailRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _cardDetailUnitOfWork;


        public CardDetailService(ICardDetailRepository cardDetailRepository
            , IDataMapper dataMapper
            , IIndex<DataSourceType, IUnitOfWork> unitOfWork)
        {
            _cardDetailRepository = cardDetailRepository;
            _dataMapper = dataMapper;
            _cardDetailUnitOfWork = unitOfWork[DataSourceType.Sql];
        }
        public List<CardDetailListViewModel> GetAll()
        {
            return _dataMapper.Project<CardDetail, CardDetailListViewModel>
                (_cardDetailRepository.GetAll(s => s.IsActive).OrderBy(s => s.Id)).ToList();
        }

        public List<CardDetailListViewModel> GetByCustomerId (int Id)
        {
            return _dataMapper.Project<CardDetail, CardDetailListViewModel>
                (_cardDetailRepository.GetAll(s => s.IsActive && s.Customer.Id == Id).OrderBy(s => s.Id)).ToList();

        }
        public AddEditCardDetailViewModel GetById(int Id)
        {
            return _dataMapper.Project<CardDetail, AddEditCardDetailViewModel>
                (_cardDetailRepository.GetAll(s => s.IsActive && s.Id == Id)).ToList().FirstOrDefault();

        }
    }
}
