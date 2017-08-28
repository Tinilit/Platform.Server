using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plarform.Server.Mappings
{
    public class TestUrlResolver : IValueResolver<Test, TestModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Test source, TestModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("testGet", new { testId = source.TestId });
        }
    }
}
