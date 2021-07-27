using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCCards.Service.Core
{
    public interface IDataMapper
    {
        /// <summary>
        /// Create new instance of destination and map Source to Destination
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Use existing destination object and map source to destination
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        /// <summary>
        /// Projects Source query to destination query
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        IQueryable<TDestination> Project<TSource, TDestination>(IQueryable<TSource> query);
    }
}
