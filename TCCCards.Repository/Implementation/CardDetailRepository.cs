using TCCCards.Models.Card;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class CardDetailRepository : BaseRepository<CardDetail>, ICardDetailRepository
    {
        public CardDetailRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
