using System.Collections.Generic;
using TCCCards.ViewModels.Card;

namespace TCCCards.Service.Contact
{
    public interface ICardTemplateService
    {
        List<CardTemplateListViewModel> GetAll();
        CardTemplateListViewModel GetById(int id);
    }
}
