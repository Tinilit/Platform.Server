using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plarform.Server.Controllers;
using Plarform.Server.Models;

namespace Plarform.Server.Mappings
{
    public class ProfileUrlResolver : IValueResolver<Platform.DataAccess.Entities.Profile, ProfileModel, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Platform.DataAccess.Entities.Profile source, ProfileModel destination, string destMember, ResolutionContext context)
        {
            var url = (IUrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.URLHELPER];
            return url.Link("profileGet", new { userName = source.User.UserName });
        }
    }
}