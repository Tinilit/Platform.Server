using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;

namespace Plarform.Server.Mappings
{
    public class ProfileUrlResolver : IValueResolver<User, ProfileModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(User source, ProfileModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("userGet", new { userName = source.UserName });
        }
    }
}