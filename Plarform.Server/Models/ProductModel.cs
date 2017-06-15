using System;

namespace Plarform.Server.Models
{
    public class ProductModel
    {
        public string Url { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }

        public string BrandName { get; set; }
    }
}
