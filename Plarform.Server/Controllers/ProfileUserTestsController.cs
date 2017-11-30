using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Plarform.Server.Controllers
{
    [Authorize]
    [Route("api/profile-user-tests")]
    [ValidateModel]
    public class ProfileUserTestsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<ProfileUserTestsController> _logger;
        private IMapper _mapper;

        public ProfileUserTestsController(IUnitOfWork unitOfWork, ILogger<ProfileUserTestsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{profileId}")]
        public IActionResult Get(string profileId)
        {
            return Ok(_mapper.Map<IEnumerable<UserTestModel>>(_unitOfWork.UserTestRepository.GetUserTestsByProviderId(profileId)));
        }
    }
}
