using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required(ErrorMessage = "A product must have a name!")]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
