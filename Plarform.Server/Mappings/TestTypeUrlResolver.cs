using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class TestTypeUrlResolver : IValueResolver<TestType, TestTypeModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestTypeUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(TestType source, TestTypeModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("testTypeGet", new { testTypeId = source.TestTypeId });
        }
    }
}
