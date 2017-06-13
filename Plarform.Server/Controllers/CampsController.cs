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
    [Route("api/camps")]
    [ValidateModel]
    public class CampsController : BaseController
    {
        private ICampRepository _campRepository;
        private ILogger<CampsController> _logger;
        private IMapper _mapper;

        public CampsController(ICampRepository capmRepository, ILogger<CampsController> logger, IMapper mapper)
        {
            _campRepository = capmRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<CampModel>>(_campRepository.GetAllCamps()));
        }

        [HttpGet("{moniker}", Name = "CampGet")]
        public IActionResult Get(string moniker, bool includeSpeakers = false)
        {
            try
            {
                Camp camp = null;
                camp = includeSpeakers ? _campRepository.GetCampByMonikerWithSpeakers(moniker) : _campRepository.GetCampByMoniker(moniker);
                if (camp == null) return NotFound($"camp {moniker} was not found");
                return Ok(_mapper.Map<CampModel>(camp));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while getting camp: {ex}");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CampModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                _logger.LogInformation("Creating a new code camp");
                var camp = _mapper.Map<Camp>(model);
                _campRepository.Add(camp);
                if (await _campRepository.SaveAllAsync())
                {
                    var uri = Url.Link("CampGet", new { moniker = camp.Moniker });
                    return Created(uri, _mapper.Map<CampModel>(camp));
                }
                _logger.LogWarning("Could not save camp to database");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while saving camp: {ex}");
                return BadRequest(ex);
            }

            return BadRequest();
        }

        [HttpPut("{moniker}")]
        public async Task<IActionResult> Put(string moniker, [FromBody] CampModel model)
        {
            try
            {
                var camp = _campRepository.GetCampByMoniker(moniker);
                if (camp == null) return NotFound($"could not find camp with an id of {moniker}");
                _mapper.Map(model, camp);
                if (await _campRepository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<CampModel>(camp));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while modifying camp: {ex}");
                return BadRequest(ex);
            }
            return BadRequest();
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var camp = _campRepository.GetCampByMoniker(moniker);
                if (camp == null) return NotFound($"camp with id {moniker} not found");
                _campRepository.Delete(camp);
                if (await _campRepository.SaveAllAsync()) return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Threw exception while deleting camp: {ex}");
                return BadRequest(ex);
            }
            return BadRequest("Could not delete camp");
        }
    }
}
