using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductModel> Add(NewProductModel newProduct)
        {
            var tcs = new TaskCompletionSource<ProductModel>();
            Task.Run(() =>
            {
                var apiClient = new RestClient("http://localhost:2534/api");
                var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
                apiRequest.AddJsonBody(newProduct);
                var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
                tcs.SetResult(apiResponse.Data);
            });

            return tcs.Task;
        }

        public Task<IEnumerable<ProductModel>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<ProductModel>>();
            Task.Run(() =>
            {
                var apiClient = new RestClient("http://localhost:2534/api");
                var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
                var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
                tcs.SetResult(apiResponse.Data);
            });

            return tcs.Task;
        }

        public Task<ProductModel> GetById(string id)
        {
            var tcs = new TaskCompletionSource<ProductModel>();
            Task.Run(() =>
            {
                var apiClient = new RestClient("http://localhost:2534/api");
                var apiRequest = new RestRequest("products/" + id, Method.GET, DataFormat.Json);
                var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
                tcs.SetResult(apiResponse.Data.FirstOrDefault());
            });

            return tcs.Task;
        }

        public Task<bool> Delete(string id)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(() =>
            {
                var apiClient = new RestClient("http://localhost:2534/api");
                var apiRequest = new RestRequest("products/" + id, Method.DELETE, DataFormat.Json);
                var apiResponse = apiClient.Execute(apiRequest);
                tcs.SetResult(apiResponse.StatusCode == System.Net.HttpStatusCode.OK);
            });

            return tcs.Task;
        }

        public Task<bool> Update(string id, NewProductModel updatedProduct)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task.Run(() =>
            {
                var apiClient = new RestClient("http://localhost:2534/api");
                var apiRequest = new RestRequest("products/" + id, Method.PUT, DataFormat.Json);
                apiRequest.AddJsonBody(updatedProduct);
                var apiResponse = apiClient.Execute(apiRequest);
                tcs.SetResult(apiResponse.StatusCode == System.Net.HttpStatusCode.OK);
            });

            return tcs.Task;
        }
    }
}
