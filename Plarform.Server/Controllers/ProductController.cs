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
    [Route("api/brands/{brandName}/products")]
    [ValidateModel]
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string brandName)
        {
            var products = _unitOfWork.ProductRepository.GetProductsByBrandName(brandName);
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(products));
        }

        [HttpGet("{id}", Name = "ProductGet")]
        public IActionResult Get(string brandName, int id)
        {
            var product = _unitOfWork.ProductRepository.GetProduct(id);
            if (product == null) return NotFound();
            if (product.Brand.Name != brandName) return BadRequest();

            return Ok(_mapper.Map<ProductModel>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string brandName, [FromBody]ProductModel model)
        {
            try
            {
                var brand = _unitOfWork.BrandRepository.GetBrandByBrandName(brandName);
                if (brand == null) return BadRequest("Could not find product");

                var product = _mapper.Map<Product>(model);
                product.Brand = brand;

                _unitOfWork.ProductRepository.Add(product);

                if (await _unitOfWork.SaveAllAsync())
                {
                    var url = Url.Link("ProductGet", new { brandName = brand.Name, id = product.Id });
                    return Created(url, _mapper.Map<ProductModel>(product));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating product: {ex}");
                throw;
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(string brandName, int id, [FromBody] ProductModel model)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetProduct(id);
                if (product == null) return NotFound("Product not found");
                if (product.Brand.Name != brandName) return BadRequest("Product and Brand do not match");

                _mapper.Map(model, product);

                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<ProductModel>(product));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating Product: {ex}");
                throw;
            }
            return BadRequest("Could not update product");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string brandName, int id)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetProduct(id);
                if (product == null) return NotFound("Product not found");
                if (product.Brand.Name != brandName) return BadRequest("Product and Brand do not match");

                _unitOfWork.ProductRepository.Delete(product);

                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while deleting product: {ex}");
                throw;
            }
            return BadRequest("Could not delete product");
        }
    }
}
