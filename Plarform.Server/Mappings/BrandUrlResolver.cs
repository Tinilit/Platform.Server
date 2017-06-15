using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class BrandUrlResolver : IValueResolver<Brand, BrandModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BrandUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Brand source, BrandModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("brandGet", new { brandName = source.Name });
        }
    }
}
