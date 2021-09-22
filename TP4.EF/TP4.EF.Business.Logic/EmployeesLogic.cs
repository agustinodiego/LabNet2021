using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.EF.Business.Domain;

namespace TP4.EF.Business.Logic
{
    public class EmployeesLogic : BaseLogic, ICommonLogic<Employees>
    {
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

        public void Add(Employees employee)
        {
            try
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idEmployee)
        {
            try
            {
                var employee = context.Employees.Single(c => c.EmployeeID == idEmployee);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            catch(Exception ex)
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

        public void Update(Employees employee)
        {
            try
            {
                var categoryUpdate = context.Employees.Single(c => c.EmployeeID == employee.EmployeeID);
                //Modificacion
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
