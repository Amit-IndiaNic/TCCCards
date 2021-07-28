using System.Collections.Generic;
using TCCCards.ViewModels.Card;

namespace TCCCards.Service.Contact
{
    public interface ICardDetailService
    {
        List<CardDetailListViewModel> GetAll();
        List<CardDetailListViewModel> GetByCustomerId(int customerId);
        AddEditCardDetailViewModel GetById(int id);
        //int Insert(AddEditCardDetailViewModel model, string userName);
        //int Update(AddEditCardDetailViewModel model, string userName);
    }
}
