using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomeCustomers
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();
    }
}
