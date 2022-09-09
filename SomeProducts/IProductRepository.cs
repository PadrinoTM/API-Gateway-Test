using System.Collections.Generic;
using System.Threading.Tasks;

namespace SomeProducts
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
    }
}
