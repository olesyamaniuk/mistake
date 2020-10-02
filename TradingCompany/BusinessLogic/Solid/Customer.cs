using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class Customer : ICustomer
    {
        private readonly ICustomerDAL _customerDAL;



        public Customer(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public CustomerDTO AddCustomer(CustomerDTO customer)
        {
            Console.WriteLine("Enter FullName, Mail, Login, Password");
            customer = new CustomerDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),
                Login = Console.ReadLine(),
                Password = Convert.ToByte(Console.ReadLine())
            };



            return _customerDAL.CreateCustomer(customer);
        }




        public CustomerDTO GetCustomerById(int id)
        {
            return _customerDAL.GetCustomerById(id);
        }

        public void ShowCustomer()
        {
            Console.WriteLine("All Customers:\n");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var customer in _customerDAL.GetCustomers())
            {
                Console.WriteLine($"{customer.ID}\t{customer.FullName}\t{customer.Login}");

            }
        }



        public CustomerDTO UpdateCustomer(CustomerDTO customer)
        {
            Console.WriteLine("Change Customer inf0: \n");
            Console.WriteLine("FullName, Mail");
            customer = new CustomerDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),

            };


            return _customerDAL.UpdateCustomer(customer);
        }

        public CustomerDTO GetCustomerByName(string Name)
        {
            return _customerDAL.GetCustomerByName(Name);
        }
    }

}
