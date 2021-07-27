using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Models.Card;
using TCCCards.Repository.Contract;
using TCCCards.Service.Contact;
using TCCCards.Service.Core;
using TCCCards.ViewModels.Card;

namespace TCCCards.Service.Implementation
{
    public class CardTemplateService : ICardTemplateService
    {
        private readonly ICardTemplateRepository _cardTemplateRepository;
        private readonly IDataMapper _dataMapper;

        public CardTemplateService(ICardTemplateRepository cardTemplateRepository
            , IDataMapper dataMapper)
        {
            _cardTemplateRepository = cardTemplateRepository;
            _dataMapper = dataMapper;
        }
        public List<CardTemplateListViewModel> GetAll()
        {
            return _dataMapper.Project<CardTemplate, CardTemplateListViewModel>
                (_cardTemplateRepository.GetAll(s => s.IsActive).OrderBy(s => s.TemplateName)).ToList();
        }

        public CardTemplateListViewModel GetById(int Id)
        {
            return _dataMapper.Project<CardTemplate, CardTemplateListViewModel>
                (_cardTemplateRepository.GetAll(s => s.IsActive && s.Id == Id)).ToList().FirstOrDefault();

        }
    }
}
