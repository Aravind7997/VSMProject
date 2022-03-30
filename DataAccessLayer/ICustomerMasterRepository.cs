using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICustomerMasterRepository<CustomerMaster>
    {
        IEnumerable<CustomerMaster> GetAllCustomer();
        CustomerMaster GetCustomerById(int id);     
        bool SaveCustomer(CustomerMaster customer);
        bool DeleteCustomer(CustomerMaster customer);    
        bool UpdteCustomer(CustomerMaster customer);
    }
}
