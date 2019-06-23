using DellChallenge.D2.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAll();
        Task<ProductModel> GetById(string id);
        Task<ProductModel> Add(NewProductModel newProduct);
        Task<bool> Delete(string id);
        Task<bool> Update(string id, NewProductModel updatedProduct);
    }
}