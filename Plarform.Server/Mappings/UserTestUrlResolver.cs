using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class UserTestUrlResolver : IValueResolver<UserTest, UserTestModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserTestUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(UserTest source, UserTestModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("userTestGet", new { userTestId = source.UserTestId });
        }
    }
}
