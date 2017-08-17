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
    [Route("api/testTypes")]
    //[ValidateModel]
    public class TestTypeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<BrandsController> _logger;
        private IMapper _mapper;

        public TestTypeController(IUnitOfWork unitOfWork, ILogger<BrandsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<TestTypeModel>>(_unitOfWork.TestTypeRepository.Get()));
        }

        [HttpGet("{testTypeId}", Name = "testTypeGet")]
        public IActionResult GetById(int testTypeId)
        {
            try
            {
                TestType testType = null;
                testType = _unitOfWork.TestTypeRepository.GetById(testTypeId);
                if (testType == null) return NotFound($"test type by id {testTypeId} was not found");
                return Ok(_mapper.Map<TestTypeModel>(testType));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting test type: {ex}");
                return BadRequest(ex);
            }
        }
    }
}
