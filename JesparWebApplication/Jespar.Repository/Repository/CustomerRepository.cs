using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.DatabaseContext.DatabaseContext;

namespace Jespar.Repository.Repository
{
    public class CustomerRepository
    {
        JesparDbContext _dbContext = new JesparDbContext();
        public bool Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Customer aCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            _dbContext.Customers.Remove(aCustomer);
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateLoyaltyPoint(Customer customer)
        {
            Customer aCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if(aCustomer != null)
            {
                aCustomer.LoyaltyPoint = customer.LoyaltyPoint;
            }
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Customer customer)
        {
            Customer aCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (aCustomer != null)
            {
                aCustomer.CustomerCode = customer.CustomerCode;
                aCustomer.CustomerName = customer.CustomerName;
                aCustomer.Contact = customer.Contact;
                aCustomer.CustomerEmail = customer.CustomerEmail;
                aCustomer.CustomerAddress = customer.CustomerAddress;
                aCustomer.LoyaltyPoint = customer.LoyaltyPoint;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Customer> GetAll()
        {

            return _dbContext.Customers.ToList();
        }
        public Customer GetById(int Id)
        {

            return _dbContext.Customers.FirstOrDefault((c => c.Id == Id));
        }
    }
}
