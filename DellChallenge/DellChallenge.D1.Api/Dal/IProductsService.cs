using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetByID(string id);
        Task<ProductDto> Add(NewProductDto newProduct);
        Task<bool> Delete(string id);
        Task<bool> Update(string id, NewProductDto updatedProduct);
    }
}
