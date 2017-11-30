using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plarform.Server.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ValidateModel]
    public class UserController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<UserController> _logger;
        private IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<UserModel>>(_unitOfWork.UserRepository.GetAllUsers()));
        }
    }
}
