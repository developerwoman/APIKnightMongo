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
        private readonly IKnightService _knightService;

        private readonly ILogger<KnightController> _logger;

        public KnightController(ILogger<KnightController> logger, IKnightService knightService)
        {
            _logger = logger;
            _knightService = knightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _knightService.GetAll().ConfigureAwait(false));
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var knight = await _knightService.GetById(id).ConfigureAwait(false);
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

        [HttpPost]
        public async Task<IActionResult> Create(Knight knight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _knightService.Create(knight).ConfigureAwait(false);
            return Ok(knight.KnightId);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(int id, Knight knight)
        {
            var existKnight = await _knightService.GetById(id).ConfigureAwait(false);
            if (existKnight == null)
            {
                return NotFound();
            }
            await _knightService.UpdateAsync(id, knight).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(int id)
        {            
            await _knightService.DeleteAsync(id);
            return NoContent();
        }
    }
}
