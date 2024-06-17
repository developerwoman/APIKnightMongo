using APIKnightMongo.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIKnightMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttributeController : Controller
    {
        private readonly IAttributeService _service;

        public AttributeController(IAttributeService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync().ConfigureAwait(false));
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var attr = await _service.GetByIdAsync(id);
            if (attr == null)
            {
                return NotFound();
            }
            return Ok(attr);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Entities.Attribute attr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.CreateAsync(attr).ConfigureAwait(false);

            return Ok(attr.AttributeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Entities.Attribute attr)
        {
            var existAttr = await _service.GetByIdAsync(id).ConfigureAwait(false);
            if (existAttr == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, attr).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

    }
}
