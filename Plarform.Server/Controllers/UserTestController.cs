using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plarform.Server.Filters;
using Plarform.Server.Models;
using Platform.DataAccess.Entities;
using Platform.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plarform.Server.Controllers
{
    [Authorize]
    [Route("api/usertests")]
    [ValidateModel]
    public class UserTestController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<UserTestController> _logger;
        private IMapper _mapper;

        public UserTestController(IUnitOfWork unitOfWork, ILogger<UserTestController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_mapper.Map<IEnumerable<UserTestModel>>(_unitOfWork.UserTestRepository.GetAllUserTests()));
        }

        [HttpGet("{userTestId}", Name = "userTestGet")]
        public IActionResult Get(int userTestId)
        {
            try
            {
                UserTest userTest = null;
                userTest = _unitOfWork.UserTestRepository.GetUserTestById(userTestId);
                if (userTest == null) return NotFound($"userTest {userTest} was not found");
                return Ok(_mapper.Map<UserTestModel>(userTest));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting userTest: {ex}");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _logger.LogInformation("Creating a new userTest");
                var userTest = _mapper.Map<UserTest>(model);
                _unitOfWork.UserTestRepository.Add(userTest);
                if (await _unitOfWork.SaveAllAsync())
                {
                    var uri = Url.Link("userTestGet", new { userTestId = userTest.UserTestId });
                    return Created(uri, _mapper.Map<UserTestModel>(userTest));
                }
                _logger.LogWarning("Could not save userTest to database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving userTest: {ex}");
                return BadRequest(ex);
            }

            return BadRequest();
        }

        [HttpPut("{userTestId}")]
        public async Task<IActionResult> Put(int userTestId, [FromBody] UserTestModel model)
        {
            try
            {
                var userTest = _unitOfWork.UserTestRepository.GetUserTestById(userTestId);
                if (userTest == null) return NotFound($"could not find userTest with an id of {userTestId}");
                _mapper.Map(model, userTest);
                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<UserTestModel>(userTest));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while modifying userTest: {ex}");
                return BadRequest(ex);
            }
            return BadRequest();
        }

        [HttpDelete("{userTestId}")]
        public async Task<IActionResult> Delete(int userTestId)
        {
            try
            {
                var userTest = _unitOfWork.UserTestRepository.GetUserTestById(userTestId);
                if (userTest == null) return NotFound($"userTest with id {userTestId} not found");
                _unitOfWork.UserTestRepository.Delete(userTest);
                if (await _unitOfWork.SaveAllAsync()) return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while deleting userTest: {ex}");
                return BadRequest(ex);
            }
            return BadRequest("Could not delete userTest");
        }
    }
}
