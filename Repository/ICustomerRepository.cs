using Crud_Operation.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_Operation.Repository
{
    interface ICustomerRepository
    {
        public List<Customer> GetAllCustomer();
        public Customer GetCustomer(int id);
        public void DeleteCustomer(int id);
        public List<Customer> ActiveCustomers();
        public List<Customer> AddCustomer(Customer customer);
    }
}
