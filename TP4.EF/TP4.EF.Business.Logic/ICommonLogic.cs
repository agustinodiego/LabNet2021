using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.EF.Business.Logic
{
    public interface ICommonLogic<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
