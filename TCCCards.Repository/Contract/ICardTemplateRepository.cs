using System.Linq;
using TCCCards.Models.Card;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Contract
{
    public interface ICardTemplateRepository : IBaseRepository<CardTemplate>
    {
        //IQueryable<CardTemplate> GetAllActive();
    }
}
