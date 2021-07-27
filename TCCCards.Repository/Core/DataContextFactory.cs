using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCCards.Repository.Data;

namespace TCCCards.Repository.Core
{
    public enum DataSourceType
    {
        MySql = 1,
        Sql = 2,
        MasterSql = 3
    }
    public class DataContextFactory
    {
        private readonly IIndex<DataSourceType, IDataContext> _dataContext;
        public DataContextFactory(IIndex<DataSourceType, IDataContext> dataContext)
        {
            _dataContext = dataContext;
        }

        public IDataContext GetDataContext(DataSourceType type)
        {
            try
            {
                return _dataContext[type];
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
