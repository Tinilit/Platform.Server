using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Interfaces;

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
            return Ok(_mapper.Map<IEnumerable<ProfileModel>>(_unitOfWork.ProfileRepository.GetAllProfiles()));
        }

        [HttpGet("{userName}", Name = "profileGet")]
        public IActionResult Get(string userName)
        {
            try
            {
                var profile = _unitOfWork.ProfileRepository.GetProfileByUserName(userName);
                if (profile == null) return NotFound($"user {userName} was not found");
                return Ok(_mapper.Map<ProfileModel>(profile));
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
                var profile = _unitOfWork.ProfileRepository.GetProfileByUserName(userName);
                if (profile == null) return NotFound($"could not find user {userName}");
                _mapper.Map(model, profile);
                 
                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<ProfileModel>(profile));
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
