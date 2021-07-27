using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace TCCCards.Service.Core
{
    public class AutomapperDataMapper : IDataMapper
    {
        private readonly IMapper _mapper;

        public AutomapperDataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }

        public IQueryable<TDestination> Project<TSource, TDestination>(IQueryable<TSource> query)
        {
            return query.ProjectTo<TDestination>(_mapper.ConfigurationProvider);
        }
    }
}
