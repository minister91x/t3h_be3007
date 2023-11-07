using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Dapper
{
    public abstract class BaseApplicationService
    {
        protected IApplicationDbConnection DbConnectionHelper { get; }
        public BaseApplicationService(IServiceProvider serviceProvider)
        {
            DbConnectionHelper = serviceProvider.GetRequiredService<IApplicationDbConnection>(); ;
        }

    }

}