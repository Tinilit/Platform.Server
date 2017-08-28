using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System.Linq;

namespace Plarform.Server.Controllers
{
    [Authorize]
    [Route("api/profiles")]
    [ValidateModel]
    public class ProfileController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<ProfileController> _logger;
        private IMapper _mapper;

        public ProfileController(IUnitOfWork unitOfWork, ILogger<ProfileController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProfileModel>>(_unitOfWork.UserRepository.GetAllUsers()));
        }

        [HttpGet("{userName}", Name = "profileGet")]
        public IActionResult Get(string userName)
        {
            try
            {
                User user = null;
                user = _unitOfWork.UserRepository.GetUser(userName);
                if (user == null) return NotFound($"user {userName} was not found");
                return Ok(_mapper.Map<ProfileModel>(user));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting profile: {ex}");
                return BadRequest(ex);
            }
        }

        [HttpPut("{userName}")]
        public async Task<IActionResult> Put(string userName, [FromBody] ProfileModel model)
        {
            try
            {
                User user = _unitOfWork.UserRepository.GetUser(userName);
                if (user == null) return NotFound($"could not find user {userName}");
                _mapper.Map(model, user);
                 
                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<ProfileModel>(user));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while modifying profile: {ex}");
                return BadRequest(ex);
            }
            return BadRequest();
        }
    }
}
