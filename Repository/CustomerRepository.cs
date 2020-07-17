using Crud_Operation.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crud_Operation.Repository
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Customer> GetAllCustomer()
        {
            var customers = _db.Customers.ToList();
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            var customer = _db.Customers.Where(a => a.Id == id).FirstOrDefault();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _db.Customers.Where(a => a.Id == id).FirstOrDefault();
            _db.Customers.Remove(customer);
            _db.SaveChanges();

        }
        public List<Customer> ActiveCustomers()
        {
            var customers = _db.Customers.Where(a => a.IsActive == true).ToList();

            return customers;
        }
        public List<Customer> AddCustomer(Customer customer)
        {
            var customers = _db.Customers.ToList();
            return customers;
        }

    }
}
