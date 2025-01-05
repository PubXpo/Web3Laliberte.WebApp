using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web3Laliberte.OperationsAPI.Models;
using Web3Laliberte.OperationsAPI.Services;
using Web3Laliberte.OperationsAPI.ViewModels;

namespace Web3Laliberte.OperationsAPI.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _service;

        public FAQController(IFAQService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Returns all FAQs.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            var faqs = await _service.GetAllAsync();
            return Ok(faqs);
        }

        /// <summary>
        ///     Returns a FAQ by ID.
        /// </summary>
        /// <param name="id">The ID of the FAQ.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int id)
        {
            var faq = await _service.GetByIdAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            return Ok(faq);
        }

        /// <summary>
        ///     Creates a new FAQ.
        /// </summary>
        /// <param name="faq">The FAQ view model.</param>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] FAQViewModel faq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faqModel = new FAQ
            {
                Question = faq.Question,
                Answer = faq.Answer
            };

            await _service.AddAsync(faqModel);
            return CreatedAtAction(nameof(GetById), new { id = faqModel.Id }, faqModel);
        }

        /// <summary>
        ///     Updates a FAQ by ID.
        /// </summary>
        /// <param name="id">The ID of the FAQ.</param>
        /// <param name="faq">The FAQ view model.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id, [FromBody] FAQViewModel faq)
        {
            if (id != faq.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faqModel = new FAQ
            {
                Id = faq.Id,
                Question = faq.Question,
                Answer = faq.Answer
            };

            await _service.UpdateAsync(faqModel);
            return NoContent();
        }

        /// <summary>
        ///     Deletes a FAQ by ID.
        /// </summary>
        /// <param name="id">The ID of the FAQ.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var faq = await _service.GetByIdAsync(id);
            if (faq == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}