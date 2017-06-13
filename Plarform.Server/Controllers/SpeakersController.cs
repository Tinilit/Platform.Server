using System;
using System.Collections;
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
    [Route("api/camps/{moniker}/speakers")]
    [ValidateModel]
    public class SpeakersController : BaseController
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SpeakersController> _logger;

        public SpeakersController(ISpeakerRepository speakerRepository,
            ICampRepository campRepository,
            IMapper mapper,
            ILogger<SpeakersController> logger)
        {
            _speakerRepository = speakerRepository;
            _campRepository = campRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string moniker)
        {
            var speakers = _speakerRepository.GetSpeakersByMoniker(moniker);
            return Ok(_mapper.Map<IEnumerable<SpeakerModel>>(speakers));
        }

        [HttpGet("{id}", Name = "SpeakerGet")]
        public IActionResult Get(string moniker, int id)
        {
            var speaker = _speakerRepository.GetSpeaker(id);
            if (speaker == null) return NotFound();
            if (speaker.Camp.Moniker != moniker) return BadRequest();

            return Ok(_mapper.Map<SpeakerModel>(speaker));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string moniker, [FromBody]SpeakerModel model)
        {
            try
            {
                var camp = _campRepository.GetCampByMoniker(moniker);
                if (camp == null) return BadRequest("Could not find camp");

                var speaker = _mapper.Map<Speaker>(model);
                speaker.Camp = camp;

                _speakerRepository.Add(speaker);

                if (await _speakerRepository.SaveAllAsync())
                {
                    var url = Url.Link("SpeakerGet", new { moniker = camp.Moniker, id = speaker.Id });
                    return Created(url, _mapper.Map<SpeakerModel>(speaker));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating speaker: {ex}");
                throw;
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(string moniker, int id, [FromBody] SpeakerModel model)
        {
            try
            {
                var speaker = _speakerRepository.GetSpeaker(id);
                if (speaker == null) return NotFound("Speaker not found");
                if (speaker.Camp.Moniker != moniker) return BadRequest("Speaker and Camp do not match");

                _mapper.Map(model, speaker);

                if (await _speakerRepository.SaveAllAsync())
                {
                    return Ok(_mapper.Map<SpeakerModel>(speaker));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while updating speaker: {ex}");
                throw;
            }
            return BadRequest("Could not update speaker");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string moniker, int id)
        {
            try
            {
                var speaker = _speakerRepository.GetSpeaker(id);
                if (speaker == null) return NotFound("Speaker not found");
                if (speaker.Camp.Moniker != moniker) return BadRequest("Speaker and Camp do not match");

                _speakerRepository.Delete(speaker);

                if (await _speakerRepository.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while deleting speaker: {ex}");
                throw;
            }
            return BadRequest("Could not delete speaker");
        }
    }
}
