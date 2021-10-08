using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.SOLUCION.Business.Domain;

namespace TP.SOLUCION.Business.Logic
{
    public class EmployeesLogic : BaseLogic, ICommonLogic<Employees>
    {
        public void Insert(Employees entity)
        {
            try
            {
                context.Employees.Add(entity);
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
                var category = context.Employees.Single(c => c.EmployeeID == id);
                context.Employees.Remove(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employees> GetAll()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees GetByID(int id)
        {
            try
            {
                return context.Employees.Single(c => c.EmployeeID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Employees entity)
        {
            try
            {
                var employeeUpdate = context.Employees.Single(c => c.EmployeeID == entity.EmployeeID);
                employeeUpdate.Title = entity.Title;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
