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
    [Authorize]
    [Route("api/brands")]
    [ValidateModel]
    public class BrandsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<BrandsController> _logger;
        private IMapper _mapper;

        public BrandsController(IUnitOfWork unitOfWork, ILogger<BrandsController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<BrandModel>>(_unitOfWork.BrandRepository.GetAllBrands()));
        }

        [HttpGet("{brandName}", Name = "brandGet")]
        public IActionResult Get(string brandName, bool includeProducts = false)
        {
            try
            {
                Brand brand = null;
                brand = includeProducts
                    ? _unitOfWork.BrandRepository.GetBrandByBrandNameWithProducts(brandName)
                    : _unitOfWork.BrandRepository.GetBrandByBrandName(brandName);
                if (brand == null) return NotFound($"brand {brandName} was not found");
                return Ok(_mapper.Map<BrandModel>(brand));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting brand: {ex}");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrandModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _logger.LogInformation("Creating a new brand");
                var brand = _mapper.Map<Brand>(model);
                _unitOfWork.BrandRepository.Add(brand);
                if (await _unitOfWork.SaveAllAsync())
                {
                    var uri = Url.Link("BrandGet", new { brandName = brand.Name });
                    return Created(uri, _mapper.Map<BrandModel>(brand));
                }
                _logger.LogWarning("Could not save brand to database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving brand: {ex}");
                return BadRequest(ex);
            }

            return BadRequest();
        }

        [HttpPut("{brandName}")]
        public async Task<IActionResult> Put(string brandName, [FromBody] BrandModel model)
        {
            try
            {
                var brand = _unitOfWork.BrandRepository.GetBrandByBrandName(brandName);
                if (brand == null) return NotFound($"could not find brand with an id of {brandName}");
                _mapper.Map(model, brand);
                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<BrandModel>(brand));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while modifying brand: {ex}");
                return BadRequest(ex);
            }
            return BadRequest();
        }

        [HttpDelete("{brandName}")]
        public async Task<IActionResult> Delete(string brandName)
        {
            try
            {
                var brand = _unitOfWork.BrandRepository.GetBrandByBrandName(brandName);
                if (brand == null) return NotFound($"brand with id {brandName} not found");
                _unitOfWork.BrandRepository.Delete(brand);
                if (await _unitOfWork.SaveAllAsync()) return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while deleting brand: {ex}");
                return BadRequest(ex);
            }
            return BadRequest("Could not delete brand");
        }
    }
}
