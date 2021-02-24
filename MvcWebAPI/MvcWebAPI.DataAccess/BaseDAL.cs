using MvcWebAPI.DataAccess.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebAPI.DataAccess
{
    public class BaseDAL
    {
        protected MvcApiEntities context;
        public BaseDAL()
        {
            context = new MvcApiEntities();
        }
    }
}
