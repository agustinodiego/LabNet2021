using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.SOLUCION.Business.Domain;

namespace TP.SOLUCION.Business.Logic
{
    public class CategoriesLogic : BaseLogic, ICommonLogic<Categories>
    {
        public void Insert(Categories entity)
        {
            try
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var category = context.Categories.Single(c => c.CategoryID == id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Categories> GetAll()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Categories GetByID(int id)
        {
            try
            {
                return context.Categories.Single(c => c.CategoryID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(Categories entity)
        {
            try
            {
                var categoryUpdate = context.Categories.Single(c => c.CategoryID == entity.CategoryID);
                categoryUpdate.CategoryName = entity.CategoryName;
                categoryUpdate.Description = entity.Description;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
