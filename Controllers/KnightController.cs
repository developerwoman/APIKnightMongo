using System.Threading.Tasks;
using APIKnightMongo.Entities;
using APIKnightMongo.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIKnightMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnightController : ControllerBase
    {
        private readonly IKnightService _service;

        //private readonly ILogger<KnightController> _logger;

        public KnightController(ILogger<KnightController> logger, IKnightService service)
        {
            //_logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll().ConfigureAwait(false));
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var knight = await _service.GetById(id).ConfigureAwait(false);
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }
        //[HttpGet("{?filter=heroes}")]
        //public async Task<IActionResult> GetHeroes([FromRoute] string heroes)
        //{
        //    var knight = await _knightService.GetHeroes
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Knight knight)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    await _knightService.Create(knight).ConfigureAwait(false);
        //    return Ok(knight.KnightId);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody] Knight knight)
        {
            var existKnight = await _service.GetById(id).ConfigureAwait(true);
            if (existKnight == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, knight).ConfigureAwait(true);
            return NoContent();
        }


        //[HttpPut]
        //public async Task<IActionResult> Update(string id, [FromBody] Entities.Attribute attr)
        //{
        //    var existAttr = await _service.GetById(id).ConfigureAwait(true);
        //    if (existAttr == null)
        //    {
        //        return NotFound();
        //    }
        //    await _service.UpdateAsync(id, attr).ConfigureAwait(false);

        //    return NoContent();
        //}

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {            
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
