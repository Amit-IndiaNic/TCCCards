using TCCCards.Models.Card;
using TCCCards.Repository.Contract;
using TCCCards.Repository.Core;

namespace TCCCards.Repository.Implementation
{
    public class CardTemplateRepository : BaseRepository<CardTemplate>, ICardTemplateRepository
    {
        public CardTemplateRepository(DataContextFactory dataContextFactory)
            : base(dataContextFactory.GetDataContext(DataSourceType.Sql))
        {

        }

    }
}
