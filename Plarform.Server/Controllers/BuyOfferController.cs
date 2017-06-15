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
    [Route("api/brands/{brandName}/products/{id}/buyoffers")]
    [ValidateModel]
    public class BuyOfferController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public BuyOfferController(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string brandName, int id)
        {
            var buyoffer = _unitOfWork.BuyOfferRepository.GetBuyOffersByProductId(id);
            return Ok(_mapper.Map<IEnumerable<BuyOfferModel>>(buyoffer));
        }

        [HttpGet("{buyofferid}", Name = "BuyOfferGet")]
        public IActionResult Get(string brandName, int id, int buyofferid)
        {
            var buyoffer = _unitOfWork.BuyOfferRepository.GetBuyOffer(buyofferid);
            if (buyoffer == null) return NotFound();
            if (buyoffer.Product.Brand.Name != brandName) return BadRequest();

            return Ok(_mapper.Map<BuyOfferModel>(buyoffer));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string brandName, int id, [FromBody]BuyOfferModel model)
        {
            try
            {
                var brand = _unitOfWork.BrandRepository.GetBrandByBrandName(brandName);
                if (brand == null) return BadRequest("Could not find brand");

                var product = _unitOfWork.ProductRepository.GetProduct(id);
                if (product == null) return BadRequest("Could not find product");

                _unitOfWork.BuyOfferRepository.Add(_mapper.Map<BuyOffer>(model));

                if (await _unitOfWork.SaveAllAsync())
                {
                    var url = Url.Link("BuyOfferGet", new { brandName = brand.Name, id = product.Id });
                    return Created(url, _mapper.Map<BuyOffer>(model));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating product: {ex}");
                throw;
            }

            return BadRequest();
        }

        [HttpPut("{buyofferid}")]
        public async Task<IActionResult> Put(string brandName, int id, int buyofferid, [FromBody] ProductModel model)
        {
            try
            {
                var buyoffer = _unitOfWork.BuyOfferRepository.GetBuyOffer(id);
                if (buyoffer == null) return NotFound("buy offer not found");
                if (buyoffer.Product.Brand.Name != brandName) return BadRequest("Product and Brand do not match");

                _mapper.Map(model, buyoffer);

                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok(_mapper.Map<BuyOffer>(buyoffer));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating Product: {ex}");
                throw;
            }
            return BadRequest("Could not update product");
        }

        [HttpDelete("buyofferid")]
        public async Task<IActionResult> Delete(string brandName, int id, int buyofferid)
        {
            try
            {
                var buyoffer = _unitOfWork.BuyOfferRepository.GetBuyOffer(buyofferid);
                if (buyoffer == null) return NotFound("buy offer not found");
                if (buyoffer.Product.Brand.Name != brandName) return BadRequest("Product and Brand do not match");

                _unitOfWork.BuyOfferRepository.Delete(buyoffer);

                if (await _unitOfWork.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while deleting buy offer: {ex}");
                throw;
            }
            return BadRequest("Could not delete buy offer");
        }
    }
}
