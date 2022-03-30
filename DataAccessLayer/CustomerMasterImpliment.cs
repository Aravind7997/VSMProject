using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerMasterImpliment : ICustomerMasterRepository<CustomerMaster>
    {
        public bool DeleteCustomer(CustomerMaster customer)
        {
            try
            {
                VSMSEntities dbContext=new VSMSEntities();
                var cust=dbContext.CustomerMasters.Where(x=>x.CustId==customer.CustId).FirstOrDefault();
                dbContext.CustomerMasters.Remove(cust);
                dbContext.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<CustomerMaster> GetAllCustomer()
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var customers = dbContext.CustomerMasters.ToList();
                return customers;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerMaster GetCustomerById(int id)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var customer=dbContext.CustomerMasters.Where(x=>x.CustId==id).FirstOrDefault();
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveCustomer(CustomerMaster customer)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                dbContext.CustomerMasters.Add(customer);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdteCustomer(CustomerMaster customer)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var cust = dbContext.CustomerMasters.Where(x => x.CustId==customer.CustId).FirstOrDefault();
                cust.CustId = customer.CustId;  
                cust.FirstName= customer.FirstName; 
                cust.LastName= customer.LastName;
                cust.ContactNo= customer.ContactNo;
                cust.Email= customer.Email;
                cust.City   = customer.City;
                cust.Country = customer.Country;    
                cust.States = customer.States;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
