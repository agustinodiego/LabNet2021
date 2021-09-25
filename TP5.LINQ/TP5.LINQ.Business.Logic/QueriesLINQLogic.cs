using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.LINQ.Business.Domain;

namespace TP5.LINQ.Business.Logic
{
    public class QueriesLINQLogic : BaseLogic
    {
        public QueriesLINQLogic()
            :base()
        {
        }

        public Customers GetTypeCustommer()
        {
            return northwindContext.Customers.FirstOrDefault();
        }

        public List<Products> ProductsWithOutStock()
        {
            return northwindContext.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> ProductsInStockWhithPriceGreaterThan(decimal unitPrice)
        {
            return northwindContext.Products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > unitPrice).ToList();
        }

        public List<Customers> CustomersInWashingtonRegion()
        {
            var query = from customer in northwindContext.Customers
                        where customer.Region.Equals("WA")
                        select customer;
            return query.ToList();
        }

        public Products FirstElementOrNullProductsByID(int idProduct)
        {
            return northwindContext.Products.FirstOrDefault(p => p.ProductID == idProduct);
        }

        public List<string> CustomersNames(bool inUpperCase)
        {
            var query = from customer in northwindContext.Customers
                        select customer.ContactName;

            List<string> names = new List<string>();

            foreach (var customerName in query)
            {
                if (inUpperCase)
                {
                    names.Add(customerName.ToUpper());
                }
                else
                {
                    names.Add(customerName.ToLower());
                }
            }
            return names;
        }

        public List<CustomerOrder> CustomersInWashingtonRegionAndOrdersDateGreaterThan(DateTime dateTime)
        {
            var query = from customer in northwindContext.Customers
                        join order in northwindContext.Orders
                        on customer.CustomerID.ToUpper() equals order.CustomerID.ToUpper()
                        where customer.Region.Equals("WA") &&
                        order.OrderDate > dateTime
                        select new CustomerOrder
                        {
                            Customer = customer,
                            Order = order
                        };

            return query.ToList<CustomerOrder>();
        }

        public List<Customers> GetSpecificNumberCustomersFromBegin(int numberCustmers)
        {
            var query = (from customer in northwindContext.Customers
                        where customer.Region.Equals("WA")
                        select customer).Take(numberCustmers);

            return query.ToList();
        }

        public List<Products> ProductsOrderByNameAZ()
        {
            return northwindContext.Products.OrderBy(p => p.ProductName).ToList();
        }

        public List<Products> ProductsOrderByUnitsInStockDesc()
        {
            return northwindContext.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }

        public List<Categories> GetAllCategories()
        {
            var query = (from category in northwindContext.Categories
                         select category).Distinct();

            return query.ToList();
        }

        public Products GetFirstProduct()
        {
            return northwindContext.Products.First();
        }

        public List<CustomerCountOrder> GetQuantityOrdersPerCustomer()
        {
            var joinCustomerAndOrder = from customer in northwindContext.Customers
                                       join order in northwindContext.Orders
                                       on customer.CustomerID.ToUpper() equals order.CustomerID.ToUpper()
                                       group customer by customer.CustomerID into cusAndOrd
                                       select new CustomerCountOrder
                                       {
                                           CustomerID = cusAndOrd.Key,
                                           CountOrders = cusAndOrd.ToList().Count()
                                        };

            return joinCustomerAndOrder.ToList();           
        }
    }
}
