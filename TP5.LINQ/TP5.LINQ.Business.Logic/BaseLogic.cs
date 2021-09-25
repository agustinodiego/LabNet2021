using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.LINQ.ResourceAccess.DB;

namespace TP5.LINQ.Business.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext northwindContext;

        public BaseLogic()
        {
            northwindContext = new NorthwindContext();
        }
    }
}
