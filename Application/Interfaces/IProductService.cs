using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();    
        Task<Product> GetProductById(int id);
        Task<bool>UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);

    }
}
