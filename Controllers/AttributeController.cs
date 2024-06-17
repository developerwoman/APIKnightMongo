using APIKnightMongo.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
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

            return Ok(attr._id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id,[FromBody] Entities.Attribute attr)
        {
            var existAttr = await _service.GetByIdAsync(id).ConfigureAwait(true);
            if (existAttr == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, attr).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

    }
}
