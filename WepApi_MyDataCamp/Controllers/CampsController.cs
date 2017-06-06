using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi_MyDataCamp.Controllers
{
    public class CampsController : Controllers
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            var camps = _repo.GetAllCamps();

            return Ok(_mapper.Map<IEnumerable<CampModel>>(camps));
        }

        [HttpGet("{id}", Name = "CampGet")]
        public IActionResult Get(string id, bool includeSpeakers = false)
        {
            try
            {
                Camp camp = null;

                if (includeSpeakers) camp = _repo.GetCampByMonikerWithSpeakers(id);
                else camp = _repo.GetCampByMoniker(id);

                if (camp == null) return NotFound($"Camp {id} was not found");

                return _mapper.Map<CampModel>(camp);
            }
            catch
            {
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CampModel model)
        {

            var camp = _mapper.Map<Camp>(model);

            _repo.Add(camp);
            if (await _repo.SaveAllAsync())
            {
                var newUri = Url.Link("CampGet", new { id = camp.id });
                return Created(newUri, _mapper.Map<CampModel>(camp));
            }
            else
            {
                return NotFound("Could not find ");
            }



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CampModel model)
        {

            var oldCamp = _repo.GetCampByMoniker(id);
            if (oldCamp == null) return NotFound($"Could not find a camp with an id of {id}");

            _mapper.Map(model, oldCamp);

            if (await _repo.SaveAllAsync())
            {
                return Ok(_mapper.Map<CampModel>(oldCamp));
            }

        }
    }
}
