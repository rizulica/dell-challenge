using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ProductDto>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<ProductDto>>();
            Task.Run(() =>
            {
                tcs.SetResult(_context.Products.Select(p => MapToDto(p)));
            });

            return tcs.Task;
        }

        public Task<ProductDto> GetByID(string Id)
        {
            var tcs = new TaskCompletionSource<ProductDto>();
            Task.Run(() =>
            {
                tcs.SetResult(_context.Products.Where(p => p.Id == Id).Select(p => MapToDto(p)).FirstOrDefault());
            });

            return tcs.Task;
        }

        public Task<ProductDto> Add(NewProductDto newProduct)
        {
            var tcs = new TaskCompletionSource<ProductDto>();
            Task.Run(() =>
            {
                var product = MapToData(newProduct);
                _context.Products.Add(product);
                _context.SaveChanges();
                var addedDto = MapToDto(product);
                tcs.SetResult(addedDto);
            });

            return tcs.Task;
        }

        public Task<bool> Delete(string id)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(() =>
            {
                var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                    tcs.SetResult(false);

                _context.Products.Remove(product);
                _context.SaveChanges();
                tcs.SetResult(true);
            });

            return tcs.Task;
        }

        public Task<bool> Update(string id, NewProductDto updatedProduct)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(() =>
            {
                var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
                if (product == null)
                    tcs.SetResult(false);

                product.Name = updatedProduct.Name;
                product.Category = updatedProduct.Category;
                _context.SaveChanges();
                tcs.SetResult(true);
            });

            return tcs.Task;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
