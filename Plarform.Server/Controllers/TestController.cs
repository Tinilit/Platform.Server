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

namespace Plarform.Server.Controllers
{
    //[Authorize]
    [Route("api/tests")]
    //[ValidateModel]
    public class TestController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<BrandsController> _logger;
        private IMapper _mapper;

        public TestController(IUnitOfWork unitOfWork, ILogger<BrandsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _logger.LogInformation("Creating a new test");
                var test = _mapper.Map<Test>(model);
                _unitOfWork.TestRepository.Add(test);
                if (await _unitOfWork.SaveAllAsync())
                {
                    var uri = Url.Link("TestGet", new { testName = test.Id });
                    return Created(uri, _mapper.Map<BrandModel>(test));
                }
                _logger.LogWarning("Could not save test to database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving test: {ex}");
                return BadRequest(ex);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(_mapper.Map<IEnumerable<TestModel>>(_unitOfWork.TestRepository.Get()));
        }

        [HttpGet("{testId}", Name = "testGet")]
        public IActionResult GetById(int testId)
        {
            try
            {
                Test test= null;
                test = _unitOfWork.TestRepository.GetById(testId);
                if (test == null) return NotFound($"test by id {testId} was not found");
                return Ok(_mapper.Map<TestModel>(test));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting test: {ex}");
                return BadRequest(ex);
            }
        }
    }
}
