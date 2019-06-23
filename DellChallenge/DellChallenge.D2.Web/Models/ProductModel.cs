using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Models
{
    public class ProductModel : NewProductModel
    {
        [HiddenInput]
        public string Id { get; set; }
    }
}
