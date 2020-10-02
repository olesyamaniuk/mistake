using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerDAL
    {
        CustomerDTO GetCustomerById(int id);
        CustomerDTO GetCustomerByName(string name);
        List<CustomerDTO> GetCustomers();
        CustomerDTO UpdateCustomer(CustomerDTO seller);
        CustomerDTO CreateCustomer(CustomerDTO seller);
        void DeleteCustomer(int id);
    }
}
