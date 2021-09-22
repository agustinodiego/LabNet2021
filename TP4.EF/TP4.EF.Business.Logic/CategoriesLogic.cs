using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.EF.Business.Domain;

namespace TP4.EF.Business.Logic
{
    public class CategoriesLogic : BaseLogic, ICommonLogic<Categories>
    {
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

        public List<Categories> GetAll()
        {
            try
            {
                return context.Categories.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Add(Categories category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idCategory)
        {
            try
            {
                var category = context.Categories.Single(c => c.CategoryID == idCategory);
                context.Categories.Remove(category);
                context.SaveChanges();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Categories category)
        {
            try
            {
                var categoryUpdate = context.Categories.Single(c => c.CategoryID == category.CategoryID);
                categoryUpdate.Description = category.Description;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
