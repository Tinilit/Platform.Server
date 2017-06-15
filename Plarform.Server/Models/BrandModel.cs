using System.ComponentModel.DataAnnotations;

namespace Plarform.Server.Models
{
    public class BrandModel
    {
        public string Url { get; set; }
        [Required]
        public string BrandName { get; set; }
    }
}
