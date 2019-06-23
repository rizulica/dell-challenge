using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var model = await _productService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewProductModel newProduct)
        {
            if (!ModelState.IsValid)
                return View(newProduct);

            await _productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel updatedProduct)
        {
            if (!ModelState.IsValid)
                return View(updatedProduct);

            var id = updatedProduct.Id;
            var productDetails = new NewProductModel()
            {
                Category = updatedProduct.Category,
                Name = updatedProduct.Name
            };
            await _productService.Update(id, productDetails);
            return RedirectToAction("Index");
        }
    }
}