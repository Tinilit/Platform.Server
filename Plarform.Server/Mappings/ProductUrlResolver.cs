using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class ProductUrlResolver : IValueResolver<Product, ProductModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Product source, ProductModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("brandGet", new { brandName = source.Brand.Name, id = source.Id });
        }
    }
}
