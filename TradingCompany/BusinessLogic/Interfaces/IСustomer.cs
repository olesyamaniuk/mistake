using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO AddCustomer(CustomerDTO user);
        CustomerDTO UpdateCustomer(CustomerDTO user);
        void ShowCustomer();
        CustomerDTO GetCustomerById(int ID);
        CustomerDTO GetCustomerByName(string Name);
    }
}
