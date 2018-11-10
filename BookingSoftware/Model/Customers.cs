using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSoftware.Model
{
    public class Customers
    {
        private Customer _customer;
        private List<Customer> _allCustomers;

        public List<Customer> GetAllCustomers()
        {
            return _allCustomers;
        }
    }
}
