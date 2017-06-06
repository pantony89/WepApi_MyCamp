using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi_MyDataCamp.Controllers
{
    public class SpeakersController:Controller
    {
      

        [HttpGet]
        public IActionResult Get(string moniker, bool includeTalks = false)
        {

            var speakers = includeTalks ? _repository.GetSpeakersByMonikerWithTalks(moniker) : _repository.GetSpeakersByMoniker(moniker);

            return Ok(_mapper.Map<IEnumerable<SpeakerModel>>(speakers));
        }
    }
}
