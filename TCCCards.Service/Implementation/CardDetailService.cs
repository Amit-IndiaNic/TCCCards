
using System.Collections.Generic;
using System.Linq;
using TCCCards.Models.Card;
using TCCCards.Repository.Contract;
using TCCCards.Service.Contact;
using TCCCards.Service.Core;
using TCCCards.ViewModels.Card;

namespace TCCCards.Service.Implementation
{
    public class CardDetailService: ICardDetailService
    {
        private readonly ICardDetailRepository _cardDetailRepository;
        private readonly IDataMapper _dataMapper;

        public CardDetailService(ICardDetailRepository cardDetailRepository
            , IDataMapper dataMapper)
        {
            _cardDetailRepository = cardDetailRepository;
            _dataMapper = dataMapper;
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
        public CardDetailListViewModel GetById(int Id)
        {
            return _dataMapper.Project<CardDetail, CardDetailListViewModel>
                (_cardDetailRepository.GetAll(s => s.IsActive && s.Id == Id)).ToList().FirstOrDefault();

        }
    }
}
